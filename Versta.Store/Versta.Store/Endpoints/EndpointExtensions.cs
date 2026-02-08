using Versta.Store.Endpoints.Order;

namespace Versta.Store.Endpoints;

public static class EndpointExtensions
{
    extension(IEndpointRouteBuilder app)
    {
        public void MapApiEndpoints()
        {
            var group = app.MapGroup("/api/orders");

            group.MapCreateOrderEndpoint();
            group.MapOrderHistoryEndpoint();
        }
    }
}
