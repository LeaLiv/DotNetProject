using DalApi;

namespace Dal;

internal sealed class DalList : IDal
{
    public ICustomer Customer => new CustomerImplementation();

    public IProduct Product => new ProductImplemention();

    public ISale Sale => new SaleImplementation();

    public static DalList Instance => new DalList();

    private DalList()
    {

    }


}

