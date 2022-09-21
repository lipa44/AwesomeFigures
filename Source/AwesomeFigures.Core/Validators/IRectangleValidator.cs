using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Angular;

namespace AwesomeFigures.Core.Validators;

public interface IRectangleValidator<TPoint>
    where TPoint : IPoint
{
    void ValidateAndThrow(IRectangle<TPoint> rectangle);
}