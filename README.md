<p align="center" width="100%">
    <img src="src/Angles.NetLogo.png" width="350" height="275" />
</p>

# Angles.Net

Angles.Net library is dedicated to easily and quickly handling and manipulating different types and units of angles.
It allows conversions and operations between different units and representations of angles to ease the job of a programmer and reduce redundancy while dealing with angles.

[![Nuget](https://img.shields.io/nuget/v/Angles.Net?label=NUGET%20VERSION&logo=Angles.Net%20version&style=for-the-badge)](https://www.nuget.org/packages/Angles.Net/)



## Compatibility

****Angles.Net is compatible with .Net Core 3.1 and higher!****

## Appendix

* [License](#license)
* [Installation](#installation)
* [API Reference](#api-reference)
   - [Data Structures](#data-structures)
   - [Public Const and Static Fields](#public-const-and-static-fields)
   - [Constructors](#constructors)
   - [Public Properties](#public-properties)
   - [Operator Overloads](#operator-overloads)
      - [Unary Operators](#unary-operators)
      - [Addition and Subtraction Operators](#addition-and-subtraction-operators)
      - [Multiplication and Division Operators](#multiplication-and-division-operators)
      - [Modulo Operator](#modulo-operator)
      - [== and != Operators](#==-and-!=-operators)
      - [< and > Operators](#<-and->-operators)
      - [<= and >= Operators](#<=-and->=-operators)
    - [Public Methods](#public-methods)
       - [Interface Implementations](#interface-implementations)
       - [Static Methods](#static-methods)
    - [Important Notes](#important-notes)
* [Lessons Learned](#lessons)
* [FAQ](#faq)
* [Authors](#authors)


## License

[![License](https://img.shields.io/badge/License-BSD_2--Clause-orange.svg)](https://www.nuget.org/packages/Angles.Net/1.0.7/License)

[BSD-2-Clause](https://choosealicense.com/licenses/bsd-2-clause/)

## Installation

[![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/XeniaPhe/Angles.Net?color=%23b71cd6&label=Package%20Size&logo=Angles.Net&logoColor=%239f87a3)](https://www.nuget.org/packages/Angles.Net/)

You can install Angles.Net by opening the Package Manager Console in the Visual Studio from View/Other Windows/Package Manager Console and typing in one of the commands :

```bash
 Install-Package Angles.Net -Version 1.0.7
 dotnet add package Angles.Net --version 1.0.7
```

Alternatively, you can use the NuGet Package Manager GUI to install Angles.Net

After completing one of the above, you can verify the success of the installation by using this code :

```c#
using Angles;

public class Program
{
    public static void Main(string[] args)
    {
        AngleDouble d = new AngleDouble(AngleDouble.Tau, AngleUnit.Radians);
        AngleFloat f = new AngleFloat(AngleFloat.OneTurnInDegrees, AngleUnit.Degrees);

        Console.WriteLine(f == d);
    }
}
```





[Go Back To Appendix](#appendix)
## API Reference

### Data Structures

* AngleFloat
* AngleDouble
* AngleInt

These 3 are the main data structures that handle all the angle logic. All of them are implemented from an interface called IAngle but this interface isn't visible outside the Angles namespace because it is not needed.
Apart from these, there are two enums :

* AngleUnit
* AngleType

AngleUnit represents the different angle units (Degrees,Radians,Gradians)
&nbsp;

AngleType represents the two normalized types (Between -1/2 and 1/2 turns; between 0 and 1 turn)


[Go Back To Appendix](#appendix)

### Public Const and Static Fields

* Tau
* OneTurnInDegrees
* OneTurnInGradians
* PI
* HalfTurnInDegrees
* HalfTurnInGradians
* QuarterTurnInRadians
* QuarterTurnInDegrees
* QuarterTurnInGradians
* Rad2Deg
* Deg2Rad
* Grad2Deg
* Deg2Grad
* Grad2Rad
* Rad2Grad

These fields above are public const fields and each one is defined in each Angle object (AngleInt,AngleFloat,AngleDouble) separately with different precisions and primitive types(int,float,double respectively)

* ZeroAngle
* RightAngle
* StraightAngle
* CompleteAngle
* OneDegree
* OneRadian
* OneGradian

These fields are public static readonly fields and are defined in each Angle object separately. It is recommended to use these whenever possible since they only get created once in the start of the program. For example :

```c#
AngleDouble d = new AngleDouble(AngleDouble.Tau, AngleUnit.Radians);
```

```c#
AngleDouble d = AngleDouble.CompleteAngle;
```

Second code will execute faster since it does not create a new AngleDouble object.

[Go Back To Appendix](#appendix)

### Constructors

Each Angle's constructor follows the same pattern : 

```c#
public AngleFloat(float angle, AngleUnit unit = AngleUnit.Radians)
{
    this.angle = angle;
    this.unit = unit;
}
```

```c#
public AngleDouble(double angle, AngleUnit unit = AngleUnit.Radians)
{
    this.angle = angle;
    this.unit = unit;
}
```

```c#
public AngleInt(int angle, AngleUnit unit = AngleUnit.Radians)
{
    this.angle = angle;
    this.unit = unit;
}
```

Constructors take two parameters as seen above. First one is the angle value which is crucial and the second one is the unit in which the angle is represented. If the second parameter is not given, then it will default to radians.

**Actually, each Angle follows the same pattern in about 99% of the project. Due to this, everything from now on will be covered in only one of the structs and the same rules,patterns will be applicable to the other two.**

[Go Back To Appendix](#appendix)

### Public Properties

* AngleUnit : AngleUnit
&nbsp;

Returns the unit of the angle
* Angle : float
&nbsp;

Returns the angle
* Revolutions : float
&nbsp;

Returns the number of revolutions of the angle
* ZeroTo360_DegreesAngle : float
&nbsp;

Normalizes the angle between 0 and 360 degrees and returns it (does not alter the original angle and unit)
* Minus180To180_DegreesAngle : float
&nbsp;

Normalizes the angle between -180 and 180 degrees and returns it (does not alter the original angle and unit)
* ZeroTo2PI_RadiansAngle : float
&nbsp;

Normalizes the angle between 0 and 2ᴨ radians and returns it (does not alter the original angle and unit)
* MinusPIToPI_RadiansAngle : float
&nbsp;

Normalizes the angle between -ᴨ and ᴨ radians and returns it (does not alter the original angle and unit)
* ZeroTo400_GradiansAngle : float
&nbsp;

Normalizes the angle between 0 and 400 gradians and returns it (does not alter the original angle and unit)
* Minus200To200_GradiansAngle : float
&nbsp;

Normalizes the angle between -200 and 200 gradians and returns it (does not alter the original angle and unit)
* OpenInterval_DegreesAngle : float
&nbsp;

Converts the angle to degrees without normalizing it and returns it (does not alter the original angle and unit)
* OpenInterval_RadiansAngle : float
&nbsp;

Converts the angle to radians without normalizing it and returns it (does not alter the original angle and unit)
* OpenInterval_GradiansAngle : float
&nbsp;

Converts the angle to gradians without normalizing it and returns it (does not alter the original angle and unit)
* ComplementaryAngle : float
* SupplementaryAngle : float
&nbsp;

These two properties return the angle's complementary and supplementary angles respectively
* ReferenceAngle : float
&nbsp;

Returns the reference angle of the angle

* Sin : float
* Cos : float
* Tan : float
* Cot : float
* Sec : float
* Csc : float
* Sinh : float
* Cosh : float
* Tanh : float
* Coth : float
* Sech : float
* Csch : float
&nbsp;

These are the trigonometric properties and they're straightforward and thus they require no explanation

* IsPositiveAngle : bool
* IsNegativeAngle : bool
* IsZeroAngle : bool
* IsAcuteAngle : bool
* IsRightAngle : bool
* IsObtuseAngle : bool
* IsStraightAngle : bool
* IsReflexAngle : bool
* IsCompleteAngle : bool
&nbsp;

These properties can be used to query the general location of the angle quickly
* IsNormalizedAngleAcuteAngle, IsNormalizedAngleRightAngle, IsNormalizedAngleObtuseAngle, IsNormalizedAngleStraightAngle, IsNormalizedAngleReflexAngle, IsNormalizedAngleCompleteAngle : bool
&nbsp;

These properties first normalize the angle between 0 and 1 turn before checking it (does not alter the original angle and unit)
* Quadrant : int
&nbsp;

Returns the quadrant (1,2,3,or 4) that the angle is within

**These properties belong to AngleFloat struct, and they're identical to the other two struct's except for that the properties which return float in AngleFloat return double in AngleDouble and int in AngleInt.**

[Go Back To Appendix](#appendix)

### Operator Overloads

#### Unary Operators

* +(AngleFloat) : AngleFloat
* +(AngleDouble) : AngleDouble
* +(AngleInt) : AngleInt

These operators return the angle object itself

* -(AngleFloat) : AngleFloat
* -(AngleDouble) : AngleDouble
* -(AngleInt) : AngleInt
* !(AngleFloat) : AngleFloat
* !(AngleDouble) : AngleDouble
* !(AngleInt) : AngleInt
* ~(AngleFloat) : AngleFloat
* ~(AngleDouble) : AngleDouble
* ~(AngleInt) : AngleInt

These operators negate the angle and return the negated angle object without altering the original angle

* ++(AngleFloat) : AngleFloat
* ++(AngleDouble) : AngleDouble
* ++(AngleInt) : AngleInt
* --(AngleFloat) : AngleFloat
* --(AngleDouble) : AngleDouble
* --(AngleInt) : AngleInt

These operators increment and decrement the angle by one degree,one radian, or one gradian depending on the unit of the angle

[Go Back To Appendix](#appendix)

#### Addition and Subtraction Operators

*  +(AngleFloat, AngleFloat) : AngleFloat
*  +(AngleFloat, AngleDouble) : AngleFloat
*  +(AngleFloat, AngleInt) : AngleFloat
*  -(AngleFloat, AngleFloat) : AngleFloat
*  -(AngleFloat, AngleDouble) : AngleFloat
*  -(AngleFloat, AngleInt) : AngleFloat


All of these + and - operator overloads first convert the unit of right hand side parameter to left hand side parameter's unit unless they're of the same units, and then perform the addition/subtraction operation, then finally return the resulting AngleFloat object. They're safe to use because they automatically convert the units if they're different and return the resulting angle in the left hand side's unit.

&nbsp;
Apart from these, there exist two more options for each addition and subtraction :

* +(AngleFloat, float) : AngleFloat
* +(float, AngleFloat) : AngleFloat
* -(AngleFloat, float) : AngleFloat
* -(float, AngleFloat) : AngleFloat

Using these overloads however, might be risky since the primitive types are assumed to be of the same unit as the Angle object. So, when used carelessly, they might cause unintended results and confusion.

&nbsp;
Here's an example code on how to use them : 

```c#
public void TestingOperators()
{
    AngleFloat f = new AngleFloat(150f,AngleUnit.Degrees);
    AngleDouble d = AngleDouble.OneRadian;
    AngleInt i = new AngleInt(240,AngleUnit.Gradians);

    var ang1 = f + d  //AngleFloat object in degrees
    var ang2 = d - f  //AngleDouble object in radians
    var ang3 = i + d  //AngleInt object in gradians
    var ang4 = f + (d - i)  //AngleFloat object in degrees
    var ang5 = (i + d) - (f + d)  //AngleInt object in gradians
    var ang6 = d + (f + f + i + i) //AngleDouble object in radians
    var ang7 = d + 180.0  
    //Oops, d is an angle in radians but we tried to add an angle in degrees, 
    //now the resulting angle will be 181.0 radians!
}
```
**As seen in the code snippet above, there exist AngleDouble and AngleInt equivalents of each of these operators, however they're not mentioned here since it would be too long.**

[Go Back To Appendix](#appendix)

#### Multiplication and Division Operators

* *(AngleDouble, double) : AngleDouble
* *(double, AngleDouble) : AngleDouble

These operators are used to multiply an angle by a number, there exist AngleFloat and AngleInt equivalents of them as well. They return angle objects.

* /(AngleFloat, float) : AngleFloat

This operator is used to divide an angle by a number, there also exist AngleDouble and AngleInt equivalents of this operator. They return angle objects.

[Go Back To Appendix](#appendix)

#### Modulo Operator

* %(AngleFloat, float) : AngleFloat

This operator is used to calculate the remainder of an angle when divided by a number, there exist AngleInt and AngleDouble equivalents as well. They return angle objects.

[Go Back To Appendix](#appendix)

#### == and != Operators

* ==(AngleDouble, AngleDouble) : bool
* ==(AngleDouble, AngleFloat) : bool
* ==(AngleDouble, AngleInt) : bool
* ==(AngleDouble, double) : bool
* ==(double, AngleDouble) : bool
* !=(AngleDouble, AngleDouble) : bool
* !=(AngleDouble, AngleFloat) : bool
* !=(AngleDouble, AngleInt) : bool
* !=(AngleDouble, double) : bool
* !=(double, AngleDouble) : bool

These operators , as all other operators do, have their equivalents in AngleFloat and AngleInt structs.
They compare the signed magnitudes of angles only, they first convert one into another if the units are different.
One can use them safely since they're implemented with small epsilon values taking into account the rounding errors.

[Go Back To Appendix](#appendix)

#### < and > Operators

```c#
 >(AngleInt, AngleInt) : bool
 >(AngleInt, AngleFloat) : bool
 >(AngleInt, AngleDouble) : bool
 >(AngleInt, int) : bool
 >(int, AngleInt) : bool
 <(AngleInt, AngleInt) : bool
 <(AngleInt, AngleFloat) : bool
 <(AngleInt, AngleDouble) : bool
 <(AngleInt, int) : bool
 <(int, AngleInt) : bool
```
**I had to write them in a script because the markdown syntax didn't let me use the greater operator symbol in a bullet list**

These operators, which have their equivalents in AngleFloat and AngleDouble, are used to compare the angles' signed magnitudes. One can use them safely since they're implemented (unless they do int to int comparison) with small epsilon values to prevent rounding errors. 

[Go Back To Appendix](#appendix)

#### <= and >= Operators

```c#
 >=(AngleDouble, AngleDouble) : bool
 >=(AngleDouble, AngleFloat) : bool
 >=(AngleDouble, AngleInt) : bool
 >=(AngleDouble, double) : bool
 >=(double, AngleDouble) : bool
 <=(AngleDouble, AngleDouble) : bool
 <=(AngleDouble, AngleFloat) : bool
 <=(AngleDouble, AngleInt) : bool
 <=(AngleDouble, double) : bool
 <=(double, AngleDouble) : bool
```
These operators, which have their equivalents in AngleFloat and AngleInt, are used to compare the angles' signed magnitudes. One can use them safely since they're implemented (unless they do int to int comparison) with small epsilon values to prevent rounding errors. 

Here's an example code snippet : 

```c#
public void TestingOperators2()
{
    AngleFloat f = new AngleFloat(25f,AngleUnit.Degrees);
    AngleDouble d = AngleDouble.OneRadian;
    AngleInt i = new AngleInt(240,AngleUnit.Gradians);

    Console.WriteLine(f > d);   //false
    Console.WriteLine(d > i);   //false
    Console.WriteLine(i > f);   //true
    Console.WriteLine(d > -i);  //true
    Console.WriteLine(f > !d);  //true

    f = new AngleFloat(AngleFloat.HalfTurnInDegrees / AngleFloat.PI,AngleUnit.Degrees);

    Console.WriteLine(f == d);  //true since one radian is equal to 180/ᴨ degrees
    Console.WriteLine(d == f);  //true
    Console.WriteLine(f > d);   //false
    Console.WriteLine(f >= d);  //true

    f += d;
    Console.WriteLine(f > d && f >= d);   //true
    Console.WriteLine((d + f) < AngleFloat.PI);   //true
    Console.WriteLine((f + d) < AngleFloat.PI);   //false,the order matters!

    /*
    The first one converts the result into a radian (1 + 2 = 3 radians)
    But the second one converts the result into a degree (57.3 + 114.6 = 171.9 degrees)
    Finally,comparison with a primitive type assumes that it's of the same unit as the Angle object
    So the first expression yields 3 radians < 3.14 radians which evaluates to true
    While the second expression yields 171.9 degrees < 3.14 degrees which is false
    */
}
```
[Go Back To Appendix](#appendix)

### Public Methods

* SetAngle(double angle,AngleUnit? unit = null) : AngleDouble
&nbsp;

SetAngle allows to change the angle and its unit. When unit is not passed, the method will treat the passed angle as if it's of the same unit as it was before, and so protect the present unit. After setting the angle and the unit, it will return the angle object itself to allow for multiple actions in one line of code. This method is defined in all angle structs.
* Increment(AngleDouble angle) : AngleDouble
* Increment(AngleFloat angle) : AngleDouble
* Increment(AngleInt angle) : AngleDouble
* Increment(double angle) : AngleDouble
* Increment(double angle, AngleUnit unit) : AngleDouble
* Decrement(AngleFloat angle) : AngleFloat
* Decrement(AngleDouble angle) : AngleFloat
* Decrement(AngleInt angle) : AngleFloat
* Decrement(float angle) : AngleFloat
* Decrement(float angle, AngleUnit unit) : AngleFloat

The Increment overloads belong to AngleDouble struct and the Decrement overloads belong to AngleFloat struct. Increment and Decrement overloads are all defined in all angle structs.They could be used like + and - operators with a difference that these are instance methods as opposed to operators. These methods increment and decrement the angle by the amount of parameter angle. Like SetAngle method, they also return themselves to allow for more code in one line.


* ConvertToRadians() : AngleFloat
* ConvertToDegrees() : AngleFloat
* ConvertToGradians() : AngleFloat
* ConvertTo(AngleUnit unit) : AngleFloat

These methods convert the angle to a different unit and again return themselves after conversion to allow for more code in one line. These methodsa are also defined in each angle struct.

* NormalizeTo_Zero_To_OneTurn() : AngleDouble
* NormalizeTo_MinusHalfTurn_To_HalfTurn : AngleDouble
* NormalizeTo(AngleType type) : AngleDouble

These methods (as opposed to properties like ZeroTo360_DegreesAngle, Minus200To200_GradiansAngle, etc...) normalize the original angle and return the angle object to allow for more code in one line.

* ToAngleDouble() : AngleDouble
* ToAngleInt() : AngleInt

These methods belong to AngleFloat struct and they are used to increase or reduce the precision by converting the angle object (returning the same angle in the type of target struct). They are not defined in each struct for obvious reasons. AngleInt's equivalent methods are :

* ToAngleFloat() : AngleFloat
* ToAngleDouble() : AngleDouble

AngleDouble's methods are :

* ToAngleFloat() : AngleFloat
* ToAngleInt() : AngleInt

Here's an example code snippet for how to use them :

```c#
public void TestingMethods()
{
    AngleFloat f = AngleFloat.StraightAngle; //radians by default
    AngleDouble d = new AngleDouble(40.0,AngleUnit.Degrees);

    Console.WriteLine(f.Angle); //will print 3.1415...
    f.SetAngle(2f); //Set to 2 radians
    Console.WriteLine(f.Increment(1.1415f).Angle);  //will print 3.1415...
    d = f.ToAngleDouble();

    Console.WriteLine(d.Angle); //will print 3.1415...

    d.SetAngle(361.0,AngleUnit.Degrees);  //Set to 361 degrees
    Console.WriteLine(d.NormalizeTo(AngleType.Zero_To_OneTurn).Angle);
    //will print 1

    Console.WriteLine(d == AngleDouble.OneDegree);  //true
}
```

* GetDeltaAngle(AngleFloat other) : AngleFloat
* GetDeltaAngle(AngleDouble other) : AngleFloat
* GetDeltaAngle(AngleInt other) : AngleFloat
* GetDeltaAngle(float other) : AngleFloat
* GetDeltaAngle(float other, AngleUnit unit) : AngleFloat

These methods, which have their equivalents in other two angle structs, calculate the shortest difference between angles and return a new angle object that has a value between 0 and 1 turn.

* CompareNormalizedAngles(AngleFloat other) : int
* CompareNormalizedAngles(AngleDouble other) : int
* CompareNormalizedAngles(AngleInt other) : int
* CompareNormalizedAngles(float other) : int
* CompareNormalizedAngles(float other, AngleUnit unit) : int

These methods, as opposed to CompareTo methods (they're not covered yet), compare the normalized angles(angles between -1/2 and 1/2 turn) and return 0 if they're equal, return -1 if the parameter is greater and return 1 if the angle instance from which the method is called is greater. The other two angle structs have their equivalent methods.

* IsParallelTo(AngleDouble other) : bool
* IsParallelTo(AngleFloat other) : bool
* IsParallelTo(AngleInt other) : bool
* IsParallelTo(double other) : bool
* IsParallelTo(double other, AngleUnit unit) : bool

These methods could be used to check if two angles are parallel to each other. Other angle structs have their equivalent IsParallelTo methods as well.

* IsPerpendicularTo(AngleInt other) : bool
* IsPerpendicularTo(AngleFloat other) : bool
* IsPerpendicularTo(AngleDouble other) : bool
* IsPerpendicularTo(int other) : bool
* IsPerpendicularTo(int other, AngleUnit unit) : bool

These methods could be used to check if two angles are perpendicular to each other. Other angle structs have their equivalents for IsPerpendicularTo as well.

* IsComplementaryTo(AngleFloat other) : bool
* IsComplementaryTo(AngleDouble other) : bool
* IsComplementaryTo(AngleInt other) : bool
* IsComplementaryTo(float other) : bool
* IsComplementaryTo(float other, AngleUnit unit) : bool

These methods could be used to check if two angles are complementary to each other. Other angle structs have their equivalents for IsComplementaryTo as well.

* IsSupplementaryTo(AngleFloat other) : bool
* IsSupplementaryTo(AngleDouble other) : bool
* IsSupplementaryTo(AngleInt other) : bool
* IsSupplementaryTo(float other) : bool
* IsSupplementaryTo(float other, AngleUnit unit) : bool

These methods could be used to check if two angles are supplementary to each other. Other angle structs have their equivalents for IsSupplementaryTo as well.

* IsCoterminalTo(AngleFloat other) : bool
* IsCoterminalTo(AngleDouble other) : bool
* IsCoterminalTo(AngleInt other) : bool
* IsCoterminalTo(float other) : bool
* IsCoterminalTo(float other, AngleUnit unit) : bool

These methods could be used to check if two angles are coterminal to each other. Other angle structs have their equivalents for IsCoterminalTo as well.

[Go Back To Appendix](#appendix)

#### Interface Implementations

Each Angle struct implements IFormattable, IComparable, IComparable<AngleFloat>, IComparable<AngleDouble>, IComparable<AngleInt> interfaces.

AngleFloat has these methods :

* CompareTo(AngleFloat other) : int
* CompareTo(AngleDouble other) : int
* CompareTo(AngleInt other) : int
* CompareTo(object? obj) : int
* Equals(AngleFloat other) : bool
* Equals(object? obj) : bool
* ToString() : string
* ToString(string? format,IFormatProvider? formatProvider) : string
* GetHashCode() : int

CompareTo overloads work same as comparison operators do, the overload with object parameter actually first determines which type of angle struct the object is and then calls the related CompareTo overload and returns it result. If the passed object is not an instance of any of the angle structs,then it will return Int32.MaxValue.

Equals overloads compare not only signed magnitudes of angles but also require them to be of the same type and same unit.

The parameterless ToString overload return a string as follows : "{angle} {unit} {type}"

The other ToString overload lets you pass a format for how the angle should be printed.

Similar to these,AngleDouble has :

* CompareTo(AngleDouble other) : int
* CompareTo(AngleFloat other) : int
* CompareTo(AngleInt other) : int
* CompareTo(object? obj) : int
* Equals(AngleDouble other) : bool
* Equals(object? obj) : bool
* ToString() : string
* ToString(string? format,IFormatProvider? formatProvider) : string
* GetHashCode() : int

and AngleInt has : 

* CompareTo(AngleInt other) : int
* CompareTo(AngleFloat other) : int
* CompareTo(AngleDouble other) : int
* CompareTo(object? obj) : int
* Equals(AngleInt other) : bool
* Equals(object? obj) : bool
* ToString() : string
* ToString(string? format,IFormatProvider? formatProvider) : string
* GetHashCode() : int

[Go Back To Appendix](#appendix)

#### Static methods

* DeltaAngle(AngleFloat lhs, AngleFloat rhs, AngleUnit unit = AngleUnit.Radians) : float
* DeltaAngle(AngleFloat lhs, AngleDouble rhs, AngleUnit unit = AngleUnit.Radians) : float
* DeltaAngle(AngleFloat lhs, AngleInt rhs, AngleUnit unit = AngleUnit.Radians) : float

DeltaAngle overloads calculate the shortest difference between angles and return the angle value between 0 and 1 turn in the desired unit. They have their equivalents in other angle structs.

* AreParallel(AngleFloat lhs, AngleFloat rhs) : bool
* AreParallel(AngleFloat lhs, AngleDouble rhs) : bool
* AreParallel(AngleFloat lhs, AngleInt rhs) : bool

AreParallel overloads work exactly in the same way as IsParallelTo method overloads do. They have their equivalents in other angle structs.

* ArePerpendicular(AngleFloat lhs, AngleFloat rhs) : bool
* ArePerpendicular(AngleFloat lhs, AngleDouble rhs) : bool
* ArePerpendicular(AngleFloat lhs, AngleInt rhs) : bool

ArePerpendicular overloads work exactly in the same way as IsPerpendicularTo method overloads do. They have their equivalents in other angle structs.

* AreComplementary(AngleFloat lhs, AngleFloat rhs) : bool
* AreComplementary(AngleFloat lhs, AngleDouble rhs) : bool
* AreComplementary(AngleFloat lhs, AngleInt rhs) : bool

AreComplementary overloads work exactly in the same way as IsComplementaryTo method overloads do. They have their equivalents in other angle structs.

* AreSupplementary(AngleFloat lhs, AngleFloat rhs) : bool
* AreSupplementary(AngleFloat lhs, AngleDouble rhs) : bool
* AreSupplementary(AngleFloat lhs, AngleInt rhs) : bool

AreSupplementary overloads work exactly in the same way as IsSupplementaryTo method overloads do. They have their equivalents in other angle structs.

* AreCoterminal(AngleFloat lhs, AngleFloat rhs) : bool
* AreCoterminal(AngleFloat lhs, AngleDouble rhs) : bool
* AreCoterminal(AngleFloat lhs, AngleInt rhs) : bool

AreCoterminal overloads work exactly in the same way as IsCoterminalTo method overloads do. They have their equivalents in other angle structs.


AngleInt and AngleFloat structs have two extra static methods than AngleDouble does. They are alternatives to + and - operators but they instead return the result in the higher precision. Here are the AngleFloat's methods : 


* PrecisionConservingAddition(AngleFloat lhs, AngleDouble rhs) : AngleDouble
* PrecisionConservingSubtraction(AngleFloat lhs, AngleDouble rhs) : AngleDouble

AngleInt has one more overload for each method for apparent reasons : 

* PrecisionConservingAddition(AngleInt lhs, AngleFloat rhs) : AngleFloat
* PrecisionConservingAddition(AngleInt lhs, AngleDouble rhs) : AngleDouble
* PrecisionConservingSubtraction(AngleInt lhs, AngleFloat rhs) : AngleFloat
* PrecisionConservingSubtraction(AngleInt lhs, AngleDouble rhs) : AngleDouble

Here's an example code : 

```c#
public void TestingMethods()
{
    AngleFloat f = AngleFloat.OneDegree;
    AngleDouble d = AngleDouble.OneRadian;
    AngleInt i = AngleInt.OneGradian;

    Console.WriteLine(AngleInt.PrecisionConservingAddition(i,f).Equals(f + i)); //true
    Console.WriteLine(AngleFloat.PrecisionConservingAddition(f,d).Equals(d + f)); //true
}
```

* Max(params AngleFloat[] angles) : AngleFloat
* Max(params AngleDouble[] angles) : AngleDouble
* Max(params AngleInt[] angles) : AngleInt
* Min(params AngleFloat[] angles) : AngleFloat
* Min(params AngleDouble[] angles) : AngleDouble
* Min(params AngleInt[] angles) : AngleInt

Each angle struct has one Max and one Min method that accept only its own type.

* MaxMagnitude(params AngleFloat[] angles) : AngleFloat
* MaxMagnitude(params AngleDouble[] angles) : AngleDouble
* MaxMagnitude(params AngleInt[] angles) : AngleInt
* MinMagnitude(params AngleFloat[] angles) : AngleFloat
* MinMagnitude(params AngleDouble[] angles) : AngleDouble
* MinMagnitude(params AngleInt[] angles) : AngleInt

Each angle struct has one MaxMagnitude and one MinMagnitude method that accept only its own type. They use the unsigned magnitudes to pick the maximum and minimum.

* Atan(double tan, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Atan2(double y, double x, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Atanh(double tanh, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Acot(double cot, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Acot2(double y, double x, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Acoth(double coth, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Asin(double sin, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Asinh(double sinh, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Acos(double cos, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Acosh(double cosh, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Asec(double sec, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Asech(double sech, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Acsc(double csc, AngleUnit unit = AngleUnit.Radians) : AngleDouble
* Acsch(double csch, AngleUnit unit = AngleUnit.Radians) : AngleDouble

Each angle struct has their own versions of these arc-trigonometric methods. They take a result of a trigonometric function and desired unit and calculate the inverse of that function which yields an angle value, so they return an angle object with that angle value and the desired unit.

[Go Back To Appendix](#appendix)

### Important Notes

1. **Be careful while using the overloads that take primitive types as parameters since they could cause unintended results and it would be pretty hard to debug it.**
2. ****Do not really use AngleInt, I added it to complete the pattern and made an excuse that "Who knows what people may be using this library for?So just do it.". So I just did it. AngleInt could cause problems with conversions and representing radians accurately. Evenmore it might be risky to do comparisons with an AngleInt. So if you don't really need it, don't use it.****
&nbsp;

[Go Back To Appendix](#appendix)

## Lessons Learned

#### What did you learn while building this project?
&nbsp;
>I've learned that building a class library is not as straightforward as I thought it would be. I've learned that planning before starting to write the code is an important step after realizing that I've made some of the methods non-static that I would've instead liked to make static methods, so I had to add static versions of them also and that was a tedious process. I also learned about some properties of angles during my researches.


[Go Back To Appendix](#appendix)

## FAQ

#### What made you write this library?

Many functions in Math APIs return angle values, most of them are in radians for convenience. However this might not be so much conveient for a programmer, because radians don't make sense to most of us,one can instantly visualize what 150 degrees looks like but it's hard to visualize an angle in radians unless it's 0 or ᴨ or 2ᴨ. So some people like myself could find themselves converting them to degrees using consts like PI in the Math API they are using, and then after being done with the angle it should be converted back to radians, and these back and forth conversions aren't necessarily made only once in a project, and also they look ugly. Another problem is, even if one only uses radians, not all methods return the angles in the same ranges, some return angles between -ᴨ and ᴨ, some other methods return between 0 and 2ᴨ and even some of them return between -ᴨ/4 and ᴨ/4. So this causes confusion and might require conversions or extra if statements.

&nbsp;

So one day I was working on a project in Unity and I had to deal with angles again, after I finished the code and ran the game I understood that I somehow messed up a conversion because the result was so funny. Then I remembered that I had problems with dealing with angles before too. Then I thought why not just make an angles library for myself?, so I created a struct called Angle and started working on it. As I worked on, I realized that I was overwriting it and adding features that I didn't need, so I said let's turn this into its own project and put a hold onto the Unity project. So I closed Unity and created a project called Angles, renamed the Angle struct to AngleFloat and added AngleInt and AngleDouble structs too. Then I decided to implement the IAngle interface and added it too. I designed and changed the designs that I didn't like and coded the project like this for around a week, and now it's finally done and I'm relieved.

#### What makes this library different than other alternatives?

To be honest, I didn't look into other libraries, if I did so I would probably not have coded this and just used one of them and moved on. So for that reason, I can't tell. However I can tell that my motivation and aim while working on Angles.Net was to make it as flexible and easy to use as possible such that I made 4 to 5 overloads in average for each method.


[Go Back To Appendix](#appendix)

## Authors

- [@XeniaPhe](https://github.com/XeniaPhe)

