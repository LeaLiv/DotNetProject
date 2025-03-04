using DO;
using DalApi;
using Tools;
using System.Reflection;

namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        LogManager.tabs += "\t";
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        if (DataSource.Sales.Any(s => s.SaleId == item.SaleId))
        {
            throw new DalExceptionIdAllreadyExist("Sale id allready exists");
        }
        Sale s = item with { SaleId = DataSource.Config.SaleCode };
        DataSource.Sales.Add(s);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
        LogManager.tabs = LogManager.tabs.Substring(1);
        return s.SaleId;

    }

    public void Delete(int id)
    {
        LogManager.tabs += "\t";
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

        Sale s = Read(id);
        DataSource.Sales.Remove(s);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
        LogManager.tabs = LogManager.tabs.Substring(1);

    }

    public Sale? Read(int id)
    {
        LogManager.tabs += "\t";
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

        try
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            LogManager.tabs = LogManager.tabs.Substring(1);
            return DataSource.Sales.Single(s => s.SaleId == id);
        }
        catch
        {
            throw new DalExceptionIdNotExist("Sale not exists");
        }

    }
    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.tabs += "\t";
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

        if (filter == null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            LogManager.tabs = LogManager.tabs.Substring(1);
            return new List<Sale>(DataSource.Sales);
        }
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
        LogManager.tabs = LogManager.tabs.Substring(1);
        return DataSource.Sales.Where(s => filter(s)).ToList();
    }

    public void Update(Sale item)
    {
        LogManager.tabs += "\t";
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

        Delete(item.SaleId);
        DataSource.Sales.Add(item);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
        LogManager.tabs = LogManager.tabs.Substring(1);
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        LogManager.tabs += "\t";
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        try
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            LogManager.tabs = LogManager.tabs.Substring(1);
            return DataSource.Sales.First(s => filter(s));
        }
        catch
        {
            throw new DalExceptionIdNotExist("Sale not exists");

        }

    }
}


