using Versta.Store.Infrastructure.Repository.Order;
using Versta.Store.Models.Results;

namespace Versta.Store.Handlers.Order.History;

using Order = Models.Domain.Order;

public class OrderHistoryHandler(IOrderRepository orderRepository) : IOrderHistoryHandler
{
    public async Task<Result<IList<Order>>> Handle()
    {
        var orders = await orderRepository.GetOrders();

        return Result<IList<Order>>.Success(orders);
    }
}
