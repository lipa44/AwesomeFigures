using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Abstractions.Visitors;

namespace AwesomeFigures.Abstractions.Figures;

public interface IAreaComputational<TPoint>
    where TPoint : IPoint
{
    double Accept(IAreaCalculatorVisitor<TPoint> visitor);
}