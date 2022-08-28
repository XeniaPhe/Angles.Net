using System;

namespace Angles
{
    public partial struct AngleFloat : IAngle<AngleFloat, float>
    {
        internal float angle;
        internal AngleUnit unit;
        private const float Epsilon = 1.0e-4f;


        public const float Tau = 6.2831853f;
        public const float OneTurnInDegrees = 360.0f;
        public const float OneTurnInGradians = 400.0f;
        public const float PI = 3.1415927f;
        public const float HalfTurnInDegrees = 180.0f;
        public const float HalfTurnInGradians = 200.0f;
        public const float QuarterTurnInRadians = 1.5707963f;
        public const float QuarterTurnInDegrees = 90.0f;
        public const float QuarterTurnInGradians = 100.0f;

        public const float Rad2Deg = 57.2957795f;
        public const float Deg2Rad = 0.0174533f;
        public const float Grad2Deg = 0.9f;
        public const float Deg2Grad = 1.1111111f;
        public const float Grad2Rad = 0.0157080f;
        public const float Rad2Grad = 63.6619772f;

        public static readonly AngleFloat ZeroAngle = new AngleFloat(0f, AngleUnit.Radians);
        public static readonly AngleFloat RightAngle = new AngleFloat(QuarterTurnInRadians, AngleUnit.Radians);
        public static readonly AngleFloat StraightAngle = new AngleFloat(PI, AngleUnit.Radians);
        public static readonly AngleFloat CompleteAngle = new AngleFloat(Tau, AngleUnit.Radians);
        public static readonly AngleFloat OneDegree = new AngleFloat(1f, AngleUnit.Degrees);
        public static readonly AngleFloat OneRadian = new AngleFloat(1f, AngleUnit.Radians);
        public static readonly AngleFloat OneGradian = new AngleFloat(1f, AngleUnit.Gradians);


        /// <summary>
        /// Creates an AngleFloat object, the unit is radians by default
        /// </summary>
        /// <param name="angle">Angle value</param>
        /// <param name="unit">Unit of the angle (degrees, radians or gradians)</param>
        public AngleFloat(float angle, AngleUnit unit = AngleUnit.Radians)
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
            float division = (float)Math.Floor(angle / oneTurn);
            var result = (angle + division * oneTurn) % oneTurn;
            return result;
        }

        internal float ConvertTo_Zero_To_OneTurn_Angle(float angle)
        {
            float oneTurn = GetOneTurn();
            float division = (float)Math.Floor(angle / oneTurn);
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

        internal float ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(float angle)
        {
            float halfTurn = GetHalfTurn();

            if (angle > halfTurn)
                angle = (angle % halfTurn) - halfTurn;

            return angle;
        }

        internal float ConvertAngleTo(AngleUnit to, float angle)
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

        internal float ConvertAngleFrom(AngleUnit from, float angle)
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