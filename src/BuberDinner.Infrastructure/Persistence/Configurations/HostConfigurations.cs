using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class HostConfigurations : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostsTable(builder);
        ConfigureHostMenuIdsTable(builder);
        ConfigureHostDinnerIdsTable(builder);
    }

    private void ConfigureHostsTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value)
            );

        builder.Property(h => h.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            );
    }

    private void ConfigureHostMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.MenuIds, mib =>
        {
            mib.ToTable("HostMenuIds");

            mib.WithOwner().HasForeignKey(nameof(HostId));

            mib.HasKey("Id");

            mib.Property(mi => mi.Value)
                .HasColumnName(nameof(MenuId))
                .ValueGeneratedNever();
        });
    }

    private void ConfigureHostDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.DinnerIds, dib =>
        {
            dib.ToTable("HostDinnerIds");

            dib.WithOwner().HasForeignKey(nameof(HostId));

            dib.HasKey("Id");

            dib.Property(di => di.Value)
                .HasColumnName(nameof(DinnerId))
                .ValueGeneratedNever();
        });
    }
}