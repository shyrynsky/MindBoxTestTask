using FiguresMathLibrary.Exceptions;

namespace FiguresMathLibrary;

/// <summary>
/// A <see cref="Circle"/> instance represents a geometric circle and can be used to calculate its parameters
/// </summary>
public class Circle : Figure
{
    /// <summary>
    /// Radius of the circle
    /// </summary>
    public double Radius { get; }
    
    /// <summary>
    /// Creates an instance of the <see cref="Circle"/> using radius
    /// </summary>
    /// <param name="radius">radius of the circle</param>
    /// <exception cref="ArgumentException">If the arguments are invalid</exception>
    public Circle(double radius)
    {
        if (radius <= 0)
            throw new NotPositiveRadiusException();

        Radius = radius;
    }

    protected sealed override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}