
namespace BO;

public class SaleInProduct
{
    public int SaleId;
    public int? Quantity;
    public double Price;
    public bool? IsForClubMembers;

    public SaleInProduct(int saleId, int? quantity, double salePrice, bool? clubSale)
    {
        SaleId = saleId;
        Quantity = quantity;
        Price = salePrice;
        IsForClubMembers = clubSale;
    }
    public SaleInProduct() { }

    public override string ToString() => this.ToStringProperty();
}
