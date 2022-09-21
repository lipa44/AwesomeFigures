using AwesomeFigures.Abstractions.Figures;
using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Angular;
using AwesomeFigures.Core.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace AwesomeFigures.Validators;

public class TriangleValidator<TPoint>
    : AbstractValidator<ITriangle<TPoint>>,
        ITriangleValidator<TPoint>
    where TPoint : IPoint
{
    public TriangleValidator()
    {
        RuleFor(triangle => triangle.Points)
            .NotNull()
            .WithMessage("Points in triangle cannot be null");

        RuleFor(triangle => triangle.Points)
            .Must(x => x.Count == 3)
            .WithMessage("Triangle must have 3 points");

        RuleFor(x => x)
            .Must(IsTriangleCorrect)
            .WithMessage("Triangle is not correct")
            .When(x => x.Points.Count == 3);
    }

    private bool IsTriangleCorrect(ITriangle<TPoint> triangle)
    {
        var points = triangle.Points;

        if (points.Count != 3) return false;

        var lengths = points
            .Select((cur, i) => cur.DistanceTo(points[(i + 1) % points.Count]))
            .ToList();

        return CheckValidity(lengths[0], lengths[1], lengths[2]);
    }

    private bool CheckValidity(double a, double b, double c)
        => !(a + b <= c) && !(a + c <= b) && !(b + c <= a);

    public void ValidateAndThrow(ITriangle<TPoint> triangle)
    {
        ValidationResult? result = Validate(triangle);

        if (!result.IsValid)
            throw new ValidationException("Triangle is not valid", result.Errors);
    }
}