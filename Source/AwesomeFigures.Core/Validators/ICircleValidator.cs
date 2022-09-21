using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Core.Validators;

public interface ICircleValidator<TPoint>
    where TPoint : IPoint
{
    void ValidateAndThrow(ICircle<TPoint> circle);
}