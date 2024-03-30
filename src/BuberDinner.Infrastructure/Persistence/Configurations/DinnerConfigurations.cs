using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnersTable(builder);
        ConfigureDinnerReservationsTable(builder);
    }

    private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value)
            );

        builder.OwnsOne(d => d.Price);

        builder.Property(d => d.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );

        builder.Property(d => d.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value)
            );

        builder.OwnsOne(d => d.Location);
    }

    private void ConfigureDinnerReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(d => d.Reservations, rb =>
        {
            rb.ToTable("DinnerReservations");

            rb.WithOwner().HasForeignKey("DinnerId");

            rb.HasKey("Id", "DinnerId");

            rb.Property(d => d.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ReservationId.Create(value)
                );
        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}