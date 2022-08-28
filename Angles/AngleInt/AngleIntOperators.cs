using System;

namespace Angles
{
    public partial struct AngleInt
    {

        /*
         * Eventhough some of these operators do the same things as some of the others do,
         * I moslty avoided making calls between them for faster execution time
         */

        #region Unary Operators

        /// <summary>
        /// Returns the angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator +(AngleInt angle) => angle;

        /// <summary>
        /// Returns the negative of the angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator -(AngleInt angle)
        {
            angle.angle = -angle.angle;
            return angle;
        }

        /// <summary>
        /// Returns a new angle that is the negative of this angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator ~(AngleInt angle) => -angle;

        /// <summary>
        /// Returns the negative of the angle in its current representation
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator !(AngleInt angle) => -angle;

        /// <summary>
        /// Increments the angle by one degree, radian or gradian depending on in its type, then returns it
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator ++(AngleInt angle)
        {
            ++angle.angle;
            return angle;
        }

        /// <summary>
        /// Decrements the angle by one degree, radian or gradian depending on in its type, then returns it
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator --(AngleInt angle)
        {
            --angle.angle;
            return angle;
        }

        #endregion

        #region Arithmetic Operators

        #region Overloads of Operator +

        /// <summary>
        /// Adds the second angle to the first angle conserving the first angle's type, and returns the result
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator +(AngleInt lhs, AngleInt rhs)
        {
            lhs.angle += rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            return lhs;
        }

        /// <summary>
        /// Adds the first angle to the second angle conserving the first angle's type, and returns the result,
        /// Right hand side is assumed to be of the type of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different type than the left hand side,
        /// first convert it or create a new AngleInt object from it before adding to the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator +(AngleInt lhs, int rhs)
        {
            lhs.angle += rhs;
            return lhs;
        }

        /// <summary>
        /// Adds the first angle to the second angle conserving the second angle's type, and returns the result,
        /// Left hand side is assumed to be of the type of right hand side's
        /// (Warning : If the left hand side is supposed to be of a different type than the right hand side,
        /// first convert it or create a new AngleInt object from it before adding to the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator +(int lhs, AngleInt rhs)
        {
            rhs.angle += lhs;
            return rhs;
        }

        /// <summary>
        /// Adds the second angle to the first angle conserving the first angle's type, and returns the result as an AngleInt
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator +(AngleInt lhs, AngleFloat rhs)
        {
            lhs.angle += (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));
            return lhs;
        }

