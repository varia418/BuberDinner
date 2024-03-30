
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId : ValueObject
{
    public Guid Value { get; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static GuestId Create(Guid guestId)
    {
        return new(guestId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}