using Manero.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Manero.Models.Interfaces;

public interface IAddAddressViewModel
{
	[Display(Name = "Title (optional)")]
	string? Title { get; set; }

	[Display(Name = "StreetName *")]
	[Required(ErrorMessage = "StreetName is required")]
	string StreetName { get; set; }

	[Display(Name = "PostalCode *")]
	[Required(ErrorMessage = "PostalCode is required")]
	[DataType(DataType.PostalCode)]
	string PostalCode { get; set; }

	[Display(Name = "City *")]
	[Required(ErrorMessage = "City is required")]
	string City { get; set; }
}
