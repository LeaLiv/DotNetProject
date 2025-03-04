
using BlApi;
using BO;
using DO;



namespace BlImplementation;

internal class CustomerImplementation : ICustomer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Customer item)
    {
        try
        {
            return _dal.Customer.Create(item.Convert());
        }
        catch (DalExceptionIdAllreadyExist e)
        {
            throw new BLExceptionIdAllreadyExist(e.Message);
        }

    }

    public void Delete(int id)
    {
        try
        {
            _dal.Customer.Delete(id);
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }
    }
    //----------------------------------------------------
    public bool IsExist(int id)
    {
        DO.Customer c = _dal.Customer.ReadAll().FirstOrDefault(c => c.Id == id);
        if (c == null)
            return false;
        return true;
    }
    //----------------------------------------------------
    public BO.Customer? Read(int id)
    {
        try
        {
            return _dal.Customer.Read(id).Convert();
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }
    }

    public BO.Customer? Read(Func<BO.Customer, bool> filter)
    {
        try { return _dal.Customer.Read(s => filter(s.Convert())).Convert(); }
        catch (DalExceptionIdNotExist e) { throw new BLExceptionIdNotExist(e.Message); }

    }

    public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        List<DO.Customer> lst;
        if (filter == null)
        {
            lst = _dal.Customer.ReadAll();
        }
        else
        {
            lst = _dal.Customer.ReadAll(s => filter(s.Convert()));
        }
        List<BO.Customer> lst2 = new List<BO.Customer>();
        foreach (var item in lst)
        {
            lst2.Add(item.Convert());
        }
        return lst2;
    }

    public void Update(BO.Customer item)
    {
        _dal.Customer.Update(item.Convert());
    }
}
