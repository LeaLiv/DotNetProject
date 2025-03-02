
namespace BlApi;

public interface IBl
{
    ICustomer Customer { get; }
    IProduct Product { get; }
    ISale Sale { get; }
    IOrder Order { get; }
}
