using Versta.Store.Extensions;
using Versta.Store.Handlers.Order.Create;
using Versta.Store.Handlers.Order.History;
using Versta.Store.Models.Dto.Order;

namespace Versta.Store.Endpoints.Order;

public static class CreateOrderEndpoint
{
    extension(IEndpointRouteBuilder app)
    {
        public void MapCreateOrderEndpoint()
        {
            app.MapPost("/", async (CreateOrderRequest request, ICreateOrderHandler handler) =>
            {
                var createdOrderResult = await handler.Handle(order: request.ToDomain());

                if (!createdOrderResult.IsSuccess)
                {
                    return Results.Problem(
                        detail: createdOrderResult.Error!.Message,
                        statusCode: StatusCodes.Status400BadRequest);
                }

                return Results.Created("api/orders/", createdOrderResult.Data);
            });
        }

        public void MapOrderHistoryEndpoint()
        {
            app.MapGet("/", async (IOrderHistoryHandler handler) =>
            {
                var orderHistoryResult = await handler.Handle();

                if (!orderHistoryResult.IsSuccess)
                {
                    return Results.Problem(
                        detail: orderHistoryResult.Error!.Message,
                        statusCode: StatusCodes.Status400BadRequest);
                }

                return Results.Ok(orderHistoryResult.Data!.ToOrderHistoryResponse());
            });
        }
    }
}
