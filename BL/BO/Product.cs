
namespace BO;

public class Product
{
    public int ProductId;
    public string? ProductName;
    public Category? category;
    public double Price;
    public int? QuantityInStock;
    public List<SaleInProduct> SalesInProduct;

    public Product(int productId, string? productName, Category? category, double price, int? quantityInStock)
    {
        ProductId = productId;
        ProductName = productName;
        category = category;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    public override string ToString() => this.ToStringProperty();

}
