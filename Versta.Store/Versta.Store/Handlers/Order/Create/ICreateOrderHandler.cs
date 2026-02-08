using Versta.Store.Models.Results;
using Versta.Store.Models.Results.Order;

namespace Versta.Store.Handlers.Order.Create;

using Order = Models.Domain.Order;

public interface ICreateOrderHandler
{
    Task<Result<CreatedOrder>> Handle(Order order);
}
