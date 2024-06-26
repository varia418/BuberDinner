
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;

public sealed class BillId : ValueObject
{
    public Guid Value { get; }

    private BillId(Guid value)
    {
        Value = value;
    }
    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static BillId Create(Guid billId)
    {
        return new(billId);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}