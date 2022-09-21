namespace AwesomeFigures.Abstractions.Lines;

public interface ILine
{
    public double A { get; init; }
    public double B { get; init; }
    public double Length { get; init; }
}