using System;

namespace Angles
{
    public partial struct AngleDouble : IAngle<AngleDouble, double>
    {
        internal double angle;
        internal AngleUnit unit;
        private const double Epsilon = 1.0e-8f;

        public const double Tau = 6.2831853071795865;
        public const double OneTurnInDegrees = 360.0;
        public const double OneTurnInGradians = 400.0;
        public const double PI = 3.1415926535897932;
        public const double HalfTurnInDegrees = 180.0;
        public const double HalfTurnInGradians = 200.0;
        public const double QuarterTurnInRadians = 1.5707963267948966;
        public const double QuarterTurnInDegrees = 90.0;
        public const double QuarterTurnInGradians = 100.0;

        public const double Rad2Deg = 57.2957795130823209;
        public const double Deg2Rad = 0.0174532925199433;
        public const double Grad2Deg = 0.9;
        public const double Deg2Grad = 1.1111111111111111;
        public const double Grad2Rad = 0.0157079632679490;
        public const double Rad2Grad = 63.6619772367581343;

        public static readonly AngleDouble ZeroAngle = new AngleDouble(0.0, AngleUnit.Radians);
        public static readonly AngleDouble RightAngle = new AngleDouble(QuarterTurnInRadians, AngleUnit.Radians);
        public static readonly AngleDouble StraightAngle = new AngleDouble(PI, AngleUnit.Radians);
        public static readonly AngleDouble CompleteAngle = new AngleDouble(Tau, AngleUnit.Radians);
        public static readonly AngleDouble OneDegree = new AngleDouble(1.0, AngleUnit.Degrees);
        public static readonly AngleDouble OneRadian = new AngleDouble(1.0, AngleUnit.Radians);
        public static readonly AngleDouble OneGradian = new AngleDouble(1.0, AngleUnit.Gradians);


        /// <summary>
        /// Creates an AngleDouble object, the type is radians by default
        /// </summary>
        /// <param name="angle">Angle value</param>
        /// <param name="unit">Type of the angle (degrees, radians or gradians)</param>
        public AngleDouble(double angle, AngleUnit unit = AngleUnit.Radians)
        {
            this.angle = angle;
            this.unit = unit;
        }

        internal double GetOneTurn()
        {
            double oneTurn = Tau;

            switch (unit)
            {
                case AngleUnit.Degrees:
                    oneTurn = OneTurnInDegrees;
                    break;
                case AngleUnit.Gradians:
                    oneTurn = OneTurnInGradians;
                    break;
            }

            return oneTurn;
        }

        internal double GetHalfTurn()
        {
            double halfTurn = PI;

            switch (unit)
            {
                case AngleUnit.Degrees:
                    halfTurn = HalfTurnInDegrees;
                    break;
                case AngleUnit.Gradians:
                    halfTurn = HalfTurnInGradians;
                    break;
            }

            return halfTurn;
        }

        internal double GetQuarterTurn()
        {
            double quarterTurn = QuarterTurnInRadians;

            switch (unit)
            {
                case AngleUnit.Degrees:
                    quarterTurn = QuarterTurnInDegrees;
                    break;
                case AngleUnit.Gradians:
                    quarterTurn = QuarterTurnInGradians;
                    break;
            }

            return quarterTurn;
        }

        internal double ConvertTo_Zero_To_OneTurn_Angle()
        {
            double oneTurn = GetOneTurn();
            double division = (double)Math.Floor(angle / oneTurn);
            var result = (angle + division * oneTurn) % oneTurn;
            return result;
        }

        internal double ConvertTo_Zero_To_OneTurn_Angle(double angle)
        {
            double oneTurn = GetOneTurn();
            double division = (double)Math.Floor(angle / oneTurn);
            var result = (angle + division * oneTurn) % oneTurn;
            return result;
        }

        internal double ConvertTo_MinusHalfTurn_To_HalfTurn_Angle()
        {
            double halfTurn = GetHalfTurn();
            double result = angle;

            if (angle > halfTurn)
                result = (angle % halfTurn) - halfTurn;

            return result;
        }

        internal double ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(double angle)
        {
            double halfTurn = GetHalfTurn();

            if (angle > halfTurn)
                angle = (angle % halfTurn) - halfTurn;

            return angle;
        }

        internal double ConvertAngleTo(AngleUnit to, double angle)
        {
            if (unit == to)
                return angle;

            switch (to)
            {
                case AngleUnit.Degrees:
                    switch (unit)
                    {
                        case AngleUnit.Radians:
                            angle *= Rad2Deg;
                            break;
                        case AngleUnit.Gradians:
                            angle *= Grad2Deg;
                            break;
                    }
                    break;
                case AngleUnit.Radians:
                    switch (unit)
                    {
                        case AngleUnit.Degrees:
                            angle *= Deg2Rad;
                            break;
                        case AngleUnit.Gradians:
                            angle *= Grad2Rad;
                            break;
                    }
                    break;
                case AngleUnit.Gradians:
                    switch (unit)
                    {
                        case AngleUnit.Degrees:
                            angle *= Deg2Grad;
                            break;
                        case AngleUnit.Radians:
                            angle *= Rad2Grad;
                            break;
                    }
                    break;
            }

            return angle;
        }

        internal double ConvertAngleFrom(AngleUnit from, double angle)
        {
            if (from == unit)
                return angle;

            switch (from)
            {
                case AngleUnit.Degrees:
                    switch (unit)
                    {
                        case AngleUnit.Radians:
                            angle *= Deg2Rad;
                            break;
                        case AngleUnit.Gradians:
                            angle *= Deg2Grad;
                            break;
                    }
                    break;
                case AngleUnit.Radians:
                    switch (unit)
                    {
                        case AngleUnit.Degrees:
                            angle *= Rad2Deg;
                            break;
                        case AngleUnit.Gradians:
                            angle *= Rad2Grad;
                            break;
                    }
                    break;
                case AngleUnit.Gradians:
                    switch (unit)
                    {
                        case AngleUnit.Degrees:
                            angle *= Grad2Deg;
                            break;
                        case AngleUnit.Radians:
                            angle *= Grad2Rad;
                            break;
                    }
                    break;
            }

            return angle;
        }
    }
}