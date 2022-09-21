using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Abstractions.Figures.General;

public interface IPolygon<TPoint>
    : IAreaComputational<TPoint>
    where TPoint : IPoint
{
    // will be better to use LinkedList<TPoint> from math POV, but... who wants to use LinkedList in math library?)
    IReadOnlyList<TPoint> Points { get; }
}