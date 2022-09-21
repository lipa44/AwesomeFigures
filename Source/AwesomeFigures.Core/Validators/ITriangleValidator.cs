using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Core.Validators;

public interface ITriangleValidator<TPoint>
    where TPoint : IPoint
{
    void ValidateAndThrow(ITriangle<TPoint> triangle);
}