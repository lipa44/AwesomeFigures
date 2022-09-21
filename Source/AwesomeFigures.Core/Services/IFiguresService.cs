using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Core.Services;

public interface IFiguresService<TPoint>
    where TPoint : IPoint
{
    public ITriangle<TPoint> CreateTriangle(List<TPoint> points);
    public IRectangle<TPoint> CreateRectangle(List<TPoint> points);
    public ICircle<TPoint> CreateCircle(double radius);
}