namespace AwesomeFigures.Abstractions.Points;

public interface IPoint
{
    double X { get; init; }
    double Y { get; init; }

    double DistanceTo(IPoint point);
}