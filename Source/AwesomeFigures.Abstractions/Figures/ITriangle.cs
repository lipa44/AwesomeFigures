using AwesomeFigures.Abstractions.Figures.General;
using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Abstractions.Figures;

public interface ITriangle<TPoint>
    : IPolygon<TPoint>
    where TPoint : IPoint
{
}