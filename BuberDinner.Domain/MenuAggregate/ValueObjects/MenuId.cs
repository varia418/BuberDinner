using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }
    private MenuId(Guid value)
    {
        Value = value;
    }
    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static MenuId Create(Guid menuId)
    {
        return new(menuId);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}