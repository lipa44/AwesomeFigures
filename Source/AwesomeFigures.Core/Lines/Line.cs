using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Core.Lines;

public readonly struct Line<TPoint>
    where TPoint : IPoint
{
    public Line(TPoint a, TPoint b)
    {
        A = a;
        B = b;
        Length = a.DistanceTo(b);
    }

    public TPoint A { get; init; }
    public TPoint B { get; init; }
    public double Length { get; init; }
}