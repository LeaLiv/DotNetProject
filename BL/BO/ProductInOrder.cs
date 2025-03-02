
namespace BO;

public class ProductInOrder
{
    public int ProductId;
    public string ProductName;
    public double BasePrice;
    public int QuantityInOrder;
    public List<SaleInProduct>? SalesInProduct;
    public double FinalPrice;
    public override string ToString() => this.ToStringProperty();
}
