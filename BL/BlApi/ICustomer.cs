

namespace BlApi;

public interface ICustomer
{
    int Create(BO.Customer item);
    BO.Customer? Read(int id);
    List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null);
    void Update(BO.Customer item);
    void Delete(int id);
    BO.Customer? Read(Func<BO.Customer, bool> filter);
    bool IsExist(int id);
}
