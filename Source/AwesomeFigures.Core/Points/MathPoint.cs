using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Core.Points;

public readonly struct MathPoint : IPoint
{
    public MathPoint(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; init; }
    public double Y { get; init; }

    public double DistanceTo(IPoint point) => 
        Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2));

    public override bool Equals(object? obj) => obj is MathPoint other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(X, Y);

    private bool Equals(MathPoint other) => X.Equals(other.X) && Y.Equals(other.Y);
}