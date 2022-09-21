using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Angular;
using AwesomeFigures.Core.Elliptical;

namespace AwesomeFigures.Core.Services;

public interface IFiguresService<TPoint>
    where TPoint : IPoint
{
    public Triangle<TPoint> CreateTriangle(List<TPoint> points);
    public Rectangle<TPoint> CreateRectangle(List<TPoint> points);
    public Circle<TPoint> CreateCircle(double radius);
}