
using BlApi;
using BO;
using DO;

namespace BlImplementation;

public class ProductImplementation : IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Product item)
    {
        try
        {
            return _dal.Product.Create(item.Convert());
        }
        catch (DO.DalExceptionIdAllreadyExist e)
        {
            throw new BLExceptionIdAllreadyExist(e.Message);
        }
    }

    public void Delete(int id)
    {
        try
        {
            _dal.Product.Delete(id);
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }
    }

    public List<BO.SaleInProduct> GetAllSalesInProduct(int ProductId, bool? isMemberClub = false)
    {
        List<SaleInProduct> sales = new List<SaleInProduct>();
        if (isMemberClub == true)
        {
            sales = _dal.Sale.ReadAll(s => s.ProductId == ProductId).Select(s => new SaleInProduct { SaleId = s.SaleId, Price = (double)s.SalePrice, IsForClubMembers = s.ClubSale }).ToList();
        }
        else
            sales = _dal.Sale.ReadAll(s => s.ProductId == ProductId && s.ClubSale == false).Select(s => new SaleInProduct { SaleId = s.SaleId, Price = (double)s.SalePrice, IsForClubMembers = s.ClubSale }).ToList(); ;
        return sales;
    }

    public BO.Product? Read(int id)
    {
        try
        {
        return _dal.Product.Read(id).Convert();
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }
    }

    public BO.Product? Read(Func<BO.Product, bool> filter)
    {
        try
        {
            return _dal.Product.Read(p => filter(p.Convert())).Convert();
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }
    }

    public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        List<DO.Product> lst;
        if (filter == null)
            lst = _dal.Product.ReadAll();
        else
            lst = _dal.Product.ReadAll(p => filter(p.Convert()));
        List<BO.Product> lst2 = new List<BO.Product>();
        foreach (var item in lst)
        {
            lst2.Add(item.Convert());
        }
        return lst2;
    }

    public void Update(BO.Product item)
    {
        _dal.Product.Update(item.Convert());
    }
}
