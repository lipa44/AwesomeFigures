namespace AwesomeFigures.Abstractions.Points;

public interface IPoint
{
    public double X { get; init; }
    public double Y { get; init; }

    public double DistanceTo(IPoint point);
}