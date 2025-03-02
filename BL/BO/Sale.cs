

namespace BO;

public class Sale
{
    public int SaleId;
    public int ProductId;
    public int? MinAmount;
    public double SalePrice;
    public bool? ClubSale;
    public DateTime? StartSale;
    public DateTime? FinishSale;

    public Sale(int saleId, int productId, int? minAmount, double salePrice, bool? clubSale, DateTime? startSale, DateTime? finishSale)
    {
        SaleId = saleId;
        ProductId = productId;
        MinAmount = minAmount;
        SalePrice = salePrice;
        ClubSale = clubSale;
        StartSale = startSale;
        FinishSale = finishSale;
    }

    public override string ToString() => this.ToStringProperty();
}
