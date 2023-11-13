using Manero.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero.Models.Interfaces;

public interface IUserAdressEntity
{
	[ForeignKey(nameof(User))]
	string UserId { get; set; }

	UserEntity User { get; set; }

	[Column(TypeName = "nvarchar(50)")]
	string? Title { get; set; }

	[ForeignKey(nameof(Adress))]
	int AdressId { get; set; }

	AdressEntity Adress { get; set; }
}
