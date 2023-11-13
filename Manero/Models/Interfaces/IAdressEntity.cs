using Manero.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Interfaces;

public interface IAdressEntity
{
	int Id { get; set; }

	[Column(TypeName = "nvarchar(100)")]
	string StreetName { get; set; }

	[Column(TypeName = "char(5)")]
	string PostalCode { get; set; }

	[Column(TypeName = "nvarchar(100)")]
	string City { get; set; }

	ICollection<UserAdressEntity> Users { get; set; }
}
