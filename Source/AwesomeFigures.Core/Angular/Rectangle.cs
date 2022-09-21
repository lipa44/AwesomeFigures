using AwesomeFigures.Abstractions.Figures.General;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Abstractions.Visitors;

namespace AwesomeFigures.Core.Angular;

public class Rectangle<TPoint>
    : IPolygon<TPoint>
    where TPoint : IPoint
{
    private readonly List<TPoint> _points;

    public Rectangle(List<TPoint> points)
    {
        ArgumentNullException.ThrowIfNull(points);

        if (points.Count != 4)
            throw new ArgumentException($"{nameof(Rectangle<TPoint>)} must have 4 points");

        _points = points;
    }

    public double Accept(IAreaCalculatorVisitor<TPoint> visitor)
        => visitor.CalculateForPolygon(this);

    public IReadOnlyList<TPoint> GetPoints() => _points;
}