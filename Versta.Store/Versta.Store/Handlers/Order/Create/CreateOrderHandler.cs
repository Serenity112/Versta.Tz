using Versta.Store.Infrastructure.Repository.Order;
using Versta.Store.Models.Results;
using Versta.Store.Models.Results.Order;

namespace Versta.Store.Handlers.Order.Create;

using Order = Models.Domain.Order;

public class CreateOrderHandler(
    IOrderRepository orderRepository,
    ILogger<CreateOrderHandler> logger) : ICreateOrderHandler
{
    public async Task<Result<CreatedOrder>> Handle(Order order)
    {
        orderRepository.Add(order);
        await orderRepository.SaveChangesAsync();

        logger.LogInformation("Order with orderId {StoreId} created", order.OrderId);

        return Result<CreatedOrder>.Success(new CreatedOrder()
        {
            OrderId = order.OrderId
        });
    }
}
