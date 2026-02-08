using Versta.Store.Models.Domain;
using Versta.Store.Models.Dto.Order;

namespace Versta.Store.Extensions;

public static class ToOrderHistoryDtoMapper
{
    extension(IList<Order> orders)
    {
        public OrderHistoryResponse ToOrderHistoryResponse()
        {
            return new OrderHistoryResponse()
            {
                Orders = orders.Select(order => new OrderHistoryItem()
                {
                    OrderId = order.OrderId,
                    CreatedAt = order.CreatedAt,
                    SenderCity = order.SenderAddressInfo.City,
                    SenderAddress = order.SenderAddressInfo.Address,
                    ReceiverCity = order.ReceiverAddressInfo.City,
                    ReceiverAddress = order.ReceiverAddressInfo.Address,
                    PickupDate = order.PickupDate,
                    Weight = order.Weight
                }).ToList()
            };
        }
    }
}
