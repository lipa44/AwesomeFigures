using AwesomeFigures.Abstractions.Figures.General;
using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Abstractions.Figures;

public interface IRectangle<TPoint>
    : IPolygon<TPoint>
    where TPoint : IPoint
{
}