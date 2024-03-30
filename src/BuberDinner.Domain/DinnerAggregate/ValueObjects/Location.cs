
using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public float Latitude { get; private set; }
    public float Longitude { get; private set; }

#pragma warning disable CS8618
    private Location() { }
#pragma warning restore CS8618

    private Location(string name, string address, float latitude, float longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static Location Create(string name, string address, float latitude, float longitude)
    {
        return new(name, address, latitude, longitude);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}