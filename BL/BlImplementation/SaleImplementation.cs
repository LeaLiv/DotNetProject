
using BlApi;
using BO;

namespace BlImplementation;

internal class SaleImplementation:ISale
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(Sale item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Sale? Read(int id)
    {
        throw new NotImplementedException();
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        throw new NotImplementedException();
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Sale item)
    {
        throw new NotImplementedException();
    }
}
