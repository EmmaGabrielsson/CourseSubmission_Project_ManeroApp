using Manero.Contexts;
using Manero.Models.Entities;

namespace Manero.Repositories;

public class ColorRepository : Repo<ColorEntity>
{
    public ColorRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
