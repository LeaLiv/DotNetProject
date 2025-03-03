
using BlApi;
using BO;



namespace BlImplementation;

internal class CustomerImplementation : ICustomer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Customer item)
    {
        return _dal.Customer.Create(item.Convert());
    }

    public void Delete(int id)
    {
        _dal.Customer.Delete(id);
    }
    //----------------------------------------------------
    public bool IsExist(int id)
    {
        BO.Customer c = Read(id);
        return true;
    }
    //----------------------------------------------------
    public BO.Customer? Read(int id)
    {
        return _dal.Customer.Read(id).Convert();
    }

    public BO.Customer? Read(Func<BO.Customer, bool> filter)
    {
        return _dal.Customer.Read(s => filter(s.Convert())).Convert();
    }

    public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
    { List<DO.Customer> lst;
        if (filter == null)
        {
            lst = _dal.Customer.ReadAll();
        }
        else
        {
            lst = _dal.Customer.ReadAll(s => filter(s.Convert()));
        }
            List<BO.Customer> lst2 = new List<Customer>();
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
