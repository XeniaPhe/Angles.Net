namespace Angles
{
    public partial struct AngleFloat
    {
        public AngleUnit AngleUnit => unit;

        public float Angle => angle;

        public float Revolutions => angle / GetOneTurn();

        public float ZeroTo360_DegreesAngle => ConvertAngleTo(AngleUnit.Degrees, ConvertTo_Zero_To_OneTurn_Angle());

        public float Minus180To180_DegreesAngle => ConvertAngleTo(AngleUnit.Degrees, ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

        public float ZeroTo2PI_RadiansAngle => ConvertAngleTo(AngleUnit.Radians, ConvertTo_Zero_To_OneTurn_Angle());

        public float MinusPIToPI_RadiansAngle => ConvertAngleTo(AngleUnit.Radians, ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

        public float ZeroTo400_GradiansAngle => ConvertAngleTo(AngleUnit.Gradians, ConvertTo_Zero_To_OneTurn_Angle());

        public float Minus200To200_GradiansAngle => ConvertAngleTo(AngleUnit.Gradians, ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

        public float OpenInterval_DegreesAngle => ConvertAngleTo(AngleUnit.Degrees, angle);

        public float OpenInterval_RadiansAngle => ConvertAngleTo(AngleUnit.Radians, angle);

        public float OpenInterval_GradiansAngle => ConvertAngleTo(AngleUnit.Gradians, angle);

        public float ComplementaryAngle => GetQuarterTurn() - ConvertTo_Zero_To_OneTurn_Angle();

        public float SupplementaryAngle => GetHalfTurn() - ConvertTo_Zero_To_OneTurn_Angle();

        public float Sin => (float)Math.Sin(MinusPIToPI_RadiansAngle);

        public float Cos => (float)Math.Cos(MinusPIToPI_RadiansAngle);

        public float Tan => (float)Math.Tan(MinusPIToPI_RadiansAngle);

        public float Cot => (float)(1.0 / Math.Tan(MinusPIToPI_RadiansAngle));

        public float Sec => (float)(1.0 / Math.Cos(MinusPIToPI_RadiansAngle));

        public float Csc => (float)(1.0 / Math.Sin(MinusPIToPI_RadiansAngle));

        public float Sinh => (float)Math.Sinh(MinusPIToPI_RadiansAngle);

        public float Cosh => (float)Math.Cosh(MinusPIToPI_RadiansAngle);

        public float Tanh => (float)Math.Tanh(MinusPIToPI_RadiansAngle);

        public float Coth => (float)(1.0 / Math.Tanh(MinusPIToPI_RadiansAngle));

        public float Sech => (float)(1.0 / Math.Cosh(MinusPIToPI_RadiansAngle));

        public float Csch => (float)(1.0 / Math.Sinh(MinusPIToPI_RadiansAngle));

        public bool IsPositiveAngle => this > ZeroAngle;

        public bool IsNegativeAngle => this < ZeroAngle;

        public bool IsZeroAngle => this == ZeroAngle;

        public bool IsAcuteAngle => this > ZeroAngle && this < RightAngle;

        public bool IsRightAngle => this == RightAngle;

        public bool IsObtuseAngle => this > RightAngle && this < StraightAngle;

        public bool IsStraightAngle => this == StraightAngle;

        public bool IsReflexAngle => this > StraightAngle && this < CompleteAngle;

        public bool IsCompleteAngle => this == CompleteAngle;

        public bool IsNormalizedAngleAcuteAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return revolutions > Epsilon && revolutions < 0.25f - Epsilon;
            }
        }

        public bool IsNormalizedAngleRightAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return Math.Abs(revolutions - 0.25f) <= Epsilon;
            }
        }

        public bool IsNormalizedAngleObtuseAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return revolutions > 0.25f + Epsilon && revolutions < 0.5f - Epsilon;
            }
        }

        public bool IsNormalizedAngleStraightAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return Math.Abs(revolutions - 0.5f) <= Epsilon;
            }
        }

        public bool IsNormalizedAngleReflexAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return revolutions > 0.5f + Epsilon && revolutions < 1f - Epsilon;
            }
        }

        public bool IsNormalizedAngleCompleteAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return Math.Abs(revolutions - 1f) <= Epsilon;
            }
        }

        public float ReferenceAngle
        {
            get => Quadrant switch
            {
                1 => ConvertTo_Zero_To_OneTurn_Angle(),
                2 => GetHalfTurn() - ConvertTo_Zero_To_OneTurn_Angle(),
                3 => ConvertTo_Zero_To_OneTurn_Angle() - GetHalfTurn(),
                _ => GetOneTurn() - ConvertTo_Zero_To_OneTurn_Angle(),
            };
        }

        public int Quadrant
        {
            get
            {
                float angle = ConvertTo_Zero_To_OneTurn_Angle();
                float border = GetQuarterTurn();

                for (int i = 1; i < 3; i++)
                {
                    if (angle <= border)
                        return i;

                    border += border;
                }

                if (angle <= border)
                    return 4;

                return 3;
            }
        }
    }
}