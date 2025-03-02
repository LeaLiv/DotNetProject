
namespace BO;

public class Order
{
    public bool IsCustomerMemberClub;
    public List<ProductInOrder> ProductsInOrder;
    public double Price;
    public override string ToString() => this.ToStringProperty();
}
