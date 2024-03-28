using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuRating : ValueObject
{
    public float Value { get; }
    public int NumRatings { get; }
    private MenuRating(float value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }

    private MenuRating()
    {
    }
    public static MenuRating Create(float value, int numRatings)
    {
        return new(value, numRatings);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumRatings;
    }
}