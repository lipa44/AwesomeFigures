using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Abstractions.Visitors;

namespace AwesomeFigures.Core.Elliptical;

// Internal ctor to force using FiguresService
public class Circle<TPoint>
    : ICircle<TPoint>
    where TPoint : IPoint
{
    internal Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; init; }

    public double Accept(IAreaCalculatorVisitor<TPoint> visitor) =>
        visitor.CalculateForCircle(this);
}