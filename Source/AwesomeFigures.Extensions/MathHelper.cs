using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Extensions;

public static class MathHelper<TPoint>
    where TPoint : IPoint
{
    private const double Epsilon = 0.0001;

    public static bool IsTriangleRectangular(ITriangle<TPoint> triangle)
    {
        var points = triangle.Points;

        var lengths = points
            .Select((cur, i) =>
                (point: cur, length: cur.DistanceTo(points[(i + 1) % points.Count])))
            .OrderByDescending(x => x.length)
            .ToList();

        var hypotenuse = lengths.First();
        var cathetusesSquareSum = lengths.Skip(1).Take(2).Sum(x => Math.Pow(x.length, 2));

        return Math.Abs(Math.Pow(hypotenuse.length, 2) - cathetusesSquareSum) < Epsilon;
    }
}