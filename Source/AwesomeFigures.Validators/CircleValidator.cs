using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Elliptical;
using AwesomeFigures.Core.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace AwesomeFigures.Validators;

public class CircleValidator<TPoint>
    : AbstractValidator<Circle<TPoint>>, 
        ICircleValidator<TPoint>
    where TPoint : IPoint
{
    public CircleValidator()
    {
        RuleFor(circle => circle.Radius)
            .GreaterThan(0)
            .WithMessage($"{nameof(Circle<TPoint>)}'s radius must be positive");
    }

    public void ValidateAndThrow(Circle<TPoint> circle)
    {
        ValidationResult? result = Validate(circle);

        if (!result.IsValid)
            throw new ValidationException("Circle is not valid", result.Errors);
    }
}