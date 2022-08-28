using System;

namespace Angles
{
    internal interface IAngle<AngleT, NumericT> : IFormattable, IComparable, IComparable<AngleFloat>, IComparable<AngleDouble>, IComparable<AngleInt>
    {
        /*
         * This library is written by XeniaPhe (Mustafa Tunahan BAS)
         * Github address : https://github.com/XeniaPhe/CSharp.Net-Dedicated-Angles-Library
         */

        #region Properties

        /// <summary>
        /// Returns the angle type, you should use one of the ConvertTo methods to set the angle type as well
        /// </summary>
        public AngleUnit AngleUnit { get; }

        /// <summary>
        /// Returns the current angle as it is
        /// </summary>
        public NumericT Angle { get; }

        /// <summary>
        /// Returns the number of total turns of the original angle
        /// </summary>
        public NumericT Revolutions { get; }

        /// <summary>
        /// Converts the angle to degrees if needed, then returns it after normalizing to a degree between 0 and 360, does not alter the original angle
        /// </summary>
        /// 
        public NumericT ZeroTo360_DegreesAngle { get; }

        /// <summary>
        /// Converts the angle to degrees if needed, then returns it after normalizing to a degree between -180 and 180, does not alter the original angle
        /// </summary>
        public NumericT Minus180To180_DegreesAngle { get; }

        /// <summary>
        /// Converts the angle to radians if needed, then returns it after normalizing to a radian between 0 and 2 PI, does not alter the original angle
        /// </summary>
        public NumericT ZeroTo2PI_RadiansAngle { get; }

        /// <summary>
        /// Converts the angle to radians if needed, then returns it after normalizing to a radian between -PI and PI, does not alter the original angle
        /// </summary>
        public NumericT MinusPIToPI_RadiansAngle { get; }

        /// <summary>
        /// Converts the angle to gradians if needed, then returns it after normalizing to a gradian between 0 and 400, does not alter the original angle
        /// </summary>
        public NumericT ZeroTo400_GradiansAngle { get; }

        /// <summary>
        /// Converts the angle to gradians if needed, then returns it after normalizing to a gradian between -200 and 200, does not alter the original angle
        /// </summary>
        public NumericT Minus200To200_GradiansAngle { get; }

        /// <summary>
        /// Converts the angle to degrees if needed, then returns it as it is, does not alter the original angle
        /// </summary>
        public NumericT OpenInterval_DegreesAngle { get; }

        /// <summary>
        /// Converts the angle to radians if needed, then returns it as it is, does not alter the original angle
        /// </summary>
        public NumericT OpenInterval_RadiansAngle { get; }

        /// <summary>
        /// Converts the angle to gradians if needed, then returns it as it is, does not alter the original angle
        /// </summary>
        public NumericT OpenInterval_GradiansAngle { get; }

        /// <summary>
        /// Returns the complementary of the angle, if the return value is smaller than 0 then the angle does not have a complementary
        /// </summary>
        public NumericT ComplementaryAngle { get; }

        /// <summary>
        /// Returns the supplementary of the angle, if the return value is smaller than 0 then the angle does not have a supplementary
        /// </summary>
        public NumericT SupplementaryAngle { get; }

        /// <summary>
        /// Returns the reference of the angle
        /// </summary>
        public NumericT ReferenceAngle { get; }

        /// <summary>
        /// Returns the sine of the angle
        /// </summary>
        public NumericT Sin { get; }

        /// <summary>
        /// Returns the cosine of the angle
        /// </summary>
        public NumericT Cos { get; }

        /// <summary>
        /// Returns the tangent of the angle
        /// </summary>
        public NumericT Tan { get; }

        /// <summary>
        /// Returns the cotangent of the angle
        /// </summary>
        public NumericT Cot { get; }

        /// <summary>
        /// Returns the secant of the angle
        /// </summary>
        public NumericT Sec { get; }

        /// <summary>
        /// Returns the cosecant of the angle
        /// </summary>
        public NumericT Csc { get; }

        /// <summary>
        /// Returns the hyperbolic sine of the angle
        /// </summary>
        public NumericT Sinh { get; }

        /// <summary>
        /// Returns the hyperbolic cosine of the angle
        /// </summary>
        public NumericT Cosh { get; }

        /// <summary>
        /// Returns the hyperbolic tangent of the angle
        /// </summary>
        public NumericT Tanh { get; }

        /// <summary>
        /// Returns the hyperbolic cotangent of the angle
        /// </summary>
        public NumericT Coth { get; }

        /// <summary>
        /// Returns the hyperbolic secant of the angle
        /// </summary>
        public NumericT Sech { get; }

        /// <summary>
        /// Returns the hyperbolic cosecant of the angle
        /// </summary>
        public NumericT Csch { get; }

        /// <summary>
        /// Returns true if the angle is positive, else returns false
        /// </summary>
        public bool IsPositiveAngle { get; }

        /// <summary>
        /// Returns true if the angle is negative, else returns false
        /// </summary>
        public bool IsNegativeAngle { get; }

