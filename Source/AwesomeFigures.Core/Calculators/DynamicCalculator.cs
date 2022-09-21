namespace AwesomeFigures.Core.Calculators;

/// <summary>
/// Tried to support generic operations, but it was weird to use dynamic types (boxing/unboxing allocations) and etc.,
/// and non-double types for math operations in general.
/// </summary>
public static class DynamicCalculator
{
    private static T Add<T>(T? x, T? y) => (dynamic?)x + (dynamic?)y;

    private static T Multiply<T>(T x, T y) => (dynamic?)x * (dynamic?)y;

    private static T Divide<T>(T x, T y) => (dynamic?)x / (dynamic?)y;
}