using Versta.Store.Models.Results;

namespace Versta.Store.Handlers.Order.History;

using Order = Models.Domain.Order;

public interface IOrderHistoryHandler
{
    Task<Result<IList<Order>>> Handle();
}
