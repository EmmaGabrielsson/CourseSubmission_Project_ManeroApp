using System.Net.NetworkInformation;

namespace Manero.ViewModels;


public class PaymentMethodsViewModel
{
    public List<PaymentMethodViewModel> PaymentMethods { get; set; } = null!;
    // Add any other properties you need for the view
    public string UserName { get; set; } = null!; // Add a property for the user's name
    public int TotalPaymentMethods { get; set; } // Add a property for the total number of payment methods

}