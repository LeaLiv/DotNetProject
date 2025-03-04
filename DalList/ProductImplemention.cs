using DalApi;
using DO;
using Tools;
using System.Reflection;


namespace Dal
{
    internal class ProductImplemention: IProduct
    {
        public int Create(Product item)
        {
            LogManager.tabs += "\t";
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
            if (DataSource.Products.Any(p=>p.ProductId==item.ProductId))
            {
                //LogManager.tabs += "\t";
                //LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "");  
                //LogManager.tabs = LogManager.tabs.Substring(1);
                throw new DalExceptionIdAllreadyExist("product id allready exists");
            }
            Product p = item with { ProductId = DataSource.Config.ProductCode };
            DataSource.Products.Add(p); 
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

            return p.ProductId;
           

        }

        public void Delete(int id)
        {
            LogManager.tabs += "\t";
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

            Product c = Read(id);
            DataSource.Products.Remove(c);
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            LogManager.tabs = LogManager.tabs.Substring(1);

        }

        public Product? Read(int id)
        {
            LogManager.tabs += "\t";
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
                LogManager.tabs = LogManager.tabs.Substring(1);
                return DataSource.Products.Single(p => p.ProductId == id);
            }
            catch
            {
                throw new DalExceptionIdNotExist("Product not exists");
            }
        }

        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            LogManager.tabs += "\t";
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

            if (filter == null)
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
                LogManager.tabs = LogManager.tabs.Substring(1);
                return new List<Product>(DataSource.Products);
                
            }
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            LogManager.tabs = LogManager.tabs.Substring(1);
            return DataSource.Products.Where(p => filter(p)).ToList();
        }

        public void Update(Product item)
        {
            LogManager.tabs += "\t";
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

            Delete(item.ProductId);
            DataSource.Products.Add(item);
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            LogManager.tabs = LogManager.tabs.Substring(1);

        }

        public Product? Read(Func<Product, bool> filter)
        {
            LogManager.tabs += "\t";
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
                LogManager.tabs = LogManager.tabs.Substring(1);
                return DataSource.Products.First(p => filter(p));
            }
            catch
            {
                throw new DalExceptionIdNotExist("Product not exists");

            }

        }

    }
}
