namespace Angles
{
    public partial struct AngleFloat
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
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator +(AngleFloat angle) => angle;

        /// <summary>
        /// Returns the negative of the angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator -(AngleFloat angle)
        {
            angle.angle = -angle.angle;
            return angle;
        }

        /// <summary>
        /// Returns a new angle that is the negative of this angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator ~(AngleFloat angle) => -angle;

        /// <summary>
        /// Returns the negative of the angle in its current representation
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator !(AngleFloat angle) => -angle;

        /// <summary>
        /// Increments the angle by one degree, radian or gradian depending on in its unit, then returns it
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator ++(AngleFloat angle)
        {
            ++angle.angle;
            return angle;
        }

        /// <summary>
        /// Decrements the angle by one degree, radian or gradian depending on in its unit, then returns it
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator --(AngleFloat angle)
        {
            --angle.angle;
            return angle;
        }

        #endregion

        #region Arithmetic Operators

        #region Overloads of Operator +

        /// <summary>
        /// Adds the second angle to the first angle conserving the first angle's unit, and returns the result
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator +(AngleFloat lhs, AngleFloat rhs)
        {
            lhs.angle += rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            return lhs;
        }

        /// <summary>
        /// Adds the first angle to the second angle conserving the first angle's unit, and returns the result,
        /// Right hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different unit than the left hand side,
        /// first convert it or create a new AngleFloat object from it before adding to the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator +(AngleFloat lhs, float rhs)
        {
            lhs.angle += rhs;
            return lhs;
        }

        /// <summary>
        /// Adds the first angle to the second angle conserving the second angle's unit, and returns the result,
        /// Left hand side is assumed to be of the unit of right hand side's
        /// (Warning : If the left hand side is supposed to be of a different unit than the right hand side,
        /// first convert it or create a new AngleFloat object from it before adding to the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator +(float lhs, AngleFloat rhs)
        {
            rhs.angle += lhs;
            return rhs;
        }

        /// <summary>
        /// Adds the second angle to the first angle conserving the first angle's unit, and returns the result as an AngleFloat
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator +(AngleFloat lhs, AngleDouble rhs)
        {
            lhs.angle += (float)rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            return lhs;
        }

        /// <summary>
        /// Adds the second angle to the first angle conserving the first angle's unit, and returns the result as an AngleFloat
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator +(AngleFloat lhs, AngleInt rhs)
        {
            lhs.angle += rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            return lhs;
        }

        #endregion

        #region Overloads of Operator -

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's unit, and returns the result
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator -(AngleFloat lhs, AngleFloat rhs)
        {
            lhs.angle -= rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            return lhs;
        }

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's unit, and returns the result,
        /// Right hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different unit than the left hand side,
        /// first convert it or create a new AngleFloat object from it before subtracting from the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator -(AngleFloat lhs, float rhs)
        {
            lhs.angle -= rhs;
            return lhs;
        }

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's unit, and returns the result,
        /// Left hand side is assumed to be of the unit of right hand side's
        /// (Warning : If the left hand side is supposed to be of a different unit than the right hand side,
        /// first convert it or create a new AngleFloat object from it before subtracting from the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator -(float lhs, AngleFloat rhs)
        {
            rhs.angle = lhs - rhs.angle;
            return rhs;
        }

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's unit, and returns the result as an AngleFloat
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator -(AngleFloat lhs, AngleDouble rhs)
        {
            lhs.angle -= (float)rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            return lhs;
        }

        /// <summary>
        /// Subtracts the second angle from the first angle conserving the first angle's unit, and returns the result as an AngleFloat
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator -(AngleFloat lhs, AngleInt rhs)
        {
            lhs.angle -= rhs.ConvertAngleTo(lhs.unit, rhs.angle);
            return lhs;
        }

        #endregion

        #region Overloads of Operators * and /

        /// <summary>
        /// Multiplies the angle in the left hand side by the right hand side, and returns it
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator *(AngleFloat lhs, float rhs)
        {
            lhs.angle *= rhs;
            return lhs;
        }

        /// <summary>
        /// Multiplies the angle in the right hand side by the left hand side, and returns it
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="lhs"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator *(float lhs, AngleFloat rhs)
        {
            rhs.angle *= lhs;
            return rhs;
        }

        /// <summary>
        /// Divides the angle in the left hand side by the right hand side, and returns it
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="multiplier"></param>
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator /(AngleFloat lhs, float rhs)
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
        /// <returns>AngleFloat</returns>
        public static AngleFloat operator %(AngleFloat lhs, float rhs)
        {
            lhs.angle %= rhs;
            return lhs;
        }

        #endregion

        #region Comparison Operators

        #region Overloads of Operator ==

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is less than or equal to 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(AngleFloat lhs, AngleFloat rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) <= Epsilon;

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is less than or equal to 0.0001, else returns false
        /// Right hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different unit than the left hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(AngleFloat lhs, float rhs) => Math.Abs(lhs.Revolutions - (rhs / lhs.GetOneTurn())) <= Epsilon;

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is less than or equal to 0.0001, else returns false
        /// Left hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different unit than the right hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(float lhs, AngleFloat rhs) => Math.Abs(rhs.Revolutions - (lhs / rhs.GetOneTurn())) <= Epsilon;

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is less than or equal to 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(AngleFloat lhs, AngleDouble rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) <= Epsilon;

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is less than or equal to 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator ==(AngleFloat lhs, AngleInt rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) <= Epsilon;

        #endregion

