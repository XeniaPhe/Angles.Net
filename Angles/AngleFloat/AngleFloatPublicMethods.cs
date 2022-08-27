using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Angles
{
    public partial struct AngleFloat
    {
        #region Interface Implementations

        /// <summary>
        /// Calls one of the other CompareTo methods if the parameter is of the unit of one of them
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>int</returns>
        public int CompareTo([NotNullWhen(true)] object? obj)
        {
            if (obj is null)
                return 0;

            Type type;

            if ((type = obj.GetType()) == typeof(AngleFloat))
                return CompareTo((AngleFloat)obj);
            else if (type == typeof(AngleDouble))
                return CompareTo((AngleDouble)obj);
            else if (type == typeof(AngleInt))
                return CompareTo((AngleInt)obj);

            return 0;
        }

        /// <summary>
        /// Compares this angle with another AngleFloat, returns -1 if this is smaller, 1 if this is bigger and 0 if they are equal
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
        /// Compares this angle with an AngleDouble, returns -1 if this is smaller, 1 if this is bigger and 0 if they are equal
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
        /// As opposed to comparison operators and CompareTo methods, this Equals method checks the equality in all of type (AngleFloat, AngleDouble or AngleInt),
        /// the angle unit(degrees, radians or gradians) and magnitude of the angle
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() != typeof(AngleFloat))
                return false;

            AngleFloat other = (AngleFloat)obj;

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
        public bool Equals(AngleFloat other)
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
            builder.Append(" (AngleFloat)");

            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(angle.ToString());
            builder.Append(' ');
            builder.Append(unit.ToString());
            builder.Append(" (AngleFloat)");

            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return angle.GetHashCode() * 2 + unit.GetHashCode() * 3;
        }

        #endregion

        #region Static Methods

        public static float DeltaAngle(AngleFloat lhs, AngleFloat rhs, AngleUnit unit = AngleUnit.Radians)
        {
            lhs.ConvertTo(unit);
            rhs.ConvertTo(unit);

            float delta = Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - rhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

            if (delta > lhs.GetHalfTurn() + Epsilon)
                delta = lhs.GetOneTurn() - delta;

            return delta;
        }

        public static float DeltaAngle(AngleFloat lhs, AngleDouble rhs, AngleUnit unit = AngleUnit.Radians)
        {
            lhs.ConvertTo(unit);
            rhs.ConvertTo(unit);

            float delta = Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - (float)rhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

            if (delta > lhs.GetHalfTurn() + Epsilon)
                delta = lhs.GetOneTurn() - delta;

            return delta;
        }

        public static float DeltaAngle(AngleFloat lhs, AngleInt rhs, AngleUnit unit = AngleUnit.Radians)
        {
            lhs.ConvertTo(unit);
            rhs.ConvertTo(unit);

            float delta = Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - rhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());

            if (delta > lhs.GetHalfTurn() + Epsilon)
                delta = lhs.GetOneTurn() - delta;

            return delta;
        }

        public static bool AreParallel(AngleFloat lhs, AngleFloat rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            float difference = Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(rhsAngle));

            return (difference <= Epsilon || Math.Abs(difference - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool AreParallel(AngleFloat lhs, AngleDouble rhs)
        {
            float rhsAngle = (float)rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            float difference = Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(rhsAngle));

            return (difference <= Epsilon || Math.Abs(difference - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool AreParallel(AngleFloat lhs, AngleInt rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            float difference = Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(rhsAngle));

            return (difference <= Epsilon || Math.Abs(difference - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool ArePerpendicular(AngleFloat lhs, AngleFloat rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            float difference = Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(rhsAngle));
            float temp = difference - lhs.GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool ArePerpendicular(AngleFloat lhs, AngleDouble rhs)
        {
            float rhsAngle = (float)rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            float difference = Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(rhsAngle));
            float temp = difference - lhs.GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool ArePerpendicular(AngleFloat lhs, AngleInt rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            float difference = Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(rhsAngle));
            float temp = difference - lhs.GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - lhs.GetHalfTurn()) <= Epsilon);
        }

        public static bool AreComplementary(AngleFloat lhs, AngleFloat rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetQuarterTurn()) <= Epsilon;
        }

        public static bool AreComplementary(AngleFloat lhs, AngleDouble rhs)
        {
            float rhsAngle = (float)rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetQuarterTurn()) <= Epsilon;
        }

        public static bool AreComplementary(AngleFloat lhs, AngleInt rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetQuarterTurn()) <= Epsilon;
        }

        public static bool AreSupplementary(AngleFloat lhs, AngleFloat rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetHalfTurn()) <= Epsilon;
        }

        public static bool AreSupplementary(AngleFloat lhs, AngleDouble rhs)
        {
            float rhsAngle = (float)rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetHalfTurn()) <= Epsilon;
        }

        public static bool AreSupplementary(AngleFloat lhs, AngleInt rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetHalfTurn()) <= Epsilon;
        }

        public static bool AreCoterminal(AngleFloat lhs, AngleFloat rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(rhsAngle)) <= Epsilon;
        }

        public static bool AreCoterminal(AngleFloat lhs, AngleDouble rhs)
        {
            float rhsAngle = (float)rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(rhsAngle)) <= Epsilon;
        }

        public static bool AreCoterminal(AngleFloat lhs, AngleInt rhs)
        {
            float rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - lhs.ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(rhsAngle)) <= Epsilon;
        }

        /// <summary>
        /// Adds the right hand side to the left hand side and returns the resulting angle.
        /// As opposed to addition operator, this method returns the result as an AngleDouble saving the precision
        /// </summary>
        /// <param name="other"></param>
        /// <returns>AngleDouble</returns>
        public static AngleDouble PrecisionConservingAddition(AngleFloat lhs, AngleDouble rhs) => rhs + lhs;

        /// <summary>
        /// Subtracts the right hand side from the left hand side and returns the resulting angle.
        /// As opposed to subtraction operator, this method returns the result as an AngleDouble saving the precision
        /// </summary>
        /// <param name="other"></param>
        /// <returns>AngleDouble</returns>
        public static AngleDouble PrecisionConservingSubtraction(AngleFloat lhs, AngleDouble rhs) => -(rhs - lhs);

        public static AngleFloat Max(params AngleFloat[] angles)
        {
            int maxIndex = 0;
            float revolutions = angles[0].Revolutions;
            float temp;

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

        public static AngleFloat Min(params AngleFloat[] angles)
        {
            int minIndex = 0;
            float revolutions = angles[0].Revolutions;
            float temp;

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

        public static AngleFloat MaxMagnitude(params AngleFloat[] angles)
        {
            int maxIndex = 0;
            float revolutions = Math.Abs(angles[0].Revolutions);
            float temp;

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

        public static AngleFloat MinMagnitude(params AngleFloat[] angles)
        {
            int minIndex = 0;
            float revolutions = Math.Abs(angles[0].Revolutions);
            float temp;

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

        public static AngleFloat Atan(float tan, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Atan(tan)).ConvertTo(unit);
        }

        public static AngleFloat Atan2(float y, float x, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Atan2(y, x)).ConvertTo(unit);
        }

        public static AngleFloat Atanh(float tanh, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Atanh(tanh)).ConvertTo(unit);
        }

        public static AngleFloat Acot(float cot, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Atan(1f / cot)).ConvertTo(unit);
        }

        public static AngleFloat Acot2(float y, float x, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Atan2(x, y)).ConvertTo(unit);
        }

        public static AngleFloat Acoth(float coth, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Tanh(1f / coth)).ConvertTo(unit);
        }

        public static AngleFloat Asin(float sin, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Asin(sin)).ConvertTo(unit);
        }

        public static AngleFloat Asinh(float sinh, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Asinh(sinh)).ConvertTo(unit);
        }

        public static AngleFloat Acos(float cos, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Acos(cos)).ConvertTo(unit);
        }

        public static AngleFloat Acosh(float cosh, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Acosh(cosh)).ConvertTo(unit);
        }

        public static AngleFloat Asec(float sec, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Acos(1f / sec)).ConvertTo(unit);
        }

        public static AngleFloat Asech(float sech, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Acosh(1f / sech)).ConvertTo(unit);
        }

        public static AngleFloat Acsc(float csc, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Asin(1f / csc)).ConvertTo(unit);
        }

        public static AngleFloat Acsch(float csch, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleFloat((float)Math.Asinh(1f / csch)).ConvertTo(unit);
        }

        #endregion

        #region Non-static Methods

        public AngleFloat SetAngle(float angle, AngleUnit? unit = null)
        {
            this.angle = angle;
            this.unit = unit.HasValue ? unit.Value : this.unit;
            return this;
        }

        public AngleFloat Increment(AngleFloat angle)
        {
            this.angle += angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleFloat Increment(AngleDouble angle)
        {
            this.angle += (float)angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleFloat Increment(AngleInt angle)
        {
            this.angle += angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleFloat Increment(float angle)
        {
            this.angle += angle;
            return this;
        }

        public AngleFloat Increment(float angle, AngleUnit unit)
        {
            angle = ConvertAngleFrom(unit, angle);
            this.angle += angle;
            return this;
        }

        public AngleFloat Decrement(AngleFloat angle)
        {
            this.angle -= angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleFloat Decrement(AngleDouble angle)
        {
            this.angle -= (float)angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleFloat Decrement(AngleInt angle)
        {
            this.angle -= angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleFloat Decrement(float angle)
        {
            this.angle -= angle;
            return this;
        }

        public AngleFloat Decrement(float angle, AngleUnit unit)
        {
            angle = ConvertAngleFrom(unit, angle);
            this.angle -= angle;
            return this;
        }

        public AngleFloat ConvertToRadians()
        {
            angle = ConvertAngleTo(AngleUnit.Radians, angle);
            unit = AngleUnit.Radians;
            return this;
        }

        public AngleFloat ConvertToDegrees()
        {
            angle = ConvertAngleTo(AngleUnit.Degrees, angle);
            unit = AngleUnit.Degrees;
            return this;
        }

        public AngleFloat ConvertToGradians()
        {
            angle = ConvertAngleTo(AngleUnit.Gradians, angle);
            unit = AngleUnit.Gradians;
            return this;
        }

        public AngleFloat ConvertTo(AngleUnit unit)
        {
            angle = ConvertAngleTo(unit, angle);
            this.unit = unit;
            return this;
        }

        public AngleFloat NormalizeTo_Zero_To_OneTurn()
        {
            angle = ConvertTo_Zero_To_OneTurn_Angle();
            return this;
        }

        public AngleFloat NormalizeTo_MinusHalfTurn_To_HalfTurn()
        {
            angle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle();
            return this;
        }

        public AngleFloat NormalizeTo(AngleType type)
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
        /// Converts the angle to AngleDouble and returns it
        /// </summary>
        /// <returns>AngleDouble</returns>
        public AngleDouble ToAngleDouble() => new AngleDouble(angle, unit);

        /// <summary>
        /// Converts the angle to AngleInt and returns it
        /// </summary>
        /// <returns>AngleInt</returns>
        public AngleInt ToAngleInt()
        {
            float angle = this.angle;

            if (angle > Int32.MaxValue)
            {
                float oneTurn = GetOneTurn();
                float extraTurns = (angle - Int32.MaxValue) / oneTurn;
                angle -= (float)Math.Ceiling(extraTurns) * oneTurn;
            }

            return new AngleInt((int)Math.Round(angle), unit);
        }

        public AngleFloat GetDeltaAngle(AngleFloat other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            float delta = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle));
            AngleFloat deltaAngle = new AngleFloat(delta, unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public AngleFloat GetDeltaAngle(AngleDouble other)
        {
            float otherAngle = (float)other.ConvertAngleTo(unit, other.angle);

            float delta = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle));
            AngleFloat deltaAngle = new AngleFloat(delta, unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public AngleFloat GetDeltaAngle(AngleInt other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            float delta = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle));
            AngleFloat deltaAngle = new AngleFloat(delta, unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public AngleFloat GetDeltaAngle(float other)
        {
            float delta = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other));
            AngleFloat deltaAngle = new AngleFloat(delta, unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public AngleFloat GetDeltaAngle(float other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);

            float delta = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other));
            AngleFloat deltaAngle = new AngleFloat(delta, this.unit);

            if (delta > GetHalfTurn() + Epsilon)
                deltaAngle.angle = GetOneTurn() - delta;

            return deltaAngle;
        }

        public int CompareNormalizedAngles(AngleFloat other)
        {
            float angle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle();
            float otherAngle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other.ConvertAngleTo(unit, other.angle));

            if (otherAngle > angle + Epsilon)
                return -1;
            else if (angle > otherAngle + Epsilon)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(AngleDouble other)
        {
            float angle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle();
            float otherAngle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle((float)other.ConvertAngleTo(unit, other.angle));

            if (otherAngle > angle + Epsilon)
                return -1;
            else if (angle > otherAngle + Epsilon)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(AngleInt other)
        {
            float angle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle();
            float otherAngle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other.ConvertAngleTo(unit, other.angle));

            if (otherAngle > angle + Epsilon)
                return -1;
            else if (angle > otherAngle + Epsilon)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(float other)
        {
            float angle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle();
            other = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other);

            if (other > angle + Epsilon)
                return -1;
            else if (angle > other + Epsilon)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(float other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);

            float angle = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle();
            other = ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other);

            if (other > angle + Epsilon)
                return -1;
            else if (angle > other + Epsilon)
                return 1;

            return 0;
        }

        public bool IsParallelTo(AngleFloat other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);
            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsParallelTo(AngleDouble other)
        {
            float otherAngle = (float)other.ConvertAngleTo(unit, other.angle);
            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsParallelTo(AngleInt other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);
            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsParallelTo(float other)
        {
            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsParallelTo(float other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);
            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other));

            return (difference <= Epsilon || Math.Abs(difference - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(AngleFloat other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(AngleDouble other)
        {
            float otherAngle = (float)other.ConvertAngleTo(unit, other.angle);

            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(AngleInt other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(float other)
        {
            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsPerpendicularTo(float other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);
            float difference = Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilon || Math.Abs(temp - GetHalfTurn()) <= Epsilon);
        }

        public bool IsComplementaryTo(AngleFloat other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsComplementaryTo(AngleDouble other)
        {
            float otherAngle = (float)other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsComplementaryTo(AngleInt other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsComplementaryTo(float other)
        {
            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsComplementaryTo(float other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetQuarterTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(AngleFloat other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(AngleDouble other)
        {
            float otherAngle = (float)other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(AngleInt other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(float other)
        {
            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsSupplementaryTo(float other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetHalfTurn()) <= Epsilon;
        }

        public bool IsCoterminalTo(AngleFloat other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle)) <= Epsilon;
        }

        public bool IsCoterminalTo(AngleDouble other)
        {
            float otherAngle = (float)other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle)) <= Epsilon;
        }

        public bool IsCoterminalTo(AngleInt other)
        {
            float otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(otherAngle)) <= Epsilon;
        }

        public bool IsCoterminalTo(float other)
        {
            return Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other)) <= Epsilon;
        }

        public bool IsCoterminalTo(float other, AngleUnit unit)
        {
            other = ConvertAngleFrom(unit, other);

            return Math.Abs(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle() - ConvertTo_MinusHalfTurn_To_HalfTurn_Angle(other)) <= Epsilon;
        }

        #endregion
    }
}