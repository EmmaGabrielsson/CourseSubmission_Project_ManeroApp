using Manero.Contexts;
using Manero.Models.Entities;
using Manero.Models.Interfaces;

namespace Manero.Repositories;

public class ImageRepository : Repo<ImageEntity>, IImageRepository
{
    public ImageRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
