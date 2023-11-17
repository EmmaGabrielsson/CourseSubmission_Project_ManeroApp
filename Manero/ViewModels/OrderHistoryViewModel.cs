namespace Manero.ViewModels
{
    public class OrderHistoryViewModel
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; } = null!;
        public DateTime UpdateStatusDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductArticleNumber { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }

        public List<OrderProductViewModel> Products { get; set; } = new List<OrderProductViewModel>();

    }

    public class OrderProductViewModel
    {
        public string ProductArticleNumber { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
