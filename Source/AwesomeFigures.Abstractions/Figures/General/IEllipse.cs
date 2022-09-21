using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Abstractions.Figures.General;

public interface IEllipse<TPoint>
    : IAreaComputational<TPoint>
    where TPoint : IPoint
{
    double RadiusX { get; }
    double RadiusY { get; }
}