        #region Overloads of Operator !=

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is greater than 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(AngleFloat lhs, AngleFloat rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) > Epsilon;

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is greater than 0.0001, else returns false
        /// Right hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different unit than the left hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(AngleFloat lhs, float rhs) => Math.Abs(lhs.Revolutions - (rhs / lhs.GetOneTurn())) > Epsilon;

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is greater than 0.0001, else returns false
        /// Left hand side is assumed to be of the unit of right hand side's
        /// (Warning : If the left hand side is supposed to be of a different unit than the right hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(float lhs, AngleFloat rhs) => Math.Abs(rhs.Revolutions - (lhs / rhs.GetOneTurn())) > Epsilon;

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is greater than 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(AngleFloat lhs, AngleDouble rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) > Epsilon;

        /// <summary>
        /// Returns true if the difference between two angles' revolutions is greater than 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator !=(AngleFloat lhs, AngleInt rhs) => Math.Abs(lhs.Revolutions - rhs.Revolutions) > Epsilon;

        #endregion

        #region Overloads of Operator >

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's revolutions + 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(AngleFloat lhs, AngleFloat rhs) => lhs.Revolutions > rhs.Revolutions + Epsilon;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's revolutions + 0.0001, else returns false
        /// Right hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different unit than the left hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(AngleFloat lhs, float rhs) => lhs.Revolutions > (rhs / lhs.GetOneTurn()) + Epsilon;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's revolutions + 0.0001, else returns false
        /// Left hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different unit than the right hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(float lhs, AngleFloat rhs) => (lhs / rhs.GetOneTurn()) > rhs.Revolutions + Epsilon;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's revolutions + 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(AngleFloat lhs, AngleDouble rhs) => lhs.Revolutions > rhs.Revolutions + Epsilon;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than right hand side's revolutions + 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >(AngleFloat lhs, AngleInt rhs) => lhs.Revolutions > rhs.Revolutions + Epsilon;

        #endregion

        #region Overloads of Operator >=

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's revolutions - 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(AngleFloat lhs, AngleFloat rhs) => lhs.Revolutions >= rhs.Revolutions - Epsilon;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's revolutions - 0.0001, else returns false
        /// Right hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different unit than the left hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(AngleFloat lhs, float rhs) => lhs.Revolutions >= (rhs / lhs.GetOneTurn()) - Epsilon;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's revolutions + 0.0001, else returns false
        /// Left hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different unit than the right hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(float lhs, AngleFloat rhs) => (lhs / rhs.GetOneTurn()) >= rhs.Revolutions - Epsilon;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's revolutions - 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(AngleFloat lhs, AngleDouble rhs) => lhs.Revolutions >= rhs.Revolutions - Epsilon;

        /// <summary>
        /// Returns true if the left hand side's number of revolutions is greater than or equal to right hand side's revolutions - 0.0001, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator >=(AngleFloat lhs, AngleInt rhs) => lhs.Revolutions >= rhs.Revolutions - Epsilon;

        #endregion

        #region Overloads of Operator <

        /// <summary>
        /// Returns true if the left hand side's revolutions + 0.0001 is less than right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(AngleFloat lhs, AngleFloat rhs) => lhs.Revolutions + Epsilon < rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's revolutions + 0.0001 is less than right hand side's number of revolutions, else returns false
        /// Right hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different unit than the left hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(AngleFloat lhs, float rhs) => lhs.Revolutions + Epsilon < (rhs / lhs.GetOneTurn());

        /// <summary>
        /// Returns true if the left hand side's revolutions + 0.0001 is less than right hand side's number of revolutions, else returns false
        /// Left hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different unit than the right hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(float lhs, AngleFloat rhs) => (lhs / rhs.GetOneTurn()) + Epsilon < rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's revolutions + 0.0001 is less than right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(AngleFloat lhs, AngleDouble rhs) => lhs.Revolutions + Epsilon < rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's revolutions + 0.0001 is less than right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <(AngleFloat lhs, AngleInt rhs) => lhs.Revolutions + Epsilon < rhs.Revolutions;

        #endregion

        #region Overloads of Operator <=

        /// <summary>
        /// Returns true if the left hand side's revolutions - 0.0001 is less than or equal to right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(AngleFloat lhs, AngleFloat rhs) => lhs.Revolutions - Epsilon <= rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's revolutions - 0.0001 is less than or equal to right hand side's number of revolutions, else returns false
        /// Right hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the right hand side is supposed to be of a different unit than the left hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the left hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(AngleFloat lhs, float rhs) => lhs.Revolutions - Epsilon <= (rhs / lhs.GetOneTurn());

        /// <summary>
        /// Returns true if the left hand side's revolutions - 0.0001 is less than or equal to right hand side's number of revolutions, else returns false
        /// Left hand side is assumed to be of the unit of left hand side's
        /// (Warning : If the left hand side is supposed to be of a different unit than the right hand side,
        /// first convert it or create a new AngleFloat object from it before comparing it with the right hand side)
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(float lhs, AngleFloat rhs) => (lhs / rhs.GetOneTurn()) - Epsilon <= rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's revolutions - 0.0001 is less than or equal to right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(AngleFloat lhs, AngleDouble rhs) => lhs.Revolutions - Epsilon <= rhs.Revolutions;

        /// <summary>
        /// Returns true if the left hand side's revolutions - 0.0001 is less than or equal to right hand side's number of revolutions, else returns false
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns>bool</returns>
        public static bool operator <=(AngleFloat lhs, AngleInt rhs) => lhs.Revolutions - Epsilon <= rhs.Revolutions;

        #endregion

        #endregion
    }
}