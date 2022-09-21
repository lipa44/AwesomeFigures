using System.Collections.Generic;
using AwesomeFigures.Core.Points;
using AwesomeFigures.Core.Services;
using AwesomeFigures.Extensions;
using AwesomeFigures.Validators;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace AwesomeFigures.UnitTests;

public class FigureInvariantTests
{
    private readonly IFiguresService<MathPoint> _figuresService = new FiguresService<MathPoint>(
        new TriangleValidator<MathPoint>(),
        new RectangleValidator<MathPoint>(),
        new CircleValidator<MathPoint>());

    [Fact]
    public void InvalidCircleRadius_ThrowsException()
    {
        // Arrange
        var expectedException = new ValidationException("Circle is not valid");

        // Act
        var actualException = Assert.Throws<ValidationException>(() => _figuresService.CreateCircle(-1));

        // Assert
        expectedException.Message.Should().BeEquivalentTo(actualException.Message);
    }

    [Fact]
    public void InvalidTriangle_WrongPointsCount_ThrowsException()
    {
        // Arrange
        var expectedException = new ValidationException("Triangle is not valid");

        // Act
        var actualException = Assert.Throws<ValidationException>(() => _figuresService.CreateTriangle(
            new List<MathPoint>
            {
                new MathPoint(),
                new MathPoint(),
            }));

        // Assert
        expectedException.Message.Should().BeEquivalentTo(actualException.Message);
    }

    [Fact]
    public void InvalidRectangle_WrongPointsCount_ThrowsException()
    {
        // Arrange
        var expectedException = new ValidationException("Rectangle is not valid");

        // Act
        var actualException = Assert.Throws<ValidationException>(() => _figuresService.CreateRectangle(
            new List<MathPoint>
            {
                new MathPoint(),
                new MathPoint(),
            }));

        // Assert
        expectedException.Message.Should().BeEquivalentTo(actualException.Message);
    }

    [Theory]
    [InlineData(0, 3, 4, 0, 0, 0, true)]
    [InlineData(0, 0, 5, 0, 2, 2, false)]
    public void IsTriangleRegular_WithValidTriangle(double x1, double y1, double x2, double y2, double x3, double y3,
        bool expectedResult)
    {
        // Arrange
        var triangle = _figuresService.CreateTriangle(new List<MathPoint>
        {
            new MathPoint(x1, y1),
            new MathPoint(x2, y2),
            new MathPoint(x3, y3),
        });

        // Act
        var actual = MathHelper<MathPoint>.IsTriangleRectangular(triangle);

        // Assert
        actual.Should().Be(expectedResult);
    }
}