using Manero.Models.Entities;
using Manero.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Manero.ViewModels;

public class AddAddressViewModel : IAddAddressViewModel
{
    [Display(Name = "Title (optional)")]
    public string? Title { get; set; }

    [Display(Name = "StreetName *")]
    [Required(ErrorMessage = "StreetName is required")]
    public string StreetName { get; set; } = null!;

    [Display(Name = "PostalCode *")]
    [Required(ErrorMessage = "PostalCode is required")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "City *")]
    [Required(ErrorMessage = "City is required")]
    public string City { get; set; } = null!;


    public static implicit operator AdressEntity(AddAddressViewModel viewModel)
    {
        try
        {
            var address = new AdressEntity
            {
                StreetName = viewModel.StreetName,
                PostalCode = viewModel.PostalCode,
                City = viewModel.City
            };
            return address;
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
