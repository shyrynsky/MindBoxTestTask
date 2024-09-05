namespace FiguresMathLibrary;

/// <summary>
///     The base class of figures in the <see cref="FiguresMathLibrary"/>
/// </summary>
public abstract class Figure
{
    private readonly object _lockObj = new();

    private double? _area;

    protected abstract double GetArea();

    /// <summary>
    /// <para>
    ///     Calculates or gets an already calculated area of the figure
    /// </para>
    ///<para>
    ///     If you are using this object in multiple threads, you should use
    ///     <see cref="GetAreaForConcurrent"/> to avoid multiple calculations.
    /// </para>
    /// </summary>
    public double Area
    {
        get
        {
            _area ??= GetArea();
            return (double)_area;
        }
    }

    /// <summary>
    /// <para>
    ///     Calculates or gets an already calculated area
    /// </para>
    ///<para>
    ///     If you are using this object in a single thread, you should use
    ///     <see cref="Area"/> for better performance.
    /// </para>
    /// </summary>
    /// <returns>The area of the figure</returns>
    public double GetAreaForConcurrent()
    {
        if (_area is null)
        {
            lock (_lockObj)
            {
                _area ??= GetArea();
            }
        }

        return (double)_area;
    }
}