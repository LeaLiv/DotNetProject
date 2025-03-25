
using DalApi;
using DO;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer item)
    {
        List
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Customer? Read(int id)
    {
        throw new NotImplementedException();
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        throw new NotImplementedException();
    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer item)
    {
        throw new NotImplementedException();
    }
}
