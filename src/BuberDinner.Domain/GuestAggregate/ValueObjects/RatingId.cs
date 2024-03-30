
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class RatingId : ValueObject
{
    public Guid Value { get; }

    private RatingId(Guid value)
    {
        Value = value;
    }
    
    public static RatingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static RatingId Create(Guid ratingId)
    {
        return new(ratingId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}