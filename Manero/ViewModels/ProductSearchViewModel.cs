using MailKit.Search;
using Manero.Models.Entities;

namespace Manero.ViewModels;

public class ProductSearchViewModel
{
    #region
    public ProductSearchViewModel()
    {
        SearchTerm = null!;
        Category = null!;
        Color = null!;
        Size = null!;
        Tags = new List<string>();
        SearchResults = new List<ProductEntity>();

    }
    #endregion 
    public string SearchTerm { get; set; }
    public string Category { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    public List<string> Tags { get; set; }
    public List<ProductEntity> SearchResults { get; set; }
}
