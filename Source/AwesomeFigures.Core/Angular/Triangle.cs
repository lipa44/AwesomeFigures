using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Abstractions.Visitors;

namespace AwesomeFigures.Core.Angular;

// Internal ctor to enforce using FiguresService
public class Triangle<TPoint>
    : ITriangle<TPoint>
    where TPoint : IPoint
{
    private readonly List<TPoint> _points;

    internal Triangle(List<TPoint> points)
    {
        _points = points;
    }

    public double Accept(IAreaCalculatorVisitor<TPoint> visitor)
        => visitor.CalculateForPolygon(this);

    public IReadOnlyList<TPoint> Points => _points;
}