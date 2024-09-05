namespace FiguresMathLibrary.Tests;

public class TriangleTests
{
    [Fact]
    public void CalculatesAreaCorrectly()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 5);

        // Act
        double area = triangle.Area;

        // Assert
        Assert.Equal(6, area, 5);
    }

    [Fact]
    public void ThrowsArgumentExceptionWhenInvalidSides()
    {
        // Act & Assert
        Assert.ThrowsAny<ArgumentException>(() => new Triangle(1, 2, 10));
    }

    [Fact]
    public void ChecksRightTriangle()
    {
        // Arrange
        var triangle1 = new Triangle(3, 4, 5);
        var triangle2 = new Triangle(3, 4, 6);

        // Act
        bool isRight1 = triangle1.IsRightTriangle();
        bool isRight2 = triangle2.IsRightTriangle();

        // Assert
        Assert.True(isRight1);
        Assert.False(isRight2);
    }
}