using System;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Angles
{
    public partial struct AngleInt
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
        /// Compares this angle with another AngleInt, returns -1 if this is smaller, 1 if this is bigger and 0 if they are equal
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
        /// As opposed to comparison operators and CompareTo methods, this Equals method checks the equality in all of type (AngleFloat, AngleDouble or AngleInt),
        /// the angle unit(degrees, radians or gradians) and magnitude of the angle
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() != typeof(AngleInt))
                return false;

            AngleInt other = (AngleInt)obj;

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
        public bool Equals(AngleInt other)
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
            builder.Append(" (AngleInt)");

            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(angle.ToString());
            builder.Append(' ');
            builder.Append(unit.ToString());
            builder.Append(" (AngleInt)");

            return builder.ToString();
        }

        public override int GetHashCode()
        {
            return angle.GetHashCode() * 11 + unit.GetHashCode() * 13;
        }

        #endregion

        #region Static Methods

        public static int DeltaAngle(AngleInt lhs, AngleInt rhs, AngleUnit unit = AngleUnit.Radians)
        {
            lhs.ConvertTo(unit);
            rhs.ConvertTo(unit);

            float delta = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - rhs.ConvertTo_Zero_To_OneTurn_Angle());

            if (delta > lhs.GetHalfTurn())
                delta = lhs.GetOneTurn() - delta;

            return (int)Math.Round(delta);
        }

        public static int DeltaAngle(AngleInt lhs, AngleFloat rhs, AngleUnit unit = AngleUnit.Radians)
        {
            lhs.ConvertTo(unit);
            rhs.ConvertTo(unit);

            float delta = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - (float)rhs.ConvertTo_Zero_To_OneTurn_Angle());

            if (delta > lhs.GetHalfTurn() + Epsilonf)
                delta = lhs.GetOneTurn() - delta;

            return (int)Math.Round(delta);
        }

        public static int DeltaAngle(AngleInt lhs, AngleDouble rhs, AngleUnit unit = AngleUnit.Radians)
        {
            lhs.ConvertTo(unit);
            rhs.ConvertTo(unit);

            double delta = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - rhs.ConvertTo_Zero_To_OneTurn_Angle());

            if (delta > lhs.GetHalfTurn() + Epsilond)
                delta = lhs.GetOneTurn() - delta;

            return (int)Math.Round(delta);
        }

        public static bool AreParallel(AngleInt lhs, AngleInt rhs)
        {
            int rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            float difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));

            return (difference <= Epsilonf || Math.Abs(difference - lhs.GetHalfTurn()) <= Epsilonf);
        }

        public static bool AreParallel(AngleInt lhs, AngleFloat rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));
            float difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));

            return (difference <= Epsilonf || Math.Abs(difference - lhs.GetHalfTurn()) <= Epsilonf);
        }

        public static bool AreParallel(AngleInt lhs, AngleDouble rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));
            float difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));

            return (difference <= Epsilonf || Math.Abs(difference - lhs.GetHalfTurn()) <= Epsilonf);
        }

        public static bool ArePerpendicular(AngleInt lhs, AngleInt rhs)
        {
            int rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            float difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));
            float temp = difference - lhs.GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilonf || Math.Abs(temp - lhs.GetHalfTurn()) <= Epsilonf);
        }

        public static bool ArePerpendicular(AngleInt lhs, AngleFloat rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));

            float difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));
            float temp = difference - lhs.GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilonf || Math.Abs(temp - lhs.GetHalfTurn()) <= Epsilonf);
        }

        public static bool ArePerpendicular(AngleInt lhs, AngleDouble rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));

            float difference = Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle));
            float temp = difference - lhs.GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilonf || Math.Abs(temp - lhs.GetHalfTurn()) <= Epsilonf);
        }

        public static bool AreComplementary(AngleInt lhs, AngleInt rhs)
        {
            int rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetQuarterTurn()) <= Epsilonf;
        }

        public static bool AreComplementary(AngleInt lhs, AngleFloat rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetQuarterTurn()) <= Epsilonf;
        }

        public static bool AreComplementary(AngleInt lhs, AngleDouble rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetQuarterTurn()) <= Epsilonf;
        }

        public static bool AreSupplementary(AngleInt lhs, AngleInt rhs)
        {
            int rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetHalfTurn()) <= Epsilonf;
        }

        public static bool AreSupplementary(AngleInt lhs, AngleFloat rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetHalfTurn()) <= Epsilonf;
        }

        public static bool AreSupplementary(AngleInt lhs, AngleDouble rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() + lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle) - lhs.GetHalfTurn()) <= Epsilonf;
        }

        public static bool AreCoterminal(AngleInt lhs, AngleInt rhs)
        {
            int rhsAngle = rhs.ConvertAngleTo(lhs.unit, rhs.angle);

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle)) <= Epsilonf;
        }

        public static bool AreCoterminal(AngleInt lhs, AngleFloat rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle)) <= Epsilonf;
        }

        public static bool AreCoterminal(AngleInt lhs, AngleDouble rhs)
        {
            int rhsAngle = (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));

            return Math.Abs(lhs.ConvertTo_Zero_To_OneTurn_Angle() - lhs.ConvertTo_Zero_To_OneTurn_Angle(rhsAngle)) <= Epsilonf;
        }

        /// <summary>
        /// Adds the right hand side to the left hand side and returns the resulting angle.
        /// As opposed to addition operator, this method returns the result as an AngleFloat saving the precision
        /// </summary>
        /// <param name="other"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat PrecisionConservingAddition(AngleInt lhs, AngleFloat rhs) => rhs + lhs;

        /// <summary>
        /// Adds the right hand side to the left hand side and returns the resulting angle.
        /// As opposed to addition operator, this method returns the result as an AngleDouble saving the precision
        /// </summary>
        /// <param name="other"></param>
        /// <returns>AngleDouble</returns>
        public static AngleDouble PrecisionConservingAddition(AngleInt lhs, AngleDouble rhs) => rhs + lhs;

        /// <summary>
        /// Subtracts the right hand side from the left hand side and returns the resulting angle.
        /// As opposed to subtraction operator, this method returns the result as an AngleFloat saving the precision
        /// </summary>
        /// <param name="other"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat PrecisionConservingSubtraction(AngleInt lhs, AngleFloat rhs) => -(rhs - lhs);

        /// <summary>
        /// Subtracts the right hand side from the left hand side and returns the resulting angle.
        /// As opposed to subtraction operator, this method returns the result as an AngleDouble saving the precision
        /// </summary>
        /// <param name="other"></param>
        /// <returns>AngleDouble</returns>
        public static AngleDouble PrecisionConservingSubtraction(AngleInt lhs, AngleDouble rhs) => -(rhs - lhs);

        public static AngleInt Max(params AngleInt[] angles)
        {
            int maxIndex = 0;
            AngleInt cache = angles[0];

            float revolutions = cache.angle / cache.GetOneTurn();
            float temp;

            for (int i = 1; i < angles.Length; i++)
            {
                cache = angles[i];

                if ((temp = cache.angle / cache.GetOneTurn()) > revolutions)
                {
                    maxIndex = i;
                    revolutions = temp;
                }
            }

            return angles[maxIndex];
        }

        public static AngleInt Min(params AngleInt[] angles)
        {
            int minIndex = 0;
            AngleInt cache = angles[0];

            float revolutions = angles[0].angle / cache.GetOneTurn();
            float temp;

            for (int i = 1; i < angles.Length; i++)
            {
                cache = angles[i];

                if ((temp = angles[i].angle / cache.GetOneTurn()) < revolutions)
                {
                    minIndex = i;
                    revolutions = temp;
                }
            }

            return angles[minIndex];
        }

        public static AngleInt MaxMagnitude(params AngleInt[] angles)
        {
            int maxIndex = 0;
            AngleInt cache = angles[0];

            float revolutions = Math.Abs(cache.angle / cache.GetOneTurn());
            float temp;

            for (int i = 1; i < angles.Length; i++)
            {
                cache = angles[i];

                if ((temp = Math.Abs(cache.angle / cache.GetOneTurn())) > revolutions)
                {
                    maxIndex = i;
                    revolutions = temp;
                }
            }

            return angles[maxIndex];
        }

        public static AngleInt MinMagnitude(params AngleInt[] angles)
        {
            int minIndex = 0;
            AngleInt cache = angles[0];

            float revolutions = Math.Abs(cache.angle / cache.GetOneTurn());
            float temp;

            for (int i = 1; i < angles.Length; i++)
            {
                cache = angles[i];

                if ((temp = Math.Abs(cache.angle / cache.GetOneTurn())) < revolutions)
                {
                    minIndex = i;
                    revolutions = temp;
                }
            }

            return angles[minIndex];
        }

        public static AngleInt Atan(float tan, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Atan(tan))).ConvertTo(unit);
        }

        public static AngleInt Atan2(float y, float x, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Atan2(y, x))).ConvertTo(unit);
        }

        public static AngleInt Atanh(float tanh, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Atanh(tanh))).ConvertTo(unit);
        }

        public static AngleInt Acot(float cot, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Atan(1f / cot))).ConvertTo(unit);
        }

        public static AngleInt Acot2(float y, float x, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Atan2(x, y))).ConvertTo(unit);
        }

        public static AngleInt Acoth(float coth, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Tanh(1f / coth))).ConvertTo(unit);
        }

        public static AngleInt Asin(float sin, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Asin(sin))).ConvertTo(unit);
        }

        public static AngleInt Asinh(float sinh, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Asinh(sinh))).ConvertTo(unit);
        }

        public static AngleInt Acos(float cos, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Acos(cos))).ConvertTo(unit);
        }

        public static AngleInt Acosh(float cosh, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Acosh(cosh))).ConvertTo(unit);
        }

        public static AngleInt Asec(float sec, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Acos(1f / sec))).ConvertTo(unit);
        }

        public static AngleInt Asech(float sech, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Acosh(1f / sech))).ConvertTo(unit);
        }

        public static AngleInt Acsc(float csc, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Asin(1f / csc))).ConvertTo(unit);
        }

        public static AngleInt Acsch(float csch, AngleUnit unit = AngleUnit.Radians)
        {
            return new AngleInt((int)Math.Round(Math.Asinh(1f / csch))).ConvertTo(unit);
        }

        #endregion

        #region Non-static Methods

        public AngleInt SetAngle(int angle, AngleUnit? unit = null)
        {
            this.angle = angle;
            this.unit = unit.HasValue ? unit.Value : this.unit;
            return this;
        }
        public AngleInt Increment(AngleInt angle)
        {
            this.angle += angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleInt Increment(AngleFloat angle)
        {
            this.angle += (int)Math.Round(angle.ConvertAngleTo(unit, angle.angle));
            return this;
        }

        public AngleInt Increment(AngleDouble angle)
        {
            this.angle += (int)Math.Round(angle.ConvertAngleTo(unit, angle.angle));
            return this;
        }

        public AngleInt Increment(int angle)
        {
            this.angle += angle;
            return this;
        }

        public AngleInt Increment(int angle, AngleUnit unit)
        {
            angle = ConvertAngleFrom(unit, angle);
            this.angle += angle;
            return this;
        }
        public AngleInt Decrement(AngleInt angle)
        {
            this.angle -= angle.ConvertAngleTo(unit, angle.angle);
            return this;
        }

        public AngleInt Decrement(AngleFloat angle)
        {
            this.angle -= (int)Math.Round(angle.ConvertAngleTo(unit, angle.angle));
            return this;
        }

        public AngleInt Decrement(AngleDouble angle)
        {
            this.angle -= (int)Math.Round(angle.ConvertAngleTo(unit, angle.angle));
            return this;
        }

        public AngleInt Decrement(int angle)
        {
            this.angle -= angle;
            return this;
        }

        public AngleInt Decrement(int angle, AngleUnit unit)
        {
            angle = ConvertAngleFrom(unit, angle);
            this.angle -= angle;
            return this;
        }

        public AngleInt ConvertToRadians()
        {
            angle = ConvertAngleTo(AngleUnit.Radians, angle);
            unit = AngleUnit.Radians;
            return this;
        }

        public AngleInt ConvertToDegrees()
        {
            angle = ConvertAngleTo(AngleUnit.Degrees, angle);
            unit = AngleUnit.Degrees;
            return this;
        }

        public AngleInt ConvertToGradians()
        {
            angle = ConvertAngleTo(AngleUnit.Gradians, angle);
            unit = AngleUnit.Gradians;
            return this;
        }

        public AngleInt ConvertTo(AngleUnit unit)
        {
            angle = ConvertAngleTo(unit, angle);
            this.unit = unit;
            return this;
        }

        public AngleInt NormalizeTo_Zero_To_OneTurn()
        {
            angle = (int)Math.Round(ConvertTo_Zero_To_OneTurn_Angle());
            return this;
        }

        public AngleInt NormalizeTo_MinusHalfTurn_To_HalfTurn()
        {
            angle = (int)Math.Round(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());
            return this;
        }

        public AngleInt NormalizeTo(AngleType type)
        {
            switch (type)
            {
                case AngleType.Zero_To_OneTurn:
                    angle = (int)Math.Round(ConvertTo_Zero_To_OneTurn_Angle());
                    break;
                case AngleType.MinusHalfTurn_To_Halfturn:
                    angle = (int)Math.Round(ConvertTo_MinusHalfTurn_To_HalfTurn_Angle());
                    break;
            }

            return this;
        }

        /// <summary>
        /// Converts the angle to AngleFloat and returns it
        /// </summary>
        /// <returns>AngleFloat</returns>
        public AngleFloat ToAngleFloat() => new AngleFloat(angle, unit);

        /// <summary>
        /// Converts the angle to AngleDouble and returns it
        /// </summary>
        /// <returns>AngleDouble</returns>
        public AngleDouble ToAngleDouble() => new AngleDouble(angle, unit);

        public AngleInt GetDeltaAngle(AngleInt other)
        {
            int otherAngle = other.ConvertAngleTo(unit, other.angle);

            int delta = (int)Math.Round(Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle)));
            AngleInt deltaAngle = new AngleInt(delta, unit);

            if (delta > GetHalfTurn() + Epsilonf)
                deltaAngle.angle = (int)Math.Round(GetOneTurn()) - delta;

            return deltaAngle;
        }

        public AngleInt GetDeltaAngle(AngleFloat other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            float delta = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            AngleInt deltaAngle = new AngleInt((int)Math.Round(delta), unit);

            if (delta > GetHalfTurn() + Epsilonf)
                deltaAngle.angle = (int)Math.Round(GetOneTurn() - delta);

            return deltaAngle;
        }

        public AngleInt GetDeltaAngle(AngleDouble other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            float delta = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            AngleInt deltaAngle = new AngleInt((int)Math.Round(delta), unit);

            if (delta > GetHalfTurn() + Epsilonf)
                deltaAngle.angle = (int)Math.Round(GetOneTurn() - delta);

            return deltaAngle;
        }

        public AngleInt GetDeltaAngle(int other)
        {
            int delta = (int)Math.Round(Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other)));
            AngleInt deltaAngle = new AngleInt(delta, unit);

            if (delta > GetHalfTurn() + Epsilonf)
                deltaAngle.angle = (int)Math.Round(GetOneTurn()) - delta;

            return deltaAngle;
        }

        public AngleInt GetDeltaAngle(int other, AngleUnit type)
        {
            other = ConvertAngleFrom(unit, other);

            int delta = (int)Math.Round(Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other)));
            AngleInt deltaAngle = new AngleInt(delta, unit);

            if (delta > GetHalfTurn() + Epsilonf)
                deltaAngle.angle = (int)Math.Round(GetOneTurn()) - delta;

            return deltaAngle;
        }

        public int CompareNormalizedAngles(AngleInt other)
        {
            float angle = ConvertTo_Zero_To_OneTurn_Angle();
            float otherAngle = ConvertTo_Zero_To_OneTurn_Angle(other.ConvertAngleTo(unit, other.angle));

            if (otherAngle > angle + Epsilonf)
                return -1;
            else if (angle > otherAngle + Epsilonf)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(AngleFloat other)
        {
            float angle = ConvertTo_Zero_To_OneTurn_Angle();
            float otherAngle = ConvertTo_Zero_To_OneTurn_Angle((int)Math.Round(other.ConvertAngleTo(unit, other.angle)));

            if (otherAngle > angle + Epsilonf)
                return -1;
            else if (angle > otherAngle + Epsilonf)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(AngleDouble other)
        {
            float angle = ConvertTo_Zero_To_OneTurn_Angle();
            float otherAngle = ConvertTo_Zero_To_OneTurn_Angle((int)Math.Round(other.ConvertAngleTo(unit, other.angle)));

            if (otherAngle > angle + Epsilonf)
                return -1;
            else if (angle > otherAngle + Epsilonf)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(int other)
        {
            float angle = ConvertTo_Zero_To_OneTurn_Angle();
            float otherAngle = ConvertTo_Zero_To_OneTurn_Angle(other);

            if (otherAngle > angle + Epsilonf)
                return -1;
            else if (angle > otherAngle + Epsilonf)
                return 1;

            return 0;
        }

        public int CompareNormalizedAngles(int other, AngleUnit type)
        {
            other = ConvertAngleFrom(unit, other);

            float angle = ConvertTo_Zero_To_OneTurn_Angle();
            float otherAngle = ConvertTo_Zero_To_OneTurn_Angle(other);

            if (otherAngle > angle + Epsilonf)
                return -1;
            else if (angle > otherAngle + Epsilonf)
                return 1;

            return 0;
        }

        public bool IsParallelTo(AngleInt other)
        {
            int otherAngle = other.ConvertAngleTo(unit, other.angle);
            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));

            return (difference <= Epsilonf || Math.Abs(difference - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsParallelTo(AngleFloat other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));
            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));

            return (difference <= Epsilonf || Math.Abs(difference - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsParallelTo(AngleDouble other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));
            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));

            return (difference <= Epsilonf || Math.Abs(difference - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsParallelTo(int other)
        {
            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));

            return (difference <= Epsilonf || Math.Abs(difference - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsParallelTo(int other, AngleUnit type)
        {
            other = ConvertAngleFrom(unit, other);
            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));

            return (difference <= Epsilonf || Math.Abs(difference - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsPerpendicularTo(AngleInt other)
        {
            int otherAngle = other.ConvertAngleTo(unit, other.angle);

            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilonf || Math.Abs(temp - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsPerpendicularTo(AngleFloat other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilonf || Math.Abs(temp - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsPerpendicularTo(AngleDouble other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilonf || Math.Abs(temp - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsPerpendicularTo(int other)
        {
            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilonf || Math.Abs(temp - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsPerpendicularTo(int other, AngleUnit type)
        {
            other = ConvertAngleFrom(unit, other);
            float difference = Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other));
            float temp = difference - GetQuarterTurn();

            return (Math.Abs(temp) <= Epsilonf || Math.Abs(temp - GetHalfTurn()) <= Epsilonf);
        }

        public bool IsComplementaryTo(AngleInt other)
        {
            int otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetQuarterTurn()) <= Epsilonf;
        }

        public bool IsComplementaryTo(AngleFloat other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetQuarterTurn()) <= Epsilonf;
        }

        public bool IsComplementaryTo(AngleDouble other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetQuarterTurn()) <= Epsilonf;
        }

        public bool IsComplementaryTo(int other)
        {
            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetQuarterTurn()) <= Epsilonf;
        }

        public bool IsComplementaryTo(int other, AngleUnit type)
        {
            other = ConvertAngleFrom(unit, other);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetQuarterTurn()) <= Epsilonf;
        }

        public bool IsSupplementaryTo(AngleInt other)
        {
            int otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetHalfTurn()) <= Epsilonf;
        }

        public bool IsSupplementaryTo(AngleFloat other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetHalfTurn()) <= Epsilonf;
        }

        public bool IsSupplementaryTo(AngleDouble other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(otherAngle) - GetHalfTurn()) <= Epsilonf;
        }

        public bool IsSupplementaryTo(int other)
        {
            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetHalfTurn()) <= Epsilonf;
        }

        public bool IsSupplementaryTo(int other, AngleUnit type)
        {
            other = ConvertAngleFrom(unit, other);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() + ConvertTo_Zero_To_OneTurn_Angle(other) - GetHalfTurn()) <= Epsilonf;
        }

        public bool IsCoterminalTo(AngleInt other)
        {
            int otherAngle = other.ConvertAngleTo(unit, other.angle);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle)) <= Epsilonf;
        }

        public bool IsCoterminalTo(AngleFloat other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle)) <= Epsilonf;
        }

        public bool IsCoterminalTo(AngleDouble other)
        {
            int otherAngle = (int)Math.Round(other.ConvertAngleTo(unit, other.angle));

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(otherAngle)) <= Epsilonf;
        }

        public bool IsCoterminalTo(int other)
        {
            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other)) <= Epsilonf;
        }

        public bool IsCoterminalTo(int other, AngleUnit type)
        {
            other = ConvertAngleFrom(unit, other);

            return Math.Abs(ConvertTo_Zero_To_OneTurn_Angle() - ConvertTo_Zero_To_OneTurn_Angle(other)) <= Epsilonf;
        }

        #endregion
    }
}