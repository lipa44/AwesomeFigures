using System;
using AwesomeFigures.Core.Elliptical;
using AwesomeFigures.Core.Points;
using FluentAssertions;
using Xunit;

namespace AwesomeFigures.UnitTests;

public class FigureInvariantTests
{
    [Fact]
    public void InvalidCircleRadius_ThrowsException()
    {
        // Arrange
        var expectedException = new ArgumentException($"{nameof(Circle<MathPoint>)}'s radius must be positive",
            nameof(Circle<MathPoint>.Radius));

        // Act
        var actualException = Assert.Throws<ArgumentException>(() => new Circle<MathPoint>(-1));

        // Assert
        expectedException.ParamName.Should().BeEquivalentTo(actualException.ParamName);
        expectedException.Message.Should().BeEquivalentTo(actualException.Message);
    }
}