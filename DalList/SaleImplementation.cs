using DO;
using DalApi;
using Tools;
using System.Reflection;

namespace Dal;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        LogManager.tabs += "\t------------------------";
        Sale s = item with { SaleId = DataSource.Config.SaleCode };
        DataSource.Sales.Add(s);
        //LogManager.tabs.substring(1);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

        return s.SaleId;

    }

    public void Delete(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        LogManager.tabs += "\t------------------------";
        Sale s = Read(id);
        DataSource.Sales.Remove(s);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

    }

    public Sale? Read(int id)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        LogManager.tabs += "\t-----------------------";
        try
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            return DataSource.Sales.Single(s => s.SaleId == id);
        }
        catch
        {
            throw new DalExceptionIdNotExist("Sale not exists");
        }

    }
    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        LogManager.tabs += "\t------------------------------";
        if (filter == null)
            return new List<Sale>(DataSource.Sales);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

        return DataSource.Sales.Where(s => filter(s)).ToList();
    }

    public void Update(Sale item)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        LogManager.tabs += "\t------------------------";
        Delete(item.SaleId);
        DataSource.Sales.Add(item);
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
        LogManager.tabs += "\t-------------------------";
        try
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

            return DataSource.Sales.First(s => filter(s));
        }
        catch
        {
            throw new DalExceptionIdNotExist("Sale not exists");

        }

    }
}


