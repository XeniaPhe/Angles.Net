using System;

namespace Angles
{
    public partial struct AngleInt
    {
        public AngleUnit AngleUnit => unit;

        public int Angle => angle;

        public int Revolutions => (int)Math.Round(angle / GetOneTurn());

        public int ZeroTo360_DegreesAngle => ConvertAngleTo(AngleUnit.Degrees, ConvertTo_Zero_To_OneTurn_Angle());

        public int Minus180To180_DegreesAngle => ConvertAngleTo(AngleUnit.Degrees, ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

        public int ZeroTo2PI_RadiansAngle => ConvertAngleTo(AngleUnit.Radians, ConvertTo_Zero_To_OneTurn_Angle());

        public int MinusPIToPI_RadiansAngle => ConvertAngleTo(AngleUnit.Radians, ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

        public int ZeroTo400_GradiansAngle => ConvertAngleTo(AngleUnit.Gradians, ConvertTo_Zero_To_OneTurn_Angle());

        public int Minus200To200_GradiansAngle => ConvertAngleTo(AngleUnit.Gradians, ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

        public int OpenInterval_DegreesAngle => ConvertAngleTo(AngleUnit.Degrees, angle);

        public int OpenInterval_RadiansAngle => ConvertAngleTo(AngleUnit.Radians, angle);

        public int OpenInterval_GradiansAngle => ConvertAngleTo(AngleUnit.Gradians, angle);

        public int ComplementaryAngle => (int)Math.Round(GetQuarterTurn() - ConvertTo_Zero_To_OneTurn_Angle());

        public int SupplementaryAngle => (int)Math.Round(GetHalfTurn() - ConvertTo_Zero_To_OneTurn_Angle());

        public int Sin => (int)Math.Round(Math.Sin(MinusPIToPI_RadiansAngle));

        public int Cos => (int)Math.Round(Math.Cos(MinusPIToPI_RadiansAngle));

        public int Tan => (int)Math.Round(Math.Tan(MinusPIToPI_RadiansAngle));

        public int Cot => (int)Math.Round(1.0 / Math.Tan(MinusPIToPI_RadiansAngle));

        public int Sec => (int)Math.Round(1.0 / Math.Cos(MinusPIToPI_RadiansAngle));

        public int Csc => (int)Math.Round(1.0 / Math.Sin(MinusPIToPI_RadiansAngle));

        public int Sinh => (int)Math.Round(Math.Sinh(MinusPIToPI_RadiansAngle));

        public int Cosh => (int)Math.Round(Math.Cosh(MinusPIToPI_RadiansAngle));

        public int Tanh => (int)Math.Round(Math.Tanh(MinusPIToPI_RadiansAngle));

        public int Coth => (int)Math.Round(1.0 / Math.Tanh(MinusPIToPI_RadiansAngle));

        public int Sech => (int)Math.Round(1.0 / Math.Cosh(MinusPIToPI_RadiansAngle));

        public int Csch => (int)Math.Round(1.0 / Math.Sinh(MinusPIToPI_RadiansAngle));

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

                return revolutions > Epsilonf && revolutions < 0.25f - Epsilonf;
            }
        }

        public bool IsNormalizedAngleRightAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return Math.Abs(revolutions - 0.25f) <= Epsilonf;
            }
        }

        public bool IsNormalizedAngleObtuseAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return revolutions > 0.25f + Epsilonf && revolutions < 0.5f - Epsilonf;
            }
        }

        public bool IsNormalizedAngleStraightAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return Math.Abs(revolutions - 0.5f) <= Epsilonf;
            }
        }

        public bool IsNormalizedAngleReflexAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return revolutions > 0.5f + Epsilonf && revolutions < 1f - Epsilonf;
            }
        }

        public bool IsNormalizedAngleCompleteAngle
        {
            get
            {
                float revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return Math.Abs(revolutions - 1f) <= Epsilonf;
            }
        }

        public int ReferenceAngle
        {
            get => (int)Math.Round(Quadrant switch
            {
                1 => ConvertTo_Zero_To_OneTurn_Angle(),
                2 => GetHalfTurn() - ConvertTo_Zero_To_OneTurn_Angle(),
                3 => ConvertTo_Zero_To_OneTurn_Angle() - GetHalfTurn(),
                _ => GetOneTurn() - ConvertTo_Zero_To_OneTurn_Angle(),
            });
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