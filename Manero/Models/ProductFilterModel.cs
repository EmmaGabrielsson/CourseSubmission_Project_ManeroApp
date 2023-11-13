namespace Manero.Models;

public class ProductFilterModel
{
    public List<int> Colors { get; set; } = new List<int>();

    public List<int> Sizes { get; set; } = new List<int>();
    public string? Source { get; set; }

    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    public List<int> CategoryIds { get; set; } = new List<int>();
    public List<int> TagIds { get; set; } = new List<int>();
}
