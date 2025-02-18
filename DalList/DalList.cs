using DalApi;

namespace Dal;

public class DalList : IDal
{
    public ICustomer Customer =>new CustomerImplementation();

    public IProduct Product => new ProductImplemention();

    public ISale Sale => new SaleImplementation();
}
