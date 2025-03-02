

namespace BlApi;

public interface ISale
{
    int Create(BO.Sale item);
    BO.Sale? Read(int id);
    List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null);
    void Update(BO.Sale item);
    void Delete(int id);
    BO.Sale? Read(Func<BO.Sale, bool> filter);
}