        /// <summary>
        /// Adds the second angle to the first angle conserving the first angle's type, and returns the result as an AngleInt
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator +(AngleInt lhs, AngleDouble rhs)
        {
            lhs.angle += (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));
            return lhs;
        }

        #endregion

        #region Overloads of Operator -

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's type, and returns the result
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator -(AngleInt lhs, AngleInt rhs)
        {
            lhs.angle -= rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            return lhs;
        }

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's type, and returns the result,
        /// Right hand side is assumed to be of the type of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different type than the left hand side,
        /// first convert it or create a new AngleInt object from it before subtracting from the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator -(AngleInt lhs, int rhs)
        {
            lhs.angle -= rhs;
            return lhs;
        }

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's type, and returns the result,
        /// Left hand side is assumed to be of the type of right hand side's
        /// (Warning : If the left hand side is supposed to be of a different type than the right hand side,
        /// first convert it or create a new AngleInt object from it before subtracting from the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator -(int lhs, AngleInt rhs)
        {
            rhs.angle = lhs - rhs.angle;
            return rhs;
        }

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's type, and returns the result as an AngleInt
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator -(AngleInt lhs, AngleFloat rhs)
        {
            lhs.angle -= (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));
            return lhs;
        }

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's type, and returns the result as an AngleInt
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator -(AngleInt lhs, AngleDouble rhs)
        {
            lhs.angle -= (int)Math.Round(rhs.ConvertAngleTo(lhs.unit, rhs.angle));
            return lhs;
        }

        #endregion

        #region Overloads of Operators * and /

        /// <summary>
        /// Multiplies the angle in the left hand side by the right hand side, and returns it
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator *(AngleInt lhs, int rhs)
        {
            lhs.angle *= rhs;
            return lhs;
        }

        /// <summary>
        /// Multiplies the angle in the right hand side by the left hand side, and returns it
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="lhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator *(int lhs, AngleInt rhs)
        {
            rhs.angle *= lhs;
            return rhs;
        }

        /// <summary>
        /// Divides the angle in the left hand side by the right hand side, and returns it
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="multiplier"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator /(AngleInt lhs, int rhs)
        {
            lhs.angle /= rhs;
            return lhs;
        }

        #endregion

        /// <summary>
        /// Calculates the modulo(right hand side) of left hand side, and returns it
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleInt</returns>
        public static AngleInt operator %(AngleInt lhs, int rhs)
        {
            lhs.angle %= rhs;
            return lhs;
        }

        #endregion

        #region Comparison Operators

        #region Overloads of Operator ==

        /// <summary>
        /// Returns true if the two angles are equal in magnitude, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(AngleInt lhs, AngleInt rhs) => rhs.Revolutions == lhs.Revolutions;

        /// <summary>
        /// Returns true if the two angles are equal in magnitude, else returns false
        /// Right hand side is assumed to be of the type of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different type than the left hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(AngleInt lhs, int rhs) => lhs.Revolutions == (int)Math.Round(rhs / lhs.GetOneTurn());

        /// <summary>
        /// Returns true if the two angles are equal in magnitude, else returns false
        /// Left hand side is assumed to be of the type of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different type than the right hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(int lhs, AngleInt rhs) => rhs.Revolutions == (int)Math.Round(lhs / rhs.GetOneTurn());

        /// <summary>
        /// Returns true if the two angles are equal in magnitude, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(AngleInt lhs, AngleFloat rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) <= Epsilonf;

        /// <summary>
        /// Returns true if the two angles are equal in magnitude, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(AngleInt lhs, AngleDouble rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) <= Epsilond;

        #endregion

        #region Overloads of Operator !=

        /// <summary>
        /// Returns true if the two angles are not equal in magnitude, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(AngleInt lhs, AngleInt rhs) => rhs.Revolutions != lhs.Revolutions;

        /// <summary>
        /// Returns true if the two angles are not equal in magnitude, else returns false
        /// Right hand side is assumed to be of the type of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different type than the left hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(AngleInt lhs, int rhs) => lhs.Revolutions == (int)Math.Round(rhs / lhs.GetOneTurn());

        /// <summary>
        /// Returns true if the two angles are not equal in magnitude, else returns false
        /// Left hand side is assumed to be of the type of right hand side's
        /// (Warning : If the left hand side is supposed to be of a different type than the right hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(int lhs, AngleInt rhs) => rhs.Revolutions == (int)Math.Round(lhs / rhs.GetOneTurn());

        /// <summary>
        /// Returns true if the two angles are not equal in magnitude, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(AngleInt lhs, AngleFloat rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) > Epsilonf;

        /// <summary>
        /// Returns true if the two angles are not equal in magnitude, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(AngleInt lhs, AngleDouble rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) > Epsilond;

        #endregion

        #region Overloads of Operator >

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(AngleInt lhs, AngleInt rhs) => lhs.Revolutions > rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's number of revolutions, else returns false
        /// Right hand side is assumed to be of the type of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different type than the left hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(AngleInt lhs, int rhs) => lhs.Revolutions > (int)Math.Round(rhs / lhs.GetOneTurn());

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's number of revolutions, else returns false
        /// Left hand side is assumed to be of the type of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different type than the right hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(int lhs, AngleInt rhs) => (int)Math.Round(lhs / rhs.GetOneTurn()) > rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(AngleInt lhs, AngleFloat rhs) => lhs.Revolutions > rhs.Revolutions + Epsilonf;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(AngleInt lhs, AngleDouble rhs) => lhs.Revolutions > rhs.Revolutions + Epsilond;

        #endregion

        #region Overloads of Operator >=

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(AngleInt lhs, AngleInt rhs) => lhs.Revolutions >= rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's revolutions - 0.0001, else returns false
        /// Right hand side is assumed to be of the type of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different type than the left hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(AngleInt lhs, int rhs) => lhs.Revolutions >= (int)Math.Round(rhs / lhs.GetOneTurn());

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's revolutions + 0.0001, else returns false
        /// Left hand side is assumed to be of the type of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different type than the right hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(int lhs, AngleInt rhs) => (int)Math.Round(lhs / rhs.GetOneTurn()) >= rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(AngleInt lhs, AngleFloat rhs) => lhs.Revolutions >= rhs.Revolutions - Epsilonf;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(AngleInt lhs, AngleDouble rhs) => lhs.Revolutions >= rhs.Revolutions - Epsilond;

        #endregion

        #region Overloads of Operator <

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(AngleInt lhs, AngleInt rhs) => lhs.Revolutions < rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than right hand side's number of revolutions, else returns false
        /// Right hand side is assumed to be of the type of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different type than the left hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(AngleInt lhs, int rhs) => lhs.Revolutions < (int)Math.Round(rhs / lhs.GetOneTurn());

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than right hand side's number of revolutions, else returns false
        /// Left hand side is assumed to be of the type of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different type than the right hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(int lhs, AngleInt rhs) => (int)Math.Round(lhs / rhs.GetOneTurn()) < rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(AngleInt lhs, AngleFloat rhs) => lhs.Revolutions + Epsilonf < rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(AngleInt lhs, AngleDouble rhs) => lhs.Revolutions + Epsilond < rhs.Revolutions;

        #endregion

        #region Overloads of Operator <=

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than or equal to right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(AngleInt lhs, AngleInt rhs) => lhs.Revolutions <= rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than or equal to right hand side's number of revolutions, else returns false
        /// Right hand side is assumed to be of the type of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different type than the left hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(AngleInt lhs, int rhs) => lhs.Revolutions <= (int)Math.Round(rhs / lhs.GetOneTurn());

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than or equal to right hand side's number of revolutions, else returns false
        /// Left hand side is assumed to be of the type of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different type than the right hand side,
        /// first convert it or create a new AngleInt object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(int lhs, AngleInt rhs) => (int)Math.Round(lhs / rhs.GetOneTurn()) <= rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than or equal to right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(AngleInt lhs, AngleFloat rhs) => lhs.Revolutions - Epsilonf <= rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is less than or equal to right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(AngleInt lhs, AngleDouble rhs) => lhs.Revolutions - Epsilond <= rhs.Revolutions;

        #endregion

        #endregion
    }
}