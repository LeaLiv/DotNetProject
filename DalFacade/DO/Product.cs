
namespace DO
{

    public record Product
        (int ProductId,
        string? ProductName = null,
        Category? category = null,
        double Price = 0.0,
        int? QuantityInStock = 0)
    {

        public Product() : this(-1)
        {

        }

    


    }
}
