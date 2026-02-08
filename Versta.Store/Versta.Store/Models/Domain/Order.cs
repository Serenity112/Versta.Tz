using Versta.Store.Models.Domain.Common;

namespace Versta.Store.Models.Domain;

public class Order : BaseEntity
{
    public Guid OrderId { get; init; }

    public AddressInfo SenderAddressInfo { get; init; }

    public AddressInfo ReceiverAddressInfo { get; init; }

    public DateTimeOffset PickupDate { get; init; }

    public double Weight { get; init; }

    public Order(
        Guid orderId,
        AddressInfo senderAddressInfo,
        AddressInfo receiverAddressInfo,
        DateTimeOffset pickupDate,
        double weight)
    {
        OrderId = orderId;
        SenderAddressInfo = senderAddressInfo;
        ReceiverAddressInfo = receiverAddressInfo;
        PickupDate = pickupDate;
        Weight = weight;
    }

    private Order()
    {
    }
}
