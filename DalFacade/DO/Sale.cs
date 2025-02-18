


namespace DO
{
    public record Sale
        (int SaleId,
        int ProductId,
        int? MinAmount = 0,
        double? SalePrice = 0,
        bool? ClubSale = true,
        DateTime? StartSale = null,
        DateTime? FinishSale = null)
    {
        //public static int index = 100;

        public Sale() : this(-1,-1)
        { }
    }
}
