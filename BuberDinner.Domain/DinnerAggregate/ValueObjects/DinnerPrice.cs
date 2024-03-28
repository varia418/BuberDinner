
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerPrice : ValueObject
{
    public int Amount { get; }
    public string Currency { get; }

#pragma warning disable CS8618
    private DinnerPrice() { }
#pragma warning restore CS8618

    private DinnerPrice(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static DinnerPrice Create(int amount, string currency)
    {
        return new(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}