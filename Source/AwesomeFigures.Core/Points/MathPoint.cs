using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Core.Points;

// A little bit of syntax sugar
public readonly record struct MathPoint(double X, double Y) : IPoint
{
    public double DistanceTo(IPoint point) =>
        Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));
}