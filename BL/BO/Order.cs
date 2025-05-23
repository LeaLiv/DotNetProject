
namespace BO;

public class Order
{
    public bool IsCustomerMemberClub;
    public List<ProductInOrder> ProductsInOrder;
    public double Price;
    public Order(bool isClub, List<ProductInOrder>? products, double finalyPrice)
    {
        this.IsCustomerMemberClub = isClub;
        this.ProductsInOrder = products;
        this.Price = finalyPrice;
    }
    public override string ToString() => this.ToStringProperty();
}
