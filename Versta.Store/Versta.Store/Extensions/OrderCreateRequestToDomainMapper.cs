using Versta.Store.Models.Domain;
using Versta.Store.Models.Dto;
using Versta.Store.Models.Dto.Order;

namespace Versta.Store.Extensions;

public static class OrderCreateRequestToDomainMapper
{
    public static Order ToDomain(this CreateOrderRequest request)
    {
        return new Order(
            orderId: Guid.NewGuid(),
            senderAddressInfo: new AddressInfo(request.SenderCity, request.SenderAddress),
            receiverAddressInfo: new AddressInfo(request.ReceiverCity, request.ReceiverAddress),
            pickupDate: request.PickupDate,
            weight: request.Weight
        );
    }
}
