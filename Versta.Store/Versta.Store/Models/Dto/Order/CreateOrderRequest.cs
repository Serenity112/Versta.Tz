using System.ComponentModel.DataAnnotations;

namespace Versta.Store.Models.Dto.Order;

public class CreateOrderRequest
{
    [Required]
    public string SenderCity { get; init; }

    [Required]
    public string SenderAddress { get; init; }

    [Required]
    public string ReceiverCity { get; init; }

    [Required]
    public string ReceiverAddress { get; init; }

    [Required]
    public DateTimeOffset PickupDate { get; init; }

    [Required]
    [Range(1, 60)]
    public double Weight { get; init; }
}
