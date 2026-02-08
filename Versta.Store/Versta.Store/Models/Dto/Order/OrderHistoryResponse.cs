namespace Versta.Store.Models.Dto.Order;

public class OrderHistoryResponse
{
    public required IList<OrderHistoryItem> Orders { get; set; }
}

public class OrderHistoryItem
{
    public Guid OrderId { get; init; }

    public DateTimeOffset CreatedAt { get; init; }

    public required string SenderCity { get; init; }

    public required string SenderAddress { get; init; }

    public required string ReceiverCity { get; init; }

    public required string ReceiverAddress { get; init; }

    public DateTimeOffset PickupDate { get; init; }

    public double Weight { get; init; }
}
