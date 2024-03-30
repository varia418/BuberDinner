using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate;
using BuberDinner.Domain.GuestAggregate.Entities;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class GuestConfigurations : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConfigureGuestsTable(builder);
        ConfigureGuestUpcomingDinnerIdsTable(builder);
        ConfigureGuestPastDinnerIdsTable(builder);
        ConfigureGuestPendingDinnerIdsTable(builder);
        ConfigureGuestBillIdsTable(builder);
        ConfigureGuestRatingsTable(builder);
    }

    private void ConfigureGuestsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value)
            );

        builder.Property(g => g.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            );
    }

    private void ConfigureGuestUpcomingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.UpcomingDinnerIds, dib =>
        {
            dib.ToTable("GuestUpcomingDinnerIds");

            dib.WithOwner().HasForeignKey(nameof(GuestId));

            dib.HasKey("Id");

            dib.Property(d => d.Value)
                .HasColumnName(nameof(DinnerId))
                .ValueGeneratedNever();
        });
    }
    private void ConfigureGuestPastDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PastDinnerIds, dib =>
        {
            dib.ToTable("GuestPastDinnerIds");

            dib.WithOwner().HasForeignKey(nameof(GuestId));

            dib.HasKey("Id");

            dib.Property(d => d.Value)
                .HasColumnName(nameof(DinnerId))
                .ValueGeneratedNever();
        });
    }
    private void ConfigureGuestPendingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PendingDinnerIds, dib =>
        {
            dib.ToTable("GuestPendingDinnerIds");

            dib.WithOwner().HasForeignKey(nameof(GuestId));

            dib.HasKey("Id");

            dib.Property(d => d.Value)
                .HasColumnName(nameof(DinnerId))
                .ValueGeneratedNever();
        });
    }
    private void ConfigureGuestBillIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.BillIds, bib =>
        {
            bib.ToTable("GuestBillIds");

            bib.WithOwner().HasForeignKey(nameof(GuestId));

            bib.HasKey("Id");

            bib.Property(d => d.Value)
                .HasColumnName(nameof(DinnerId))
                .ValueGeneratedNever();
        });
    }

    private void ConfigureGuestRatingsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.Ratings, rb =>
        {
            rb.ToTable("GuestRatings");

            rb.WithOwner().HasForeignKey(nameof(GuestId));

            rb.HasKey(nameof(GuestRating.Id), nameof(GuestId));

            rb.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => RatingId.Create(value)
                );

            rb.Property(r => r.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );

            rb.Property(r => r.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value)
            );
        });
    }
}