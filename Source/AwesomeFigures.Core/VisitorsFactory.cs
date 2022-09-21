using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Visitors;

namespace AwesomeFigures.Core;

// Just to be sure that we don't exactly know what is the type of the figure
public static class VisitorsFactory<T, TPoint>
    where T : IAreaComputational<TPoint>
    where TPoint : IPoint
{
    public static double GetArea(T source)
        => source.Accept(new AreaCalculatorVisitor<TPoint>());
}