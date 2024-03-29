using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId : ValueObject
{
    public Guid Value { get; }
    private DinnerId(Guid value)
    {
        Value = value;
    }
    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static DinnerId Create(Guid dinnerId)
    {
        return new(dinnerId);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}