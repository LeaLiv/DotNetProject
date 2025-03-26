
using DalApi;


namespace Dal;

public class DalXml:IDal
{
    public ICustomer Customer => new CustomerImplementation();

    public IProduct Product => new ProductImplementation();

    public ISale Sale => new SaleImplementation();

    public static readonly DalXml instance => new DalXml();
    public static DalXml Instance { get{ return instance; } }

    private DalXml()
    {

    }
}
