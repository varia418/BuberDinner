
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;

public sealed class BillPrice : ValueObject
{
    public int Amount { get; }
    public string Currency { get; }

    private BillPrice(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static BillPrice Create(int amount, string currency)
    {
        return new(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}