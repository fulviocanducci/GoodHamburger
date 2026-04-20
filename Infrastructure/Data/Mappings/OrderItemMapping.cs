using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("orders_items");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        builder.Property(x => x.OrderId)
            .HasColumnName("orders_id")
            .IsRequired();
        builder.Property(x => x.MenuId)
            .HasColumnName("menus_id")
            .IsRequired();
        builder.Property(x => x.Value)
            .HasColumnName("value")
            .HasPrecision(5, 2)
            .IsRequired();
        builder.HasOne(x => x.Order)
            .WithMany(o => o.OrdersItems)
            .HasForeignKey(x => x.OrderId)
            .HasPrincipalKey(x => x.Id);
        builder.HasOne(x => x.Menu)
            .WithMany(x => x.OrdersItems)
            .HasForeignKey(x => x.MenuId)
            .HasPrincipalKey(x => x.Id);
    }
}