        /// <summary>
        /// Returns true if the angle is zero angle, else returns false
        /// </summary>
        public bool IsZeroAngle { get; }

        /// <summary>
        /// Returns true if the angle is an acute angle, else returns false
        /// </summary>
        public bool IsAcuteAngle { get; }

        /// <summary>
        /// Returns true if the angle is right angle, else returns false
        /// </summary>
        public bool IsRightAngle { get; }

        /// <summary>
        ///  Returns true if the angle is an obtuse angle, else returns false
        /// </summary>
        public bool IsObtuseAngle { get; }

        /// <summary>
        /// Returns true if the angle is straight angle, else returns false
        /// </summary>
        public bool IsStraightAngle { get; }

        /// <summary>
        /// Returns true if the angle is a reflex angle, else returns false
        /// </summary>
        public bool IsReflexAngle { get; }

        /// <summary>
        /// Returns true if the angle is complete angle, else returns false
        /// </summary>
        public bool IsCompleteAngle { get; }

        /// <summary>
        /// Returns true if the angle is an acute angle when normalized between zero and one turn, else returns false
        /// </summary>
        public bool IsNormalizedAngleAcuteAngle { get; }

        /// <summary>
        /// Returns true if the angle is right angle when normalized between zero and one turn, else returns false
        /// </summary>
        public bool IsNormalizedAngleRightAngle { get; }

        /// <summary>
        ///  Returns true if the angle is an obtuse angle when normalized between zero and one turn, else returns false
        /// </summary>
        public bool IsNormalizedAngleObtuseAngle { get; }

        /// <summary>
        /// Returns true if the angle is straight angle when normalized between zero and one turn, else returns false
        /// </summary>
        public bool IsNormalizedAngleStraightAngle { get; }

        /// <summary>
        /// Returns true if the angle is a reflex angle when normalized between zero and one turn, else returns false
        /// </summary>
        public bool IsNormalizedAngleReflexAngle { get; }

        /// <summary>
        /// Returns true if the angle is complete angle when normalized between zero and one turn, else returns false
        /// </summary>
        public bool IsNormalizedAngleCompleteAngle { get; }

