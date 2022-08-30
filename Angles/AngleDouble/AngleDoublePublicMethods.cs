using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Angles
{
    public partial struct AngleDouble
    {
        #region Interface Implementations

        /// <summary>
        /// Calls one of the other CompareTo methods if the parameter is of the type of one of them
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>int</returns>
        public int CompareTo([NotNullWhen(true)] object? obj)
        {
            if (obj is null)
                return Int32.MaxValue;

            Type type;

            if ((type = obj.GetType()) == typeof(AngleFloat))
                return CompareTo((AngleFloat)obj);
            else if (type == typeof(AngleDouble))
                return CompareTo((AngleDouble)obj);
            else if (type == typeof(AngleInt))
                return CompareTo((AngleInt)obj);

            return Int32.MaxValue;
        }

        /// <summary>
        /// Compares this angle with another AngleDouble, returns -1 if this is smaller, 1 if this is bigger and 0 if they are equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareTo(AngleDouble other)
        {
            if (this < other)
                return -1;
            else if (this > other)
                return 1;

            return 0;
        }

        /// <summary>
        /// Compares this angle with an AngleFloat, returns -1 if this is smaller, 1 if this is bigger and 0 if they are equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareTo(AngleFloat other)
        {
            if (this < other)
                return -1;
            else if (this > other)
                return 1;

            return 0;
        }

        /// <summary>
        /// Compares this angle with an AngleInt, returns -1 if this is smaller, 1 if this is bigger and 0 if they are equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareTo(AngleInt other)
        {
            if (this < other)
                return -1;
            else if (this > other)
                return 1;

            return 0;
        }

        /// <summary>
        /// As opposed to comparison operators and CompareTo methods, this Equals method checks the equality in all of type (AngleDouble, AngleFloat or AngleInt),
        /// the angle unit(degrees, radians or gradians) and magnitude of the angle
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() != typeof(AngleDouble))
                return false;

            AngleDouble other = (AngleDouble)obj;

            if (unit != other.unit)
                return false;
            if (angle != other.angle)
                return false;

            return true;
        }

        /// <summary>
        /// As opposed to comparison operators and CompareTo methods, this Equals method checks the equality in both 
        /// the angle unit(degrees, radians or gradians) and magnitude of the angle
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool Equals(AngleDouble other)
        {
            if (unit != other.unit)
                return false;
            if (angle != other.angle)
                return false;

            return true;
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            StringBuilder builder = new StringBuilder(angle.ToString(format, formatProvider));
            builder.Append(' ');
            builder.Append(unit.ToString());
            builder.Append(" (AngleDouble)");

            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(angle.ToString());
            builder.Append(' ');
            builder.Append(unit.ToString());
            builder.Append(" (AngleDouble)");

            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return angle.GetHashCode() * 5 + unit.GetHashCode() * 7;
        }

        #endregion

        #region Static Methods

        public static double DeltaAngle(AngleDouble lhs, AngleDouble rhs, AngleUnit unit = AngleUnit.Radians)
        {
            lhs.ConvertTo(unit);
            rhs.ConvertTo(unit);

            double delta = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - rhs.ConvertTo_Zero_To_OneTurn_Angle());

            if (delta > lhs.GetHalfTurn() + Epsilon)
                delta = lhs.GetOneTurn() - delta;

            return delta;
        }

        public static double DeltaAngle(AngleDouble lhs, AngleFloat rhs, AngleUnit unit = AngleUnit.Radians)
        {
            lhs.ConvertTo(unit);
            rhs.ConvertTo(unit);

            double delta = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - rhs.ConvertTo_Zero_To_OneTurn_Angle());

            if (delta > lhs.GetHalfTurn() + Epsilon)
                delta = lhs.GetOneTurn() - delta;

            return delta;
        }

        public static double DeltaAngle(AngleDouble lhs, AngleInt rhs, AngleUnit unit = AngleUnit.Radians)
        {
            lhs.ConvertTo(unit);
            rhs.ConvertTo(unit);

            double delta = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - rhs.ConvertTo_Zero_To_OneTurn_Angle());

            if (delta > lhs.GetHalfTurn() + Epsilon)
                delta = lhs.GetOneTurn() - delta;

            return delta;
        }

        public static bool AreParallel(AngleDouble lhs, AngleDouble rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            double difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));

            return (difference <= Epsilon || Math.Abs(difference - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool AreParallel(AngleDouble lhs, AngleFloat rhs)
        {
            double rhsAngle = (float)rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            double difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));

            return (difference <= Epsilon || Math.Abs(difference - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool AreParallel(AngleDouble lhs, AngleInt rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            double difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));

            return (difference <= Epsilon || Math.Abs(difference - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool ArePerpendicular(AngleDouble lhs, AngleDouble rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            double difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));
            double temp = difference - lhs.GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool ArePerpendicular(AngleDouble lhs, AngleFloat rhs)
        {
            double rhsAngle = (float)rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            double difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));
            double temp = difference - lhs.GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool ArePerpendicular(AngleDouble lhs, AngleInt rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            double difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));
            double temp = difference - lhs.GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool AreComplementary(AngleDouble lhs, AngleDouble rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetQuarterTurn()) <= Epsilon;
        }

        public static bool AreComplementary(AngleDouble lhs, AngleFloat rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetQuarterTurn()) <= Epsilon;
        }

        public static bool AreComplementary(AngleDouble lhs, AngleInt rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetQuarterTurn()) <= Epsilon;
        }

        public static bool AreSupplementary(AngleDouble lhs, AngleDouble rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetHalfTurn()) <= Epsilon;
        }

        public static bool AreSupplementary(AngleDouble lhs, AngleFloat rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetHalfTurn()) <= Epsilon;
        }

        public static bool AreSupplementary(AngleDouble lhs, AngleInt rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetHalfTurn()) <= Epsilon;
        }

        public static bool AreCoterminal(AngleDouble lhs, AngleDouble rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle)) <= Epsilon;
        }

        public static bool AreCoterminal(AngleDouble lhs, AngleFloat rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle)) <= Epsilon;
        }

        public static bool AreCoterminal(AngleDouble lhs, AngleInt rhs)
        {
            double rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle)) <= Epsilon;
        }

        public static AngleDouble Max(params AngleDouble[] angles)
        {
            int maxIndex = 0;
            double revolutions = angles[0].Revolutions;
            double temp;

            for (int i = 1; i < angles.Length; i++)
            {
                if ((temp = angles[i].Revolutions) > revolutions)
                {
                    maxIndex = i;
                    revolutions = temp;
                }
            }

            return angles[maxIndex];
        }

        public static AngleDouble Min(params AngleDouble[] angles)
        {
            int minIndex = 0;
            double revolutions = angles[0].Revolutions;
            double temp;

            for (int i = 1; i < angles.Length; i++)
            {
                if ((temp = angles[i].Revolutions) < revolutions)
                {
                    minIndex = i;
                    revolutions = temp;
                }
            }

            return angles[minIndex];
        }

        public static AngleDouble MaxMagnitude(params AngleDouble[] angles)
        {
            int maxIndex = 0;
            double revolutions = Math.Abs(angles[0].Revolutions);
            double temp;

            for (int i = 1; i < angles.Length; i++)
            {
                if ((temp = Math.Abs(angles[i].Revolutions)) > revolutions)
                {
                    maxIndex = i;
                    revolutions = temp;
                }
            }

            return angles[maxIndex];
        }

        public static AngleDouble MinMagnitude(params AngleDouble[] angles)
        {
            int minIndex = 0;
            double revolutions = Math.Abs(angles[0].Revolutions);
            double temp;

            for (int i = 1; i < angles.Length; i++)
            {
                if ((temp = Math.Abs(angles[i].Revolutions)) < revolutions)
                {
                    minIndex = i;
                    revolutions = temp;
                }
            }

            return angles[minIndex];
        }

        public static AngleDouble Atan(double tan, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Atan(tan)).ConvertTo(unit);
        }

        public static AngleDouble Atan2(float y, float x, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Atan2(y, x)).ConvertTo(unit);
        }

        public static AngleDouble Atanh(float tanh, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Atanh(tanh)).ConvertTo(unit);
        }

        public static AngleDouble Acot(float cot, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Atan(1f / cot)).ConvertTo(unit);
        }

        public static AngleDouble Acot2(float y, float x, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Atan2(x, y)).ConvertTo(unit);
        }

        public static AngleDouble Acoth(float coth, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Tanh(1f / coth)).ConvertTo(unit);
        }

        public static AngleDouble Asin(float sin, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Asin(sin)).ConvertTo(unit);
        }

        public static AngleDouble Asinh(float sinh, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Asinh(sinh)).ConvertTo(unit);
        }

        public static AngleDouble Acos(float cos, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Acos(cos)).ConvertTo(unit);
        }

        public static AngleDouble Acosh(float cosh, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Acosh(cosh)).ConvertTo(unit);
        }

        public static AngleDouble Asec(float sec, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Acos(1f / sec)).ConvertTo(unit);
        }

        public static AngleDouble Asech(float sech, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Acosh(1f / sech)).ConvertTo(unit);
        }

        public static AngleDouble Acsc(float csc, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Asin(1f / csc)).ConvertTo(unit);
        }

        public static AngleDouble Acsch(float csch, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleDouble(Math.Asinh(1f / csch)).ConvertTo(unit);
        }

        #endregion

        #region Non-static Methods

        public AngleDouble SetAngle(double angle, AngleUnit? unit = null)
        {
            this.angle = angle;
            this.unit = unit.HasValue ? unit.Value : this.unit;
            return this;
        }

        public AngleDouble Increment(AngleDouble angle)
        {
            this.angle += angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleDouble Increment(AngleFloat angle)
        {
            this.angle += angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleDouble Increment(AngleInt angle)
        {
            this.angle += angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleDouble Increment(double angle)
        {
            this.angle += angle;
            return this;
        }

        public AngleDouble Increment(double angle, AngleUnit unit)
        {
            angle = ConvertAngleFrom(unit, angle);
            this.angle += angle;
            return this;
        }

        public AngleDouble Decrement(AngleDouble angle)
        {
            this.angle -= angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleDouble Decrement(AngleFloat angle)
        {
            this.angle -= angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleDouble Decrement(AngleInt angle)
        {
            this.angle -= angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleDouble Decrement(double angle)
        {
            this.angle -= angle;
            return this;
        }

        public AngleDouble Decrement(double angle, AngleUnit unit)
        {
            angle = ConvertAngleFrom(unit, angle);
            this.angle -= angle;
            return this;
        }

        public AngleDouble ConvertToRadians()
        {
            angle = ConvertAngleTo(AngleUnit.Radians, angle);
            unit = AngleUnit.Radians;
            return this;
        }

        public AngleDouble ConvertToDegrees()
        {
            angle = ConvertAngleTo(AngleUnit.Degrees, angle);
            unit = AngleUnit.Degrees;
            return this;
        }

        public AngleDouble ConvertToGradians()
        {
            angle = ConvertAngleTo(AngleUnit.Gradians, angle);
            unit = AngleUnit.Gradians;
            return this;
        }

        public AngleDouble ConvertTo(AngleUnit unit)
        {
            angle = ConvertAngleTo(unit, angle);
            this.unit = unit;
            return this;
        }

        public AngleDouble NormalizeTo_Zero_To_OneTurn()
        {
            angle = ConvertTo_Zero_To_OneTurn_Angle();
            return this;
        }

        public AngleDouble NormalizeTo_MinusHalfTurn_To_HalfTurn()
        {
            angle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle();
            return this;
        }

        public AngleDouble NormalizeTo(AngleType type)
        {
            switch (type)
            {
                case AngleType.Zero_To_OneTurn:
                    angle = ConvertTo_Zero_To_OneTurn_Angle();
                    break;
                case AngleType.MinusHalfTurn_To_Halfturn:
                    angle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle();
                    break;
            }

            return this;
        }

        /// <summary>
        /// Converts the angle to AngleFloat and returns it
        /// </summary>
        /// <returns>AngleFloat</returns>
        public AngleFloat ToAngleFloat()
        {
            double angle = this.angle;

            if (angle > float.MaxValue)
            {
                double oneTurn = GetOneTurn();
                double extraTurns = (angle - float.MaxValue) / oneTurn;
                angle -= Math.Ceiling(extraTurns) * oneTurn;
            }

            return new AngleFloat((float)Math.Round(angle), unit);
        }

        /// <summary>
        /// Converts the angle to AngleInt and returns it
        /// </summary>
        /// <returns>AngleInt</returns>
        public AngleInt ToAngleInt()
        {
            double angle = this.angle;

            if (angle > Int32.MaxValue)
            {
                double oneTurn = GetOneTurn();
                double extraTurns = (angle - Int32.MaxValue) / oneTurn;
                angle -= Math.Ceiling(extraTurns) * oneTurn;
            }

            return new AngleInt((int)Math.Round(angle), unit);
        }

        public AngleDouble GetDeltaAngle(AngleDouble other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            double delta = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            AngleDouble deltaAngle = new AngleDouble(delta, unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public AngleDouble GetDeltaAngle(AngleFloat other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            double delta = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            AngleDouble deltaAngle = new AngleDouble(delta, unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public AngleDouble GetDeltaAngle(AngleInt other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            double delta = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            AngleDouble deltaAngle = new AngleDouble(delta, unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public AngleDouble GetDeltaAngle(double other)
        {
            double delta = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));
            AngleDouble deltaAngle = new AngleDouble(delta, unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public AngleDouble GetDeltaAngle(double other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);

            double delta = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));
            AngleDouble deltaAngle = new AngleDouble(delta, unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public int CompareNormalizedAngles(AngleDouble other)
        {
            double angle = ConvertTo_Zero_To_OneTurn_Angle();
            double otherAngle = ConvertTo_Zero_To_OneTurn_Angle(other.ConvertAngleTo(unit, other.angle));

            if (otherAngle > angle + Epsilon)
                return -1;
            else if (angle > otherAngle + Epsilon)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(AngleFloat other)
        {
            double angle = ConvertTo_Zero_To_OneTurn_Angle();
            double otherAngle = ConvertTo_Zero_To_OneTurn_Angle(other.ConvertAngleTo(unit, other.angle));

            if (otherAngle > angle + Epsilon)
                return -1;
            else if (angle > otherAngle + Epsilon)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(AngleInt other)
        {
            double angle = ConvertTo_Zero_To_OneTurn_Angle();
            double otherAngle = ConvertTo_Zero_To_OneTurn_Angle(other.ConvertAngleTo(unit, other.angle));

            if (otherAngle > angle + Epsilon)
                return -1;
            else if (angle > otherAngle + Epsilon)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(double other)
        {
            double angle = ConvertTo_Zero_To_OneTurn_Angle();
            other = ConvertTo_Zero_To_OneTurn_Angle(other);

            if (other > angle + Epsilon)
                return -1;
            else if (angle > other + Epsilon)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(double other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);

            double angle = ConvertTo_Zero_To_OneTurn_Angle();
            other = ConvertTo_Zero_To_OneTurn_Angle(other);

            if (other > angle + Epsilon)
                return -1;
            else if (angle > other + Epsilon)
                return 1;

            return 0;
        }

        public bool IsParallelTo(AngleDouble other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);
            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsParallelTo(AngleFloat other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);
            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsParallelTo(AngleInt other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);
            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsParallelTo(double other)
        {
            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsParallelTo(double other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);
            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(AngleDouble other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            double temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(AngleFloat other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            double temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(AngleInt other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            double temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(double other)
        {
            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));
            double temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(double other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);
            double difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));
            double temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsComplementaryTo(AngleDouble other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsComplementaryTo(AngleFloat other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsComplementaryTo(AngleInt other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsComplementaryTo(double other)
        {
            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsComplementaryTo(double other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);
            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(AngleDouble other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(AngleFloat other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(AngleInt other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(double other)
        {
            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(double other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsCoterminalTo(AngleDouble other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle)) <= Epsilon;
        }

        public bool IsCoterminalTo(AngleFloat other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle)) <= Epsilon;
        }

        public bool IsCoterminalTo(AngleInt other)
        {
            double otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle)) <= Epsilon;
        }

        public bool IsCoterminalTo(double other)
        {
            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other)) <= Epsilon;
        }

        public bool IsCoterminalTo(double other, AngleUnit type)
        {
            other = ConvertAngleFrom(unit, other);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other)) <= Epsilon;
        }

        #endregion
    }
}