using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Angular;
using AwesomeFigures.Core.Validators;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace AwesomeFigures.Validators;

public class RectangleValidator<TPoint>
    : AbstractValidator<IRectangle<TPoint>>,
        IRectangleValidator<TPoint>
    where TPoint : IPoint
{
    public RectangleValidator()
    {
        RuleFor(rectangle => rectangle.Points)
            .NotNull()
            .WithMessage("Points in rectangle cannot be null");

        RuleFor(rectangle => rectangle.Points)
            .Must(points => points.Count >= 3)
            .WithMessage("Rectangle must have at least 3 points");
    }

    public void ValidateAndThrow(IRectangle<TPoint> rectangle)
    {
        ValidationResult? result = Validate(rectangle);

        if (!result.IsValid)
            throw new ValidationException("Rectangle is not valid", result.Errors);
    }

}