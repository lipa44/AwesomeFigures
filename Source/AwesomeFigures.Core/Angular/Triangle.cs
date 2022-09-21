using AwesomeFigures.Abstractions.Figures.General;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Abstractions.Visitors;

namespace AwesomeFigures.Core.Angular;

public class Triangle<TPoint>
    : IPolygon<TPoint>
    where TPoint : IPoint
{
    private readonly List<TPoint> _points;

    public Triangle(List<TPoint> points)
    {
        ArgumentNullException.ThrowIfNull(points);

        if (points.Count != 3)
            throw new ArgumentException($"{nameof(Triangle<TPoint>)} must have 3 points");

        _points = points;
    }

    public double Accept(IAreaCalculatorVisitor<TPoint> visitor)
        => visitor.CalculateForPolygon(this);

    public IReadOnlyList<TPoint> GetPoints() => _points;
}