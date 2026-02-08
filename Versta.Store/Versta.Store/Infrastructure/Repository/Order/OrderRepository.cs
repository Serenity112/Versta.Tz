using Microsoft.EntityFrameworkCore;
using Versta.Store.Infrastructure.Repository.Common;

namespace Versta.Store.Infrastructure.Repository.Order;

using Order = Models.Domain.Order;

public class OrderRepository(AppDbContext dbContext) : RepositoryBase<Order>(dbContext), IOrderRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<IList<Order>> GetOrders()
    {
        return await _dbContext.Orders.ToListAsync();
    }
}
