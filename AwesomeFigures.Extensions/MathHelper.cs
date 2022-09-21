using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Angular;

namespace AwesomeFigures.Extensions;

public static class MathHelper<TPoint>
    where TPoint : IPoint
{
    public static bool IsTriangleRectangular(Triangle<TPoint> triangle)
    {
        var points = triangle.GetPoints();

        var lengths = points
            .Select((cur, i) =>
                (point: cur, length: cur.DistanceTo(points[(i + 1) % points.Count])))
            .OrderByDescending(x => x.length)
            .ToList();

        var hypotenuse = lengths.First();
        var cathetusesSquareSum = lengths.Skip(1).Take(2).Sum(x => Math.Pow(x.length, 2));

        return Math.Abs(Math.Pow(hypotenuse.length, 2) - cathetusesSquareSum) < 0.0001;
    }
}