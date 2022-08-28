<p align="center" width="100%">
    <img src="src/Angles.NetLogo.png" width="350" height="275" />
</p>


# Angles.Net

Angles.Net library is dedicated to easily and quickly handling and manipulating different types and units of angles.
It allows conversions and operations between different units and representations of angles to ease the job of a programmer and reduce redundancy while dealing with angles.

## Authors

- [@XeniaPhe](https://github.com/XeniaPhe)


## Installation

You can install Angles.Net by opening the Package Manager Console in the Visual Studio from View/Other Windows/Package Manager Console and typing in one of the commands :

```bash
 Install-Package Angles.Net -Version 1.0.2
 dotnet add package Angles.Net --version 1.0.2
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





## API Reference

### Data structures

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


### Public const and static fields

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
* Sin, Cos, Tan, Cot, Sec, Csc, Sinh, Cosh, Tanh, Coth, Sech, Csch : float
&nbsp;
These are the trigonometric properties and they're straightforward and thus they require no explanation
* IsPositiveAngle, IsNegativeAngle, IsZeroAngle : bool
* IsAcuteAngle, IsRightAngle, IsObtuseAngle, IsStraightAngle, IsReflexAngle, IsCompleteAngle : bool
&nbsp;
These properties can be used to query the general location of the angle quickly
* IsNormalizedAngleAcuteAngle, IsNormalizedAngleRightAngle, IsNormalizedAngleObtuseAngle, IsNormalizedAngleStraightAngle, IsNormalizedAngleReflexAngle, IsNormalizedAngleCompleteAngle : bool
&nbsp;
These properties first normalize the angle between 0 and 1 turn before checking it (does not alter the original angle and unit)
* Quadrant : int
&nbsp;
Returns the quadrant (1,2,3,or 4) that the angle is within

**These properties belong to AngleFloat struct, and they're identical to the other two struct's except for that the properties which return float in AngleFloat return double in AngleDouble and int in AngleInt.**
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

#### Addition/Subtraction Operators

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

#### Multiplication and Division Operators

* *(AngleDouble, double) : AngleDouble
* *(double, AngleDouble) : AngleDouble

These operators are used to multiply an angle by a number, there exist AngleFloat and AngleInt equivalents of them as well. They return angle objects.

* /(AngleFloat, float) : AngleFloat

This operator is used to divide an angle by a number, there also exist AngleDouble and AngleInt equivalents of this operator. They return angle objects.

#### Modulo Operator

* %(AngleFloat, float) : AngleFloat

This operator is used to calculate the remainder of an angle when divided by a number, there exist AngleInt and AngleDouble equivalents as well. They return angle objects.


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

### Public Methods

* SetAngle(double angle,AngleUnit? unit = null) : AngleDouble
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








