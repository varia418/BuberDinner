using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvide : IDateTimeProvider
{
    public DateTimeProvide()
    {
    }

    public DateTime UtcNow => DateTime.UtcNow;
}