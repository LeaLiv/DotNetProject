
using BlApi;
using BO;
using DO;


namespace BlImplementation;

internal class SaleImplementation : ISale
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Sale item)
    {
        try
        {
            return _dal.Sale.Create(item.Convert());
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
            _dal.Sale.Delete(id);
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }
    }

    public BO.Sale? Read(int id)
    {
        try
        {
            return _dal.Sale.Read(id).Convert();
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }
    }

    public BO.Sale? Read(Func<BO.Sale, bool> filter)
    {
        try
        {
            return _dal.Sale.Read(s => filter(s.Convert())).Convert();
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }
    }

    public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
    {
        List<DO.Sale> lst;
        if (filter != null)
            lst = _dal.Sale.ReadAll(p => filter(p.Convert()));
        else lst = _dal.Sale.ReadAll();
        List<BO.Sale> lst2 = new List<BO.Sale>();
        foreach (var item in lst)
        {
            lst2.Add(item.Convert());
        }
        return lst2;
    }

    public void Update(BO.Sale item)
    {
        _dal.Sale.Update(item.Convert());
    }
}
