using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Versta.Store.Models.Domain;

namespace Versta.Store.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .ComplexProperty(p => p.SenderAddressInfo);

        builder
            .ComplexProperty(p => p.ReceiverAddressInfo);
    }
}
