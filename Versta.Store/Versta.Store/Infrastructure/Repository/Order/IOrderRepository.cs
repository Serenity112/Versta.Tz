using Versta.Store.Infrastructure.Repository.Common;

namespace Versta.Store.Infrastructure.Repository.Order;

using Order = Models.Domain.Order;

public interface IOrderRepository : IRepositoryBase<Order>
{
    Task<IList<Order>> GetOrders();
}
