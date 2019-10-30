    /*//////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////

    Background
    ==========

    A spacecraft (S/C e.g. New Horizons) is flying on a linear
    trajectory past a target (e.g. Pluto), with a 99%+ probability that
    the target is inside a volume shaped like a cigar with its long axis
    parallel to the flyby velocity vector.  The observation scans an
    instrument across the target, which instrument has a Field Of View
    (FOV) far greater than the smaller axes of the cigar.  So the target
    will be visible in the instrument FOV at some point as long as the
    instrument boresight is scanned along that long axis during the
    observation.

    However, there is a much more stringent requirement determining
    exactly *how* the boresight moves along that axis.  Specifically,
    the instrument boresight must be scanned along the long axis of the
    cigar such that, when the boresight passes over the target, the
    angular rate of the target with respect to the instrument frame is a
    precise fixed value.  That value is typically set, via a S/C command
    sequence, as the scan rate of a Time Delay Integration (TDI) CCD.


    DPDTRUN purpose
    ===============

    For a given flyby of a nominal body position Pnom, calculate the
    ephemeris of a pseudo-body (CB3 a.k.a. P) along-track wrt Pnom,
    such that if any S/C instrument points its boresight at CB3 through-
    out the flyby, the scan rate (radian/second) of the actual body, at
    an unknown position but assumed to be fixed somewhere along-track
    wrt Pnom, across that boresight will remain at the constant
    sequenced value.


                                             |          |         |
                                         --->|deltaX(t) |<---     |
                                             |          |         |
                                             |      --->|  P(t)   |<---
                                             |          |         |
                                             |          |         |
      ---------------------------------------|----------CB3-------Pnom
        ^           +Y                       |         /     -X<--|-->+X
        |           ^                        |        /          X=0
        |           |                        |       /
        |           |                        |      /<=Boresight line,
        |           | Inertial               |     /    pointing from
      deltaY        | Reference              |    /      S/C toward CB3
        |           | Frame                  |   /
        |          -+----------->+X        ->|  /<-Theta, positive
        |           |                        | /    wrt +Y toward +X
        V                                    |/
      ---------------------------------------Sc(t)====>-----------+--
                                                     ^            |
                                                     |           X=0
                                                     |
                          Flyby velocity vector, V --+  ||V|| = vFb

    Jargon
    ------

      <--uptrack,              <--along-track-->           downtrack,-->
       -X, opposite             parallel to S/C            +X, with S/C
       to S/C velocity           S/C velocity              velocity


    * TCA => Time of Closest Approach, of spacecraft to Pnom

    Input parameters (constants)
    ----------------------------

    dThDtTDI  TMR*, sequenced scan rate of target wrt boresight, rad/s**
    deltaY    Flyby (Fb) distance, km
    vFb       Speed of flyby, km/s, should be non-negative
    DelT      Integration timestep, s

    * TMR:  Target Motion Rate
    ** A positive value for dThDtTDI has CB3 moving downtrack wrt Pnom


    Initial conditions
    ------------------

    xEll_km     Extent of along-track to be covered wrt Pnom, km
                - If one value specified:  -|xEll_km| to +|xEll_km|
                - If two values specified:  min(xEll_km) to max(xEll_km)
                   - positive implies +X i.e. downtrack
                - This procedure integrates the CB3 position between
                  these two values at a minimum


    xEll_s      IFF xEll_km not specified, extent of along-track covered
                wrt nominal target, s past CA (t - TCA) at vFb
                - default: 150s
                - same scheme as xEll_km for one or two values
                  - positive implies +X i.e. downtrack

    xCb3_0_km   Initial CB3 position wrt nominal target, km
                - positive implies +X => downtrack
    xCb3_0_s    IFF xCb3_0_km not specified, initial CB3 position
                wrt nominal target, s past CA (CB3t0 - TCA) at vFb
                - default:  0s
                - positive implies +X => downtrack

    xSc0_km     Initial S/C position wrt nominal target, km
                - positive implies +X => downtrack
    xSc0_s      IFF xSc0_km not specified, initial S/C position
                wrt nominal target, s past CA (SCt0 - TCA) at vFb
                - default:  0s
                - positive implies +X => downtrack


    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    FUNCTION dydx
    =============

    Derivative function to support DPDTRUN:  used to calculate dy/dx
    (derivative) for fourth-order Runge-Kutta solution; see derivation below.

    Arguments
    ---------

    t   Time at which to calculate derivative (t=0 is start of integration)
    P   CB3(t), current value of P
    ////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////*/

    public double dpdt(double t, double P) {
        deltaX = P - (vFb * t);
        return dThDtTDI * (deltaY  + (deltaX * deltaX / deltaY));
    }

    /*//////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    Derivation of dPdT function
    ===========================

    Refer to the Background and diagram above.

    The instantaneous angular (scan) rate of a target across such a S/C
    instrument's boresight, with said target fixed at position
    [Pnom + CB3(t)] at any time t, is

      dThDtTDI = dThDt + dThDtFb   (radian/second; rad/s)           [1]

    where

      Pnom     = Nominal target position = inertial frame origin, constant
      CB3(t)   = Time-dependent pseudo-body* offset from Pnom along X, km
      dThDtTDI = Desired (sequenced) scan rate, constant, converted to rad/s
      Theta(t) = Boresight angle wrt inertial +Y, positive toward +X, radian
      dThDt    = dTheta / dt, inertial angular rate of Theta(t), rad/s
      dThDtFb  = Instantaneous angular rotation rate of a line from [the
                   fixed target at CB3(t)] to [the spacecraft] due to
                   S/C-target relative translational motion, radian/second

    * The to-be-solved-for pseudo-body position model, CB3(t), does not
      represent a real target; it is instead a synthetic trajectory loaded
      into the S/C GN&C** subsystem, and to which GN&C will point the
      instrument boresight during the observation scan.  The CB3(t) pseudo-
      body trajectory will at some point during the scan pass through the
      the real target position, which position is at an unknown but fixed
      offset from Pnom.  The goal of this exercise is to solve for (derive)
      that CB3(t) trajectory model.

    ** Guidance, Navigation and Control

    Since Theta(t) is by definition the instantaneous angle of the
    boresight pointing at any actual fixed target at CB3(t) from S/C(t),
    the scan rate contribution of that fixed target across the boresight
    due to relative translational motion is the ratio of [the motion of
    the fixed target perpendicular to the boresight] to [the range
    between the S/C and the fixed target]:

                vFb * cos(Theta)                 2
     dThDtFb = ---------------------- = vFb * cos (Theta) / deltaY   [2]
               deltaY / cos(Theta)


    Substituting into [1] and solving for dThDt,

                                   2
     dThDt = dThDtTDI  -  vFb * cos (Theta) / deltaY                 [3]

    The distance along the flyby direction (+X) between the spacecraft
    and the target can be derived from two formulae:

     deltaX = P(t)  -  vFb * t                                       [4]
     deltaX = deltaY * tan(Theta)                                    [5]

    where t is time and is zero at TCA to Pnom.  Setting [4] equal to [5]
    and solving for P(t) yields

     P(t) = deltaY * tan(Theta)  +  vFb * t                          [6]


    Solving for dP/dt yields

                        2
     dP/dt = (deltaY/cos (Theta)) * dTh/dt  +  vFb                   [7]


    Substituting [3] for dTh/dt into [7]:

                                                    2
               deltaY        /             vFb * cos (Theta) \
     dP/dt = -----------  * ( dThDtTDI  -  -----------------  )  +  vFb
                2            \                   deltaY      /
             cos (Theta)

                                    2
     dP/dt = deltaY * dThDtTDI / cos (Theta)  -  vFb  +  vFb

                                    2
     dP/dt = deltaY * dThDtTDI / cos (Theta)                         [8]


    Substituting the trigonomtric identity

        2                    2          2         2
     cos (Theta(t)) =  deltaY  / (deltaY  + deltaX  )


    yields

                                       2         2
                                 deltaY  + deltaX
     dP/dt = deltaY * dThDtTDI * -------------------
                                            2
                                      deltaY


    and, after rearranging,

                                            2
                         /            deltaX  \
     dP/dt = dThDtTDI * (  deltaY  +  ------   )                     [9]
                         \            deltaY  /


    Finally, substituting equation [4] for deltaX yields the equation
    [10], which is used in method dpdt above as part of the 4th-order
    Runge-Kutta solution:

                                                    2
                         /          (P(t) - vFb * t)  \
     dP/dt = dThDtTDI * (  deltaY + -----------------  )            [10]
                         \               deltaY       /

    ////////////////////////////////////////////////////////////////////////
    Final note:
    When the range to the target is large and/or the flyby distance
    (deltaY) is large compared to the distance the S/C moves during the
    scan, dThDtFb is essentially constant, and this derivation is not
    relevant.
    ////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////*/


    /*//////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////

    Analytical solution (developed after the RK4 solution)
    ======================================================

                                  2
     dThDt = dThDtTDI -  vFb * cos (Theta) / deltaY                  [3]

    Substituting

     b^2   = vFb / (dThDtTDI * deltaY)

      - see Note 1 below for case where this quantity is negative

    yields

           dTheta
     --------------------- = dThDtTDI * dt   [11]
                  2
     1 - b^2 * cos (Theta)
                                                            2
    N.B. for b^2=1, the left side of [11] becomes dTheta/sin (Theta)

    Substituting

     broot = SQRT(b^2 - 1)     if b^2 > 1

     broot = SQRT(1 - b^2)     if b^2 < 1

    and integrating both sides of [11] (see Notes 1) depending on the
    value of b^2:

                   1        / tan(Theta) - broot \
     b^2 > 1:  --------- ln( ------------------   ) = dThDtTDI * t + C  [12a]
               2 * broot    \ tan(Theta) + broot /
                                                      (See also Note 2 below)


                 1      -1 / tan(Theta) \
     b^2 < 1:  ----- tan  (  ----------  )          = dThDtTDI * t + C  [12b]
               broot       \   broot    /


     b^2 = 1:  - cot(Theta)  =  - 1 / tan(Theta)    = dThDtTDI * t + C  [12c]


    where C is the constant of integration and may be evaluated at t = zero
    as the left hand sides of [12*]; any other time tReal may be converted
    to 't' by means of a constant offset (t = tReal - tReal0), and Theta(t=0)
    defined as ThetaReal(tReal=tReal0), the initial condition for the ODE.

    Note 1:  Integrals 376, 375, & 308  in section A of "CRC Handbook of
             Chemistry and Physics," Weast, Robert C. (ed), 56th edition,
             CRC Press, pp. A-136, A-138, 1974.  The first form of integral
             376 and the is essentially identical to 375 where 375 covers the
             case where dThDtTDI is negative.

    Note 2:  In equation [12a], it is possible that broot is greater
             than tan(Theta), which results in a negative numerator
             and a negative value passed to the natural logarithm
             function.  In that case this approach fails, because the
             constant of integration cannot be calculated.


    Substituting

     deltaX/deltaY = tan(Theta)

     T             = dThDtTDI * t + C

    into [12*] and solving for deltaX:


                       deltaY * broot * ( exp(2*broot*T) + 1 )
    b^2 > 1:  deltaX = ---------------------------------------       [13a]
                            1 + exp(2*broot*T)

    b^2 < 1:  deltaX = deltaY * broot * tan(broot*T) + 1 )           [13b]

    b^2 < 1:  deltaX = - deltaY / T                                  [13c]

    ////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////*/
