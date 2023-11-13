using Manero.Contexts;
using Manero.Models.Entities;
namespace Manero.Repositories;

public class ProductReviewRepository : Repo<ProductReviewEntity>
{
    public ProductReviewRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
