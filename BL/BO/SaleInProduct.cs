
namespace BO;

public class SaleInProduct
{
    public int SaleId;
    public int? Quantity;
    public double Price;
    public bool? IsForClubMembers;
    public override string ToString() => this.ToStringProperty();
}
