using AwesomeFigures.Abstractions.Figures.General;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Abstractions.Visitors;

namespace AwesomeFigures.Core.Visitors;

public class AreaCalculatorVisitor<TPoint>
    : IAreaCalculatorVisitor<TPoint>
    where TPoint : IPoint
{
    public double CalculateForCircle(IEllipse<TPoint> ellipse)
        => Math.PI * ellipse.RadiusX * ellipse.RadiusY;

    public double CalculateForPolygon(IPolygon<TPoint> polygon)
    {
        double area = 0.0;

        var points = polygon.GetPoints();
        var j = points.Count - 1;

        for (var i = 0; i < points.Count; j = i, i++)
        {
            area += (points[j].X + points[i].X) * (points[j].Y - points[i].Y);
        }

        return area / 2;
    }
}