using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Elliptical;

namespace AwesomeFigures.Core.Validators;

public interface ICircleValidator<TPoint>
    where TPoint : IPoint
{
    void ValidateAndThrow(Circle<TPoint> circle);
}