        /// <summary>
        /// Returns the quadrant the angle is within
        /// </summary>
        public int Quadrant { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Sets angle and its type and returns itself, null type means keep the existing type of the object, the type is null by default
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="unit"></param>
        /// <returns>Angle</returns>
        public AngleT SetAngle(NumericT angle, AngleUnit? unit = null);

        /// <summary>
        /// Increments the angle by the angle given, and returns itself
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Increment(AngleFloat angle);

        /// <summary>
        /// Increments the angle by the angle given, and returns itself
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Increment(AngleDouble angle);

        /// <summary>
        /// Increments the angle by the angle given, and returns itself
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Increment(AngleInt angle);

        /// <summary>
        /// Increments the angle by the angle given, and returns itself
        /// Assumes the parameter is of the same type of angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Increment(NumericT angle);

        /// <summary>
        /// Increments the angle by the angle given, and returns itself
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Increment(NumericT angle, AngleUnit unit);

        /// <summary>
        /// Decrements the angle by the angle given, and returns itself
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Decrement(AngleFloat angle);

        /// <summary>
        /// Decrements the angle by the angle given, and returns itself
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Decrement(AngleDouble angle);

        /// <summary>
        /// Decrements the angle by the angle given, and returns itself
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Decrement(AngleInt angle);

        /// <summary>
        /// Decrements the angle by the angle given, and returns itself
        /// Assumes the parameter is of the same type of angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Decrement(NumericT angle);

        /// <summary>
        /// Decrements the angle by the angle given, and returns itself
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>Angle</returns>
        public AngleT Decrement(NumericT angle, AngleUnit unit);

        /// <summary>
        /// Converts the angle to radians, and returns itself
        /// </summary>
        /// <returns>Angle</returns>
        public AngleT ConvertToRadians();

        /// <summary>
        /// Converts the angle to degrees, and returns itself
        /// </summary>
        /// <returns>Angle</returns>
        public AngleT ConvertToDegrees();

        /// <summary>
        /// Converts the angle to gradians, and returns itself
        /// </summary>
        /// <returns>Angle</returns>
        public AngleT ConvertToGradians();

        /// <summary>
        /// Converts the angle to the angle type passed as parameter, and returns itself
        /// </summary>
        /// <returns>Angle</returns>
        public AngleT ConvertTo(AngleUnit angleUnit);

        /// <summary>
        /// Normalizes the angle between 0 and one turn without changing its unit, and returns itself
        /// </summary>
        /// <returns>Angle</returns>
        public AngleT NormalizeTo_Zero_To_OneTurn();

        /// <summary>
        /// Normalizes the angle between -1/2 turn and 1/2 turn without changing its unit, and returns itself
        /// </summary>
        /// <returns>Angle</returns>
        public AngleT NormalizeTo_MinusHalfTurn_To_HalfTurn();

        /// <summary>
        /// Normalizes the angle to the specified type without changing its unit, and returns itself
        /// </summary>
        /// <param name="type"></param>
        /// <returns>Angle</returns>
        public AngleT NormalizeTo(AngleType type);

        /// <summary>
        /// Returns the smallest positive angle that is the delta between this angle and the other
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Angle</returns>
        public AngleT GetDeltaAngle(AngleFloat other);

        /// <summary>
        /// Returns the smallest positive angle that is the delta between this angle and the other
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Angle</returns>
        public AngleT GetDeltaAngle(AngleDouble other);

        /// <summary>
        /// Returns the smallest positive angle that is the delta between this angle and the other
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Angle</returns>
        public AngleT GetDeltaAngle(AngleInt other);

        /// <summary>
        /// Returns the smallest positive angle that is the delta between this angle and the other
        /// Assumes the parameter is of the same type of angle
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Angle</returns>
        public AngleT GetDeltaAngle(NumericT other);

        /// <summary>
        /// Returns the smallest positive angle that is the delta between this angle and the other
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Angle</returns>
        public AngleT GetDeltaAngle(NumericT other, AngleUnit unit);

        /// <summary>
        /// Normalizes the angles between 0 and 1 turn to compare
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareNormalizedAngles(AngleFloat other);

        /// <summary>
        /// Normalizes the angles between 0 and 1 turn to compare
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareNormalizedAngles(AngleDouble other);

        /// <summary>
        /// Normalizes the angles between 0 and 1 turn to compare
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareNormalizedAngles(AngleInt other);

        /// <summary>
        /// Normalizes the angles between 0 and 1 turn to compare.
        /// Assumes that the parameter is of the same type of angle
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareNormalizedAngles(NumericT other);

        /// <summary>
        /// Normalizes the angles between 0 and 1 turn to compare.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareNormalizedAngles(NumericT other, AngleUnit unit);

        /// <summary>
        /// Returns true if the angles are parallel to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsParallelTo(AngleFloat other);

        /// <summary>
        /// Returns true if the angles are parallel to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsParallelTo(AngleDouble other);

        /// <summary>
        /// Returns true if the angles are parallel to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsParallelTo(AngleInt other);

        /// <summary>
        /// Returns true if the angles are parallel to each other, else returns false.
        /// Assumes the parameter is of the same type of angle
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsParallelTo(NumericT other);

        /// <summary>
        /// Returns true if the angles are parallel to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsParallelTo(NumericT other, AngleUnit unit);

        /// <summary>
        /// Returns true if the angles are vertical to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsPerpendicularTo(AngleFloat other);

        /// <summary>
        /// Returns true if the angles are vertical to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsPerpendicularTo(AngleDouble other);

        /// <summary>
        /// Returns true if the angles are vertical to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsPerpendicularTo(AngleInt other);

        /// <summary>
        /// Returns true if the angles are vertical to each other, else returns false
        /// Assumes the parameter is of the same type of angle
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsPerpendicularTo(NumericT other);

        /// <summary>
        /// Returns true if the angles are vertical to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsPerpendicularTo(NumericT other, AngleUnit unit);

        /// <summary>
        /// Returns true if the angles are complementary to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsComplementaryTo(AngleFloat other);

        /// <summary>
        /// Returns true if the angles are complementary to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsComplementaryTo(AngleDouble other);

        /// <summary>
        /// Returns true if the angles are complementary to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsComplementaryTo(AngleInt other);

        /// <summary>
        /// Returns true if the angles are complementary to each other, else returns false
        /// Assumes the parameter is of the same type of angle
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsComplementaryTo(NumericT other);

        /// <summary>
        /// Returns true if the angles are complementary to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsComplementaryTo(NumericT other, AngleUnit unit);

        /// <summary>
        /// Returns true if the angles are supplementary to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsSupplementaryTo(AngleFloat other);

        /// <summary>
        /// Returns true if the angles are supplementary to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsSupplementaryTo(AngleDouble other);

        /// <summary>
        /// Returns true if the angles are supplementary to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsSupplementaryTo(AngleInt other);

        /// <summary>
        /// Returns true if the angles are supplementary to each other, else returns false
        /// Assumes the parameter is of the same type of angle
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsSupplementaryTo(NumericT other);

        /// <summary>
        /// Returns true if the angles are supplementary to each other, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsSupplementaryTo(NumericT other, AngleUnit unit);

        /// <summary>
        /// Returns true if the angles are coterminal, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsCoterminalTo(AngleFloat other);

        /// <summary>
        /// Returns true if the angles are coterminal, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsCoterminalTo(AngleDouble other);

        /// <summary>
        /// Returns true if the angles are coterminal, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsCoterminalTo(AngleInt other);

        /// <summary>
        /// Returns true if the angles are coterminal, else returns false
        /// Assumes the parameter is of the same type of angle
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsCoterminalTo(NumericT other);

        /// <summary>
        /// Returns true if the angles are coterminal, else returns false
        /// </summary>
        /// <param name="other"></param>
        /// <returns>bool</returns>
        public bool IsCoterminalTo(NumericT other, AngleUnit unit);

        #endregion
    }
}