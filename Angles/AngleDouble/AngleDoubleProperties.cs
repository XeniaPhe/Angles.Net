using System;

namespace Angles
{
    public partial struct AngleDouble
    {
        public AngleUnit AngleUnit => unit;

        public double Angle => angle;

        public double Revolutions => angle / GetOneTurn();

        public double ZeroTo360_DegreesAngle => ConvertAngleTo(AngleUnit.Degrees, ConvertTo_Zero_To_OneTurn_Angle());

        public double Minus180To180_DegreesAngle => ConvertAngleTo(AngleUnit.Degrees, ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

        public double ZeroTo2PI_RadiansAngle => ConvertAngleTo(AngleUnit.Radians, ConvertTo_Zero_To_OneTurn_Angle());

        public double MinusPIToPI_RadiansAngle => ConvertAngleTo(AngleUnit.Radians, ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

        public double ZeroTo400_GradiansAngle => ConvertAngleTo(AngleUnit.Gradians, ConvertTo_Zero_To_OneTurn_Angle());

        public double Minus200To200_GradiansAngle => ConvertAngleTo(AngleUnit.Gradians, ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

        public double OpenInterval_DegreesAngle => ConvertAngleTo(AngleUnit.Degrees, angle);

        public double OpenInterval_RadiansAngle => ConvertAngleTo(AngleUnit.Radians, angle);

        public double OpenInterval_GradiansAngle => ConvertAngleTo(AngleUnit.Gradians, angle);

        public double ComplementaryAngle => GetQuarterTurn() - ConvertTo_Zero_To_OneTurn_Angle();

        public double SupplementaryAngle => GetHalfTurn() - ConvertTo_Zero_To_OneTurn_Angle();

        public double Sin => Math.Sin(ZeroTo2PI_RadiansAngle);

        public double Cos => Math.Cos(ZeroTo2PI_RadiansAngle);

        public double Tan => Math.Tan(ZeroTo2PI_RadiansAngle);

        public double Cot => 1.0 / Math.Tan(ZeroTo2PI_RadiansAngle);

        public double Sec => 1.0 / Math.Cos(ZeroTo2PI_RadiansAngle);

        public double Csc => 1.0 / Math.Sin(ZeroTo2PI_RadiansAngle);

        public double Sinh => Math.Sinh(ZeroTo2PI_RadiansAngle);

        public double Cosh => Math.Cosh(ZeroTo2PI_RadiansAngle);

        public double Tanh => Math.Tanh(ZeroTo2PI_RadiansAngle);

        public double Coth => 1.0 / Math.Tanh(ZeroTo2PI_RadiansAngle);

        public double Sech => 1.0 / Math.Cosh(ZeroTo2PI_RadiansAngle);

        public double Csch => 1.0 / Math.Sinh(ZeroTo2PI_RadiansAngle);

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
                double revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return revolutions > Epsilon && revolutions < 0.25 - Epsilon;
            }
        }

        public bool IsNormalizedAngleRightAngle
        {
            get
            {
                double revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return Math.Abs(revolutions - 0.25) <= Epsilon;
            }
        }

        public bool IsNormalizedAngleObtuseAngle
        {
            get
            {
                double revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return revolutions > 0.25 + Epsilon && revolutions < 0.5 - Epsilon;
            }
        }

        public bool IsNormalizedAngleStraightAngle
        {
            get
            {
                double revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return Math.Abs(revolutions - 0.5) <= Epsilon;
            }
        }

        public bool IsNormalizedAngleReflexAngle
        {
            get
            {
                double revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return revolutions > 0.5 + Epsilon && revolutions < 1.0 - Epsilon;
            }
        }

        public bool IsNormalizedAngleCompleteAngle
        {
            get
            {
                double revolutions = ConvertTo_Zero_To_OneTurn_Angle() / GetOneTurn();

                return Math.Abs(revolutions - 1.0) <= Epsilon;
            }
        }

        public double ReferenceAngle
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
                double angle = ConvertTo_Zero_To_OneTurn_Angle();
                double border = GetQuarterTurn();

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