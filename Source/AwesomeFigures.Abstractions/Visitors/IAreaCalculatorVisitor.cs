using AwesomeFigures.Abstractions.Figures.General;
using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Abstractions.Visitors;

// I've decided to use a visitor pattern because it's more powerful and flexible rather then using
// a stupid generic service, which may come to mind first.
public interface IAreaCalculatorVisitor<TPoint>
    where TPoint : IPoint
{
    double CalculateForCircle(IEllipse<TPoint> ellipse);
    double CalculateForPolygon(IPolygon<TPoint> polygon);
}