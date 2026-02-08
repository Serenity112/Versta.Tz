using Versta.Store.Exceptions.Domain;
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
        if (string.IsNullOrWhiteSpace(senderAddressInfo.City))
            throw new DomainException("Город отправления не должен быть пустым");

        if (string.IsNullOrWhiteSpace(senderAddressInfo.Address))
            throw new DomainException("Адрес отправления не должен быть пустым");

        if (string.IsNullOrWhiteSpace(receiverAddressInfo.City))
            throw new DomainException("Город получателя не должен быть пустым");

        if (string.IsNullOrWhiteSpace(receiverAddressInfo.Address))
            throw new DomainException("Адрес получателя не должен быть пустым");

        if (pickupDate <= DateTime.UtcNow)
            throw new DomainException("Время забора должно быть больше текущего");
        
        if (weight <= 0)
            throw new DomainException("Вес не может быть отрицательным");

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
