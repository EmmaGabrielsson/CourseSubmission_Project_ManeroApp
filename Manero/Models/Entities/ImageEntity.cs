namespace Manero.Models.Entities;

public class ImageEntity
{
    public Guid Id { get; set; }

    public string ImageName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public ICollection<ProductImageEntity> ProductImages { get; set; } = new HashSet<ProductImageEntity>();

}
