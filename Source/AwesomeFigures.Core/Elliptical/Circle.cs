using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Abstractions.Visitors;

namespace AwesomeFigures.Core.Elliptical;

public class Circle<TPoint>
    : ICircle<TPoint>
    where TPoint : IPoint
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Radius { get; init; }

    public double Accept(IAreaCalculatorVisitor<TPoint> visitor) =>
        visitor.CalculateForCircle(this);
}