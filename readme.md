    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    // FUNCTION DPDTRUN
    //
    // For a given flyby of a nominal body position Pnom, calculate the
    // ephemeris of a pseudo-body (CB3 or P) directly uptrack or downtrack
    // (i.e. along the flyby velocity vector) from Pnom, such that if any
    // spacecraft (S/C) instrument points its boresight at CB3 throughout
    // the flyby, the scan rate (radians/second) of the actual body, at an
    // unknown position but assumed to be fixed directly uptrack or
    // downtrack wrt Pnom, across that boresight will remain constant.
    //
    //                                           |         |          |
    //                                       --->|deltaX(t)|<---      |
    //                                           |         |          |
    //                                           |     --->|   P(t)   |<---
    //                                           |         |          |
    //                                           |         |          |
    //   ----------------------------------------|---------CB3(t)-----Pnom
    //     ^           +Y                        |        /
    //     |           ^                         |       /
    //     |           |                         |      /<==Boresight
    //     |           | Inertial                |     /
    //   deltaY        | Reference               |    /
    //     |           | Frame                 ->|   /<-Theta, positive away
    //     |          -+----------->+X           |  /   from +Y toward +X
    //     |           |                         | /
    //     V                                     |/
    //   ----------------------------------------Sc(t)====>-------------
    //                                                   ^
    //                                                   |
    //                        Flyby velocity vector, V --+  ||V|| = vFb
    //
    //
    // RETURN VALUE:
    // =============
    //
    // Structures containing, among other things
    // - .Ts        = array of seconds past nominal body TCA* (i.e. t-TCA), s
    // - .PsFormula = P(t) from analytical solution to the differential equation
    // - .PsRK4     = P(t) Runge-Kutta integration solution to the diff. eqn.
    //
    // * TCA => Time of Closest Approach, of spacecraft to Pnom
    //
    //   - N.B. .PsRK4 and .PsFormula correspond to .Ts values
    //
    // - Input parameters as used
    // - Various calculated rates, ranges, derivatives
    //
    //
    // ARGUMENTS:
    // ==========
    //
    // dThDtTDI  TMR:  desired scan rate of actual body across FOV, rad/s
    //           - A positive value means that the CB3 moves downtrack with
    //             respect to Pnom, even as Theta may decrease or increase,
    //             with increasing time
    // deltaY    Flyby (Fb) distance, km
    // vFb       Speed of flyby, km/s, should be non-negative
    // DelT      Integration timestep, s; defaults to 1s if not present
    //
    //
    // KEYWORDS:
    // =========
    //
    // xEll_km=xEll_km     Extent of ellipse to be covered wrt nominal target, km
    //                     - If one value specified:  -|xEll_km| to +|xEll_km|
    //                     - If two values specified:  min(xEll_km) to max(xEll_km)
    //                        - positive implies => +X => direction of S/C velocity
    //                     - This procedure integrates the CB3 position between
    //                       these two values at a minimum
    //
    //
    // xEll_s=xEll_s       IFF xEll_km not specified, extent of ellipse
    //                     wrt nominal target, s past CA (t - TCA) at vFb
    //                     - default: 150s
    //                     - same scheme as xEll_km for one or two values
    //                     - same scheme as xEll_km for one or two values
    //                       - positive implies => +X => direction of S/C velocity
    //
    // xCb3_0_km=xCb3_0_km   Initial CB3 position wrt nominal target, km
    //                       - positive implies => +X => direction of S/C velocity
    // xCb3_0_s=xCb3_0_s     IFF xCb3_0_km not specified, initial CB3 position
    //                       wrt nominal target, s past CA (CB3t0 - TCA) at vFb
    //                       - default:  0s
    //                       - positive implies => +X => direction of S/C velocity
    //
    // xSc0_km=xSc0_km       Initial S/C position wrt nominal target, km
    //                       - positive implies => +X => direction of S/C velocity
    // xSc0_s=xSc0_s         IFF xSc0_km not specified, initial S/C position
    //                       wrt nominal target, s past CA (SCt0 - TCA) at vFb
    //                       - default:  0s
    //                       - positive implies => +X => direction of S/C velocity
    //
    // debug                 Enable debugging output
    //
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    // FUNCTION DPDT
    //
    // Derivative function to support DPDTRUN:  used as argument Derivs
    // to 4-order Runge-Kutta solution.  See derivation below.
    //
    // ARGUMENTS:
    // ==========
    //
    // theTime   Time at which to calculate derivative
    // pATt      Current value of P = CB3(t)
    //
    function dpdt, theTime, pATt, initstruct=instr
    common dpdt_cmn, dThDtTDI, deltaY, vFb
    if n_elements(instr) eq 1L then begin
      dThDtTDI = double(instr.dThDtTDI) // desired net scan rate, rad/s
      deltaY = double(instr.deltaY)     // Flyby distance, km/s
      vFb = double(instr.vFb)           // Flyby speed, km
      return,[0d0]
    endif
    t = double(theTime[0])
    deltaX = double(pATt[0]) - (vFb * t)
    return, dThDtTDI * [deltaY  + (deltaX * deltaX / deltaY) ]
    end
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    // Derivation of dPdT function:
    ////////////////////////////////////////////////////////////////////////
    //
    // Refer to the diagram above.
    //
    // A spacecraft (S/C) is flying by an object (i.e. Pluto) with a
    // position uncertainty ellipsoid that is shaped like a cigar with its
    // long axis along the flyby velocity vector.  It is desired to scan an
    // instrument boresight along the long axis of the uncertainty
    // ellipsoid such that, whereever the  object is, when the scan passes
    // over it, the object moves across the FOV at a fixed angular rate,
    // typically the scan rate of a Time Delay  Integration (TDI) CCD
    // converted via the optics geometry to radian/s.
    //
    // The scan rate across a S/C instrument's FOV of an object
    // at [Pnom + CB3(t)] is
    //
    //   dThDtTDI = dThDt + dThDtFb                                     [1]
    //
    // where
    //
    //   Pnom     = Nominal target position = inertial frame origin
    //   CB3(t)   = Time-dependent offset from Pnom along X, vector [P(t),0,0]
    //   dThDtTDI = Desired scan rate, constant, rad/s
    //   Theta(t) = Inertial angle of boresight, +Y=0, +X positive, radians
    //   dThDt    = dTheta / dt, inertial angular rate of Theta, rad/s
    //   dThDtFb  = Instantaneous scan rate of a fixed target at CB3(t) wrt
    //                FOV due to S/C-target translational motion, rad/s
    //
    // Since Theta(t) is by definition the instantaneous angle of the
    // boresight pointing at any actual fixed target at CB3(t) from S/C(t),
    // the scan rate contribution of that fixed target across the boresight
    // due to relative translational motion is the ratio of [the motion of
    // the fixed object perpendicular to the boresight] to [the range
    // between the S/C and the fixed object]:
    //
    //             vFb * cos(Theta)                 2
    //  dThDtFb = ---------------------- = vFb * cos (Theta) / deltaY   [2]
    //            deltaY / cos(Theta)
    //
    //
    // Substituting into [1] and solving for dThDt,
    //
    //                                2
    //  dThDt = dThDtTDI  -  vFb * cos (Theta) / deltaY                 [3]
    //
    // The distance along the flyby direction (+X) between the spacecraft
    // and the object can be derived from two formulae:
    //
    //  deltaX = P(t)  -  vFb * t                                       [4]
    //  deltaX = deltaY * tan(Theta)                                    [5]
    //
    // where t is time and is zero at TCA to Pnom.  Setting [4] equal to [5]
    // and solving for P(t) yields
    //
    //  P(t) = deltaY * tan(Theta)  +  vFb * t                          [6]
    //
    //
    // Solving for dP/dt yields
    //
    //                     2
    //  dP/dt = (deltaY/cos (Theta)) * dTh/dt  +  vFb                   [7]
    //
    //
    // Substituting [3] for dTh/dt into [7]:
    //
    //                                                 2
    //            deltaY        /             vFb * cos (Theta) \
    //  dP/dt = -----------  * ( dThDtTDI  -  -----------------  )  +  vFb
    //             2            \                   deltaY      /
    //          cos (Theta)
    //
    //                                 2
    //  dP/dt = deltaY * dThDtTDI / cos (Theta)  -  vFb  +  vFb
    //
    //                                 2
    //  dP/dt = deltaY * dThDtTDI / cos (Theta)                         [8]
    //
    //
    // Substituting the trigonomtric identity
    //
    //     2                    2          2         2
    //  cos (Theta(t)) =  deltaY  / (deltaY  + deltaX  )
    //
    //
    // yields
    //
    //                                    2         2
    //                              deltaY  + deltaX
    //  dP/dt = deltaY * dThDtTDI * -------------------
    //                                         2
    //                                   deltaY
    //
    //
    // and, after rearranging,
    //
    //                                         2
    //                      /            deltaX  \
    //  dP/dt = dThDtTDI * (  deltaY  +  ------   )                     [9]
    //                      \            deltaY  /
    //
    //
    // Finally, substituting equation [4] for deltaX yields the equation
    // [10], which is used in method dpdt above as part of the 4th-order
    // Runge-Kutta solution:
    //
    //                                                 2
    //                      /          (P(t) - vFb * t)  \
    //  dP/dt = dThDtTDI * (  deltaY + -----------------  )            [10]
    //                      \               deltaY       /
    //
    ////////////////////////////////////////////////////////////////////////
    // Final note:
    // When the range to the object is large and/or the flyby distance
    // (deltaY) is large compared to the distance the S/C moves during the
    // scan, dThDtFb is essentially constant, and this derivation is not
    // relevant.
    //
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    // Analytical solution (developed after the RK4 solution)
    //                               2
    //  dThDt = dThDtTDI -  vFb * cos (Theta) / deltaY                  [3]
    //
    // Substituting
    //
    //  b^2   = vFb / (dThDtTDI * deltaY)
    //
    //   - see Note 1 below for case where this quantity is negative
    //
    // yields
    //
    //        dTheta
    //  --------------------- = dThDtTDI * dt   [11]
    //               2
    //  1 - b^2 * cos (Theta)
    //                                                         2
    // N.B. for b^2=1, the left side of [11] becomes dTheta/sin (Theta)
    //
    // Substituting
    //
    //  broot = SQRT(b^2 - 1)     if b^2 > 1
    //
    //  broot = SQRT(1 - b^2)     if b^2 < 1
    //
    // and integrating both sides of [11] (see Notes 1) depending on the
    // value of b^2:
    //
    //                1        / tan(Theta) - broot \
    //  b^2 > 1:  --------- ln( ------------------   ) = dThDtTDI * t + C  [12a]
    //            2 * broot    \ tan(Theta) + broot /
    //
    //
    //              1      -1 / tan(Theta) \
    //  b^2 < 1:  ----- tan  (  ----------  )          = dThDtTDI * t + C  [12b]
    //            broot       \   broot    /
    //
    //
    //  b^2 = 1:  - cot(Theta)  =  - 1 / tan(Theta)    = dThDtTDI * t + C  [12c]
    //
    //
    // where C is the constant of integration and may be evaluated at t = zero
    // as the left hand sides of [12*]; any other time tReal may be converted
    // to 't' by means of a constant offset (t = tReal - tReal0), and Theta(t=0)
    // defined as ThetaReal(tReal=tReal0), the initial condition for the ODE.
    //
    // Note 1:  Integrals 376, 375, & 308  in section A of "CRC Handbook of
    //          Chemistry and Physics," Weast, Robert C. (ed), 56th edition,
    //          CRC Press, pp. A-136, A-138, 1974.  The first form of integral
    //          376 and the is essentially identical to 375 where 375 covers the
    //          case where dThDtTDI is negative.
    //
    // Substituting
    //
    //  deltaX/deltaY = tan(Theta)
    //
    //  T             = dThDtTDI * t + C
    //
    // into [12*] and solving for deltaX:
    //
    //
    //                    deltaY * broot * ( exp(2*broot*T) + 1 )
    // b^2 > 1:  deltaX = ---------------------------------------       [13a]
    //                         1 + exp(2*broot*T)
    //
    // b^2 < 1:  deltaX = deltaY * broot * tan(broot*T) + 1 )           [13b]
    //
    // b^2 < 1:  deltaX = - deltaY / T                                  [13c]
    //
    ////////////////////////////////////////////////////////////////////////
    function deltaXSolved, t, initDeltaX0=argDeltaX0
    common dpdt_cmn
    common dxsd_cmn, b2, broot, constint

    //////////////////////////////////
    // - calculate constants, store in common block:
    //   - b2 => b^2
    //   - broot = SQRT(b^2 - 1) or SQRT(1 - b^2)
    //   - constant of integration

    if n_elements(argDeltaX0) eq 1L then begin

      deltaX0 = double(argDeltaX0[0])

      b2 = vFb / ( dThDtTDI * deltaY)
      broot = sqrt(abs(b2 - 1))
      tanth = deltaX0 / deltaY

      ////////////////////////////////
      // - constant of integration

      if b2 gt 1d0 then begin
        constint = alog( (tanth - broot) / (tanth + broot) ) / (2d0 * broot)
      endif else if b2 lt 1d0 then begin
        constint = atan( tanth / broot) / broot
      endif else begin
        constint = - deltaY / deltaX0
      endelse
      return, 0d0
    endif

    //////////////////////////////////
    // - calculate solution

    kTplusC = (dThDtTDI * double(t[0])) + constint

    //////////////////////////////////
    // Equation [13a]:  b^2 > 1

    if b2 gt 1d0 then begin
      exp2BT = exp(2d0 * broot * kTplusC)
      return, deltaY * ( broot * (1d0 + exp2BT) ) / (1d0 - exp2BT)
    endif

    //////////////////////////////////
    // Equation [13b]:  b^2 < 1

    if b2 lt 1d0 then return, deltaY * broot * tan(broot * kTplusC)

    //////////////////////////////////
    // Equation [13c]:  b^2 = 1

    return, - deltaY / kTplusC

    end

    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    function gettx,sVal,tx,pfx=pfx
    pfxLcl = n_elements(pfx) eq 1L ? strtrim(pfx[0],2) : ""
    return,string(f="(a,a,a,a,a,a,a,a,a)",pfxLcl,"<t",tx,">",strtrim(sVal,2),"</t",tx,">")
    end
    function getthead,sVal,pfx=pfx
    return,gettx(sVal,"head",pfx=pfx)
    end
    function gettd,sVal,pfx=pfx
    return,gettx(sVal,"d",pfx=pfx)
    end
    function getth,sVal,pfx=pfx
    return,gettx(sVal,"h",pfx=pfx)
    end
    function gettr,sVal,pfx=pfx
    return,gettx(sVal,"r",pfx=pfx)
    end
    function gethdpair,sName,xVal
    s = getth(sName)
    s = gettd(xVal,pfx=s)
    return, gettr(s)
    end
    pro pla,lun,s
    printf,lun,f="(a)",s
    end

    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    function dpdtrun, argDThDtTDI, argDeltaY, argVFb, argDelT $
                  , xEll_km=xEll_km, xEll_s=xEll_s $
                  , xCb3_0_km=xCb3_0_km, xCb3_0_s=xCb3_0_s $
                  , xSc0_km=xSc0_km, xSc0_s=xSc0_s $
                  , xlsOut=xlsOut $
                  , debug=debug
    common dpdt_cmn

    dodebug = keyword_set(debug)
    nodebug = not keyword_set(debug)

    //////////////////////////////////
    // Input arguments:
    // - inpDelT   = Integration timestep
    // - lclVFb    = Flyby velocity
    // - xEll[2]   = Limits of integration result
    // - xCb3_0    = Initial CB3 X offset wrt nominal body at X=0
    // - xSc0      = Initial S/C X offset wrt nominal body at X=0

    inpDelT = n_elements(argDelT) eq 1L ? double(argDelT[0]) : 1d0

    lclVFb = double(argVFb[0])

    if n_elements(xEll_km) gt 0L then     xEll = double([xEll_km]) $
    else if n_elements(xEll_s) gt 0L then xEll = double([xEll_s]) * lclVFb $
    else                                  xEll = [150d0 * lclVFb]

    xEll = ([xEll[*],-xEll[*]])[0:1]  // Ensure two elements; use only first two
    mn = min(xEll,max=mx)
    xEll = [mn,mx]        // order them

    if n_elements(xCb3_0_km) gt 0L then     xCb3_0 = double(xCb3_0_km) $
    else if n_elements(xCb3_0_s) gt 0L then xCb3_0 = double(xCb3_0_s) * lclVFb $
    else                                    xCb3_0 = 0d0

    if n_elements(xSc0_km) gt 0L then     xSc0 = double(xSc0_km) $
    else if n_elements(xSc0_s) gt 0L then xSc0 = double(xSc0_s) * lclVFb $
    else                                  xSc0 = 0d0

    //////////////////////////////////
    // Adjust time base so that deltaX in dpdt()
    // is X offset from S/C to CB3

    t0 = xSc0 / lclVFb

    //////////////////////////////////
    // Prepare to start integration

    newP = double(xCb3_0)        // CB3 X offset wrt nominal body
    newT = double(t0)            // Time


    // - Load constants into dPdT & dxsd common blocks

    xxx = dpdt( initstruct={vFb:lclVFb, deltaY:argDeltaY, dThDtTDI:argDThDtTDI})
    xxx = deltaXSolved(initDeltaX0=xCb3_0 - xSc0)

    newOff = newT * lclVFb      // Offset:  motion due to flyby wrt t=0
                                // (newP - newOff) will be deltaX

    PsRK4 = [newP]
    PsFormula = PsRK4
    Ts = [newT]

    DPDTs = [dpdt(newT,newP)]

    fwdDelT = abs(inpDelT)
    bwdDelT = -fwdDelT

    //////////////////////////////////
    // debug output

    if dodebug then begin
      print, f='(2(a10,2a15))' $
           , 'newT(bwd)', 'newP(RK4,bwd)', 'newP(Form,bwd)' $
           , 'newT(fwd)', 'newP(RK4,fwd)', 'newP(Form,fwd)'

      print, f='(f10.1,2g15.7)' $
        , Ts[0], PsRK4[0], PsFormula[0]
    endif

    iBwd = 0L
    iFwd = 0L

    maxNotDone = max(PsRK4[[iBwd,iFwd]]) lt xEll[1]
    minNotDone = min(PsRK4[[iBwd,iFwd]]) gt xEll[0]

    while minNotDone or maxNotDone do begin

      doFwdMax = 0b
      doBwdMax = 0b
      doFwdMin = 0b
      doBwdMin = 0b

      if maxNotDone then begin
        doFwdMax = (PsRK4[iFwd] lt xEll[1]) and (DPDTs[iFwd] ge 0d0)
        doBwdMax = (PsRK4[iBwd] lt xEll[1]) and (DPDTs[iBwd] le 0d0) // delT<0
        if not (doFwdMax or doFwdMax) then begin
          doFwdMax = 1b
          doBwdMax = 1b
        endif
      endif

      if minNotDone then begin
        doFwdMin = (PsRK4[iFwd] gt xEll[0]) and (DPDTs[iFwd] le 0d0)
        doBwdMin = (PsRK4[iBwd] gt xEll[0]) and (DPDTs[iBwd] ge 0d0) // delT<0
        if not (doFwdMin or doBwdMin) then begin
          doFwdMin = 1b
          doBwdMin = 1b
        endif
      endif

      ////////////////////////////////
      // forward integration

      if doFwdMin or doFwdMax then begin
        newP = PsRK4[iFwd]
        newT = Ts[iFwd]
        delT = fwdDelT
        newDpDt = DPDTs[iFwd]

        newPRK4   = rk4([newP],newDpDt,[newT],delT,'dpdt',/double)

        newT = newT + delT
        newOff = newT * lclVFb

        newDeltaX = deltaXSolved(newT-t0)

        //////////////////////////////
        // - APpend new values:

        Ts        = [Ts, newT]
        PsRK4     = [PsRK4, newPRK4[0]]
        DPDTs     = [DPDTs, dpdt(newT, newPRK4)]
        PsFormula = [PsFormula, newDeltaX[0] + newOff]
      endif

      ////////////////////////////////
      // Backward integration

      if doBwdMin or doBwdMax then begin
        newP = PsRK4[iBwd]
        newT = Ts[iBwd]
        delT = bwdDelT
        newDpDt = DPDTs[iBwd]

        newPRK4   = rk4([newP],newDpDt,[newT],delT,'dpdt',/double)

        newT = newT + delT
        newOff = newT * lclVFb

        newDeltaX = deltaXSolved(newT-t0)

        //////////////////////////////
        // - PREpend new values:

        PsRK4     = [newPRK4[0], PsRK4]
        DPDTs     = [dpdt(newT, newPRK4), DPDTs]
        PsFormula = [newDeltaX[0] + newOff, PsFormula]
        Ts        = [newT, Ts]
      endif

      ////////////////////////////////
      // Adjust index to last element

      iFwd = n_elements(Ts) - 1L

      if dodebug then print, f='(2(f10.1,2g15.7))' $
        , Ts[iBwd], PsRK4[iBwd], PsFormula[iBwd] $
        , Ts[iFwd], PsRK4[iFwd], PsFormula[iFwd]

      if maxNotDone then maxNotDone = max(PsRK4[[iBwd,iFwd]]) lt xEll[1]
      if minNotDone then minNotDone = min(PsRK4[[iBwd,iFwd]]) gt xEll[0]

    endwhile // [while minNotDone or maxNotDone do begin]

    tMD = deltaY / vFb     // miss distance in equivalent seconds

    thetaNadirs = atan(-Ts / tMD)
    cosThetaNs = tMD / sqrt(tMD*tMD + Ts*Ts)
    thetaNadirDots = - (cosThetaNs^2) / tMD
    thetaNadirDotDots = 2 * Ts * (cosThetaNs^4) / (tMD^3)

    RangeNadirs = deltaY / cosThetaNs

    tCB3deltas = (PsRK4/vFb) - Ts
    thetaCB3s = atan(tCB3deltas / tMD)
    cosThetaCB3s = tMD / sqrt(tMD*tMD + tCB3deltas*tCB3deltas)
    thetaCB3Dots = dThDtTDI - (cosThetaCB3s^2) / tMD
    thetaCB3DotDots = (sin(2d0 * thetaCB3s) / tMD) * thetaCB3dots

    RangeCB3s = deltaY / cosThetaCB3s

    thetaMirrors = thetaCB3s - thetaNadirs
    thetaMirrorDots = thetaCB3Dots - thetaNadirDots
    thetaMirrorDotDots = thetaCB3DotDots - thetaNadirDotDots

    // Calculate numerical dThDtTDI
    vLen = n_elements(Ts)
    SCsVec = Ts * vFb

    thetasI = atan(deltaY, PsFormula[0:vLen-2]-SCsVec[1:*])
    thetasIplus1 = atan(deltaY, PsFormula[1:*]-SCsVec[1:*])
    dThDtTDIcalcFormula = [ dThDtTDI $
                          , (thetasI - thetasIplus1) / inpDelT $
                          ]

    thetasI = atan(deltaY, PsRK4[0:vLen-2]-SCsVec[1:*])
    thetasIplus1 = atan(deltaY, PsRK4[1:*]-SCsVec[1:*])
    dThDtTDIcalcRK4 = [ dThDtTDI $
                      , (thetasI - thetasIplus1) / inpDelT $
                      ]

    if n_elements(xlsOut) eq 1L then begin
      openw,lun,xlsOut,/get_lun
      pla,lun $
      , [ '<html' $
        , ' xmlns:o="urn:schemas-microsoft-com:office:office"' $
        , ' xmlns:x="urn:schemas-microsoft-com:office:excel"' $
        , ' xmlns="http://www.w3.org/TR/REC-html40"' $
        , '>' $
        , '<head>' $
        , '  <!--[if gte mso 9]>' $
        , '    <xml>' $
        , '    <x:ExcelWorkbook>' $
        , '    <x:ExcelWorksheets>' $
        , '    <x:ExcelWorksheet>' $
        , '    <x:Name>export</x:Name>' $
        , '    <x:WorksheetOptions>' $
        , '    <x:DisplayGridlines>' $
        , '    </x:DisplayGridlines>' $
        , '    </x:WorksheetOptions>' $
        , '    </x:ExcelWorksheet>' $
        , '    </x:ExcelWorksheets>' $
        , '    </x:ExcelWorkbook>' $
        , '    </xml>' $
        , '  <![endif]-->' $
        , '<meta http-equiv="content-type" content="text/plain; charset=UTF-8"/>' $
        , '</head><body><table><thead><tr><th>DPDTRUN.pro</th></tr></thead><tbody>' $
        ]

      pla,lun,gethdpair("Flyby Speed, km/s",vFb)
      pla,lun,gethdpair("Miss distance, km",deltaY)
      pla,lun,gethdpair("TMR, &mu;radian/s",dThDtTDI*1d6)
      pla,lun,gethdpair("S/C initial offset, km ",xSc0)
      pla,lun,gethdpair("CB3 initial offset, km ",xCb3_0)

      s = getth("Ellipse extents, km")
      s = gettd(xEll[0],pfx=s)
      pla,lun,gettr(gettd(xEll[1],pfx=s))

      pla,lun,gethdpair("Integration step, s ",inpDelT)

      pla,lun,gethdpair("Miss distance, s",deltaY/vFb)
      pla,lun,gethdpair("S/C initial offset, s ",t0)
      pla,lun,gethdpair("CB3 initial offset, s ",xCb3_0/vFb)

      s = getth("Ellipse extents, s")
      s = gettd(xEll[0]/vFb,pfx=s)
      pla,lun,gettr(gettd(xEll[1]/vFb,pfx=s))

      pla,lun,gettr(gettd(""))

      s = getth("T-TCA, s")
      s = getth("CB3-TCA,s",pfx=s)

      s = getth("T-TCA,km",pfx=s)
      s = getth("CB3-TCA,km",pfx=s)

      s = getth("ThetaNadir,deg",pfx=s)
      s = getth("ThetaNadir,radian",pfx=s)
      s = getth("ThetaNadirDot,&mu;radian/s",pfx=s)
      s = getth("ThetaNadirDotDot,&mu;radian/s**2",pfx=s)

      s = getth("RangeToNomTarg,km",pfx=s)

      s = getth("ThetaCB3,deg",pfx=s)
      s = getth("ThetaCB3,radian",pfx=s)
      s = getth("ThetaCB3Dot,&mu;radian/s",pfx=s)
      s = getth("ThetaCB3DotDot,&mu;radian/s**2",pfx=s)

      s = getth("RangeToTPWYL,km",pfx=s)

      s = getth("ThetaMirror,deg",pfx=s)
      s = getth("ThetaMirror,radian",pfx=s)
      s = getth("ThetaMirrorDot,&mu;radian/s",pfx=s)
      s = getth("ThetaMirrorDotDot,&mu;radian/s**2",pfx=s)
      pla,lun,gettr(s)

      dpr = 180d0/!dpi

      for i=0L,n_elements(Ts)-1L do begin

        s = gettd(Ts[i])
        s = gettd(PsRK4[i]/vFb,pfx=s)

        s = gettd(Ts[i]*vFb,pfx=s)
        s = gettd(PsRK4[i],pfx=s)

        s = gettd(ThetaNadirs[i]*dpr,pfx=s)
        s = gettd(ThetaNadirs[i],pfx=s)
        s = gettd(ThetaNadirDots[i]*1d6,pfx=s)
        s = gettd(ThetaNadirDotDots[i]*1d6,pfx=s)

        s = gettd(RangeNadirs[i],pfx=s)

        s = gettd(ThetaCB3s[i]*dpr,pfx=s)
        s = gettd(ThetaCB3s[i],pfx=s)
        s = gettd(ThetaCB3Dots[i]*1d6,pfx=s)
        s = gettd(ThetaCB3DotDots[i]*1d6,pfx=s)

        s = gettd(RangeCB3s[i],pfx=s)

        s = gettd(ThetaMirrors[i]*dpr,pfx=s)
        s = gettd(ThetaMirrors[i],pfx=s)
        s = gettd(ThetaMirrorDots[i]*1d6,pfx=s)
        s = gettd(ThetaMirrorDotDots[i]*1d6,pfx=s)
        pla,lun,gettr(s)

      endfor

      pla,lun, ["</tbody></table></body></html>"]

      free_lun,lun

    endif // n_elements(xlsOut) eq 1L then begin

    rtn = { Ts:Ts, PsRK4:PsRK4, PsFormula:PsFormula, DPDTs:DPDTs $
          , vFb:VFb, deltaY:deltaY, dThDtTDI:dThDtTDI $
          , xEll:xEll, inpDelT:inpDelT $
          , xSc0:xSc0, xCb3_0:xCb3_0 $
          , TminusTCA:t0 $
          , thetaNadirs:thetaNadirs $
          , thetaNadirDots:thetaNadirDots $
          , thetaNadirDotDots:thetaNadirDotDots $
          , rangeNadirs:rangeNadirs $
          , thetaCB3s:thetaCB3s $
          , thetaCB3Dots:thetaCB3Dots $
          , thetaCB3DotDots:thetaCB3DotDots $
          , rangeCB3s:rangeCB3s $
          , thetaMirrors:thetaMirrors $
          , thetaMirrorDots:thetaMirrorDots $
          , thetaMirrorDotDots:thetaMirrorDotDots $
          , dThDtTDIcalcFormula:dThDtTDIcalcFormula $
          , dThDtTDIcalcRK4:dThDtTDIcalcRK4 $
          }

    return, rtn
    end
