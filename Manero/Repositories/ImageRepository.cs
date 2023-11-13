using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class ImageRepository : Repo<ImageEntity>
{
    public ImageRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
