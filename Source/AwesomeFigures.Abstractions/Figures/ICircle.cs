using AwesomeFigures.Abstractions.Figures.General;
using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Abstractions.Figures;

public interface ICircle<TPoint>
    : IEllipse<TPoint>
    where TPoint : IPoint
{
    double Radius { get; }

    double IEllipse<TPoint>.RadiusX => Radius;
    double IEllipse<TPoint>.RadiusY => Radius;
}