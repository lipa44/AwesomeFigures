using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;

namespace AwesomeFigures.Core.Validators;

public interface IRectangleValidator<TPoint>
    where TPoint : IPoint
{
    void ValidateAndThrow(IRectangle<TPoint> rectangle);
}