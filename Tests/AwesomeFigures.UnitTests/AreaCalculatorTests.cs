using System;
using System.Collections.Generic;
using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Core;
using AwesomeFigures.Core.Angular;
using AwesomeFigures.Core.Elliptical;
using AwesomeFigures.Core.Points;
using AwesomeFigures.Core.Services;
using AwesomeFigures.Core.Visitors;
using AwesomeFigures.Validators;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace AwesomeFigures.UnitTests;

public class AreaCalculatorTests
{
    private const double Precision = 0.01;

    [Theory]
    [InlineData(0, 0, 0, 1, 1, 1, 0.5)]
    [InlineData(0, 0, 0, 2, 2, 2, 2)]
    public void TriangleArea_ShouldBeCorrect(double x1, double y1, double x2, double y2, double x3, double y3,
        double expectedResult)
    {
        // Arrange
        var triangleValidatorMock = new Mock<TriangleValidator<MathPoint>>();
        triangleValidatorMock
            .Setup(x => x.Validate(It.IsAny<ValidationContext<ITriangle<MathPoint>>>()))
            .Returns(new ValidationResult());

        var figuresService = new FiguresService<MathPoint>(triangleValidatorMock.Object, null, null);

        var calculator = new AreaCalculatorVisitor<MathPoint>();
        var triangle = figuresService.CreateTriangle(new List<MathPoint>
        {
            new MathPoint(x1, y1),
            new MathPoint(x2, y2),
            new MathPoint(x3, y3),
        });

        // Act
        var triangleAreaV1 = triangle.Accept(calculator);
        // Just to be sure that we don't exactly know what is the type of the figure
        var triangleAreaV2 = VisitorsFactory<IAreaComputational<MathPoint>, MathPoint>.GetArea(triangle);

        // Assert
        triangleAreaV2.Should().BeApproximately(expectedResult, Precision);
        triangleAreaV2.Should().BeApproximately(triangleAreaV1, Precision);
    }

    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(10, Math.PI * 10 * 10)]
    public void CircleArea_ShouldBeCorrect(double radius, double expectedResult)
    {
        // Arrange
        var circleValidatorMock = new Mock<CircleValidator<MathPoint>>();
        circleValidatorMock
            .Setup(x => x.Validate(It.IsAny<ValidationContext<ICircle<MathPoint>>>()))
            .Returns(new ValidationResult());

        var figuresService = new FiguresService<MathPoint>(null, null, circleValidatorMock.Object);

        var calculator = new AreaCalculatorVisitor<MathPoint>();
        var circle = figuresService.CreateCircle(radius);

        // Act
        var circleAreaV1 = circle.Accept(calculator);
        // Just to be sure that we don't exactly know what is the type of the figure
        var circleAreaV2 = VisitorsFactory<IAreaComputational<MathPoint>, MathPoint>.GetArea(circle);

        // Assert
        circleAreaV1.Should().BeApproximately(expectedResult, Precision);
        circleAreaV2.Should().BeApproximately(circleAreaV1, Precision);
    }

    [Theory]
    [InlineData(0, 0, 0, 1, 1, 1, 1, 0, 1)]
    [InlineData(0, 0, 0, 2, 2, 2, 2, 0, 4)]
    public void RectangleArea_ShouldBeCorrect(double x1, double y1, double x2, double y2, double x3, double y3,
        double x4, double y4, double expectedResult)
    {
        // Arrange
        var rectangleValidatorMock = new Mock<RectangleValidator<MathPoint>>();
        rectangleValidatorMock
            .Setup(x => x.Validate(It.IsAny<ValidationContext<IRectangle<MathPoint>>>()))
            .Returns(new ValidationResult());

        var figuresService = new FiguresService<MathPoint>(null, rectangleValidatorMock.Object, null);

        var calculator = new AreaCalculatorVisitor<MathPoint>();
        var rectangle = figuresService.CreateRectangle(new List<MathPoint>
        {
            new MathPoint(x1, y1),
            new MathPoint(x2, y2),
            new MathPoint(x3, y3),
            new MathPoint(x4, y4),
        });

        // Act
        var rectangleAreaV1 = rectangle.Accept(calculator);
        // Just to be sure that we don't exactly know what is the type of the figure
        var triangleAreaV2 = VisitorsFactory<IAreaComputational<MathPoint>, MathPoint>.GetArea(rectangle);

        // Assert
        rectangleAreaV1.Should().BeApproximately(expectedResult, Precision);
        triangleAreaV2.Should().BeApproximately(rectangleAreaV1, Precision);
    }
}