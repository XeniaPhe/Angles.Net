using System.Diagnostics.CodeAnalysis;

namespace Angles
{
    [Obsolete(message: "This struct ,since it relies on integers, is not reliable for angle representation, you should be careful while using it", error: false)]
    public partial struct AngleInt : IAngle<AngleInt, int>
    {
        internal int angle;
        internal AngleUnit unit;
        private const float Epsilonf = 1.0e-4f;
        private const double Epsilond = 1.0e-8f;


        public const float Tau = 6.2832f;
        public const float OneTurnInDegrees = 360.0f;
        public const float OneTurnInGradians = 400.0f;
        public const float PI = 3.1416f;
        public const float HalfTurnInDegrees = 180.0f;
        public const float HalfTurnInGradians = 200.0f;
        public const float QuarterTurnInRadians = 1.5708f;
        public const float QuarterTurnInDegrees = 90.0f;
        public const float QuarterTurnInGradians = 100.0f;

        public const float Rad2Deg = 57.2958f;
        public const float Deg2Rad = 0.0175f;
        public const float Grad2Deg = 0.9f;
        public const float Deg2Grad = 1.1111f;
        public const float Grad2Rad = 0.0157f;
        public const float Rad2Grad = 63.6620f;

        public static readonly AngleInt ZeroAngle = new AngleInt(0, AngleUnit.Radians);
        public static readonly AngleInt RightAngle = new AngleInt((int)QuarterTurnInRadians, AngleUnit.Radians);
        public static readonly AngleInt StraightAngle = new AngleInt((int)PI, AngleUnit.Radians);
        public static readonly AngleInt CompleteAngle = new AngleInt((int)Tau, AngleUnit.Radians);
        public static readonly AngleInt OneDegree = new AngleInt(1, AngleUnit.Degrees);
        public static readonly AngleInt OneRadian = new AngleInt(1, AngleUnit.Radians);
        public static readonly AngleInt OneGradian = new AngleInt(1, AngleUnit.Gradians);


        /// <summary>
        /// Creates an AngleInt object, the unit is radians by default
        /// </summary>
        /// <param name="angle">Angle value</param>
        /// <param name="unit">Type of the angle (degrees, radians or gradians)</param>
        public AngleInt(int angle, AngleUnit unit = AngleUnit.Radians)
        {
            this.angle = angle;
            this.unit = unit;
        }

        internal float GetOneTurn()
        {
            float oneTurn = Tau;

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

        internal float GetHalfTurn()
        {
            float halfTurn = PI;

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

        internal float GetQuarterTurn()
        {
            float quarterTurn = QuarterTurnInRadians;

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

        internal float ConvertTo_Zero_To_OneTurn_Angle()
        {
            float oneTurn = GetOneTurn();
            float division = (int)Math.Floor((double)angle / oneTurn);
            var result = (angle + division * oneTurn) % oneTurn;
            return result;
        }

        internal float ConvertTo_Zero_To_OneTurn_Angle(int angle)
        {
            float oneTurn = GetOneTurn();
            float division = (int)Math.Floor((double)angle / oneTurn);
            var result = (angle + division * oneTurn) % oneTurn;
            return result;
        }

        internal float ConvertTo_MinusHalfTurn_To_HalfTurn_Angle()
        {
            float halfTurn = GetHalfTurn();
            float result = angle;

            if (angle > halfTurn)
                result = (angle % halfTurn) - halfTurn;

            return result;
        }

        internal float ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(int angle)
        {
            float halfTurn = GetHalfTurn();
            float result = angle;

            if (angle > halfTurn)
                result = (angle % halfTurn) - halfTurn;

            return result;
        }

        internal int ConvertAngleTo(AngleUnit to, float angle)
        {
            if (unit == to)
                return (int)Math.Round(angle);

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

            return (int)Math.Round(angle);
        }

        internal int ConvertAngleFrom(AngleUnit from, float angle)
        {
            if (from == unit)
                return (int)Math.Round(angle);

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

            return (int)Math.Round(angle);
        }
    }
}