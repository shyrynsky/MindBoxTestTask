using FiguresMathLibrary.Exceptions;

namespace FiguresMathLibrary;

/// <summary>
/// A <see cref="Triangle"/> instance represents a geometric triangle and can be used to calculate its parameters
/// </summary>
public class Triangle : Figure
{
    /// <summary>
    /// 1st side of the triangle
    /// </summary>
    public double SideA { get; }
    
    /// <summary>
    /// 2st side of the triangle
    /// </summary>
    public double SideB { get; }
    
    /// <summary>
    /// 3st side of the triangle
    /// </summary>
    public double SideC { get; }
    
    /// <summary>
    /// returns is the triangle valid 
    /// </summary>
    /// <param name="sideA">length of the 1st side</param>
    /// <param name="sideB">length of the 2st side</param>
    /// <param name="sideC">length of the 3st side</param>
    public static bool IsValidTriangle(double sideA, double sideB, double sideC)
    {
        return (sideA + sideB > sideC) &&
               (sideA + sideC > sideB) &&
               (sideB + sideC > sideA);
    }

    /// <summary>
    ///  Creates an instance of the <see cref="Triangle"/> using three sides
    /// </summary>
    /// <param name="sideA">length of the 1st side</param>
    /// <param name="sideB">length of the 2st side</param>
    /// <param name="sideC">length of the 3st side</param>
    /// <exception cref="ArgumentException">If the arguments are invalid</exception>
    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new NotPositiveFigureSideException();

        if (!IsValidTriangle(sideA, sideB, sideC))
            throw new InvalidFigureParamsException();

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        GetAreaFunc = GetAreaUsingThreeSides;
        IsRightTriangleFunc = IsRightTriangleUsingThreeSides;
    }

    protected readonly Func<bool> IsRightTriangleFunc;

    protected readonly Func<double> GetAreaFunc;

    private bool IsRightTriangleUsingThreeSides()
    {
        double[] sides = [SideA, SideB, SideC];
        Array.Sort(sides);
        return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 0.00001;
    }

    private double GetAreaUsingThreeSides()
    {
        double p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    /// <summary>
    ///  returns is the triangle right
    /// </summary>
    public bool IsRightTriangle()
    {
        return IsRightTriangleFunc();
    }

    protected sealed override double GetArea()
    {
        return GetAreaFunc();
    }
}