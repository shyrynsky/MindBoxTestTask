namespace FiguresMathLibrary.Tests;

public class CircleTests
{
    [Fact]
    public void CalculatesAreaCorrectly()
    {
        // Arrange
        var circle = new Circle(5);

        // Act
        double area = circle.Area;

        // Assert
        Assert.Equal(Math.PI * 25, area, 5);
    }

    [Fact]
    public void ThrowsArgumentExceptionWhenInvalidRadius()
    {
        // Act & Assert
        Assert.ThrowsAny<ArgumentException>(() => new Circle(-5));
    }
}