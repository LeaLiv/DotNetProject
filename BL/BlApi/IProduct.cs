


namespace BlApi;

public interface IProduct
{
    int Create(BO.Product item);
    BO.Product? Read(int id);
    List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null);
    void Update(BO.Product item);
    void Delete(int id);
    BO.Product? Read(Func<BO.Product, bool> filter);
    List<BO.SaleInProduct> GetAllSalesInProduct(int ProductId, bool? isMemberClub=false);
}
