using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Host
    {
        public static readonly HostId Id = HostId.Create(Guid.Parse("3f1c55d4-2aab-43d7-987d-b0fc907ffd1e"));
    }
}