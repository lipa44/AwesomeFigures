using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Angular;

namespace AwesomeFigures.Core.Validators;

public interface ITriangleValidator<TPoint>
    where TPoint : IPoint
{
    void ValidateAndThrow(Triangle<TPoint> triangle);
}