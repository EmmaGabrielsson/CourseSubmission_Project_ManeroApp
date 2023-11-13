using System.ComponentModel.DataAnnotations;

namespace Manero.ViewModels;

public class PaymentMethodViewModel
{
    [Required]
    public string CardHolderName { get; set; } = null!;


    [Required]
    [RegularExpression(@"^\d{16}$", ErrorMessage = "Card Number must be 16 digits")]
    public string CardNumber
    {
        get => _cardNumber;
        set => _cardNumber = value?.Replace(" ", ""); // Remove spaces before setting
    }
    private string _cardNumber;

    [Required]
    [Range(1, 12, ErrorMessage = "Expiry Month must be between 1 and 12")]
    public int ExpiryMonth { get; set; }


    [Required]
    [Range(1000, 9999, ErrorMessage = "Expiry Year must be a four-digit number")]
    public int ExpiryYear { get; set; }

    [Required]
    [StringLength(3, MinimumLength = 3)]
    [RegularExpression("^[0-9]{3}$", ErrorMessage = "CVV must be a three-digit number")]
    public string CVV { get; set; } = null!;

    public Guid Id { get; set; }
    public Guid PaymentMethodId { get; set; }
}
