using AwesomeFigures.Abstractions.Points;
using AwesomeFigures.Core.Angular;
using AwesomeFigures.Core.Elliptical;
using AwesomeFigures.Core.Validators;

namespace AwesomeFigures.Core.Services;

public sealed class FiguresService<TPoint>
    : IFiguresService<TPoint>
    where TPoint : IPoint
{
    private readonly ITriangleValidator<TPoint> _triangleValidator;
    private readonly IRectangleValidator<TPoint> _rectangleValidator;
    private readonly ICircleValidator<TPoint> _circleValidator;

    public FiguresService(
        ITriangleValidator<TPoint> triangleValidator,
        IRectangleValidator<TPoint> rectangleValidator,
        ICircleValidator<TPoint> circleValidator)
    {
        _triangleValidator = triangleValidator;
        _rectangleValidator = rectangleValidator;
        _circleValidator = circleValidator;
    }

    public Triangle<TPoint> CreateTriangle(List<TPoint> points)
    {
        var triangle = new Triangle<TPoint>(points);
        _triangleValidator.ValidateAndThrow(triangle);

        return triangle;
    }

    public Rectangle<TPoint> CreateRectangle(List<TPoint> points)
    {
        var rectangle = new Rectangle<TPoint>(points);
        _rectangleValidator.ValidateAndThrow(rectangle);

        return rectangle;
    }

    public Circle<TPoint> CreateCircle(double radius)
    {
        var circle = new Circle<TPoint>(radius);
        _circleValidator.ValidateAndThrow(circle);

        return circle;
    }
}