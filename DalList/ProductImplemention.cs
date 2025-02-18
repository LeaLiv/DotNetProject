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
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

            Product p = item with { ProductId = DataSource.Config.ProductCode };
            DataSource.Products.Add(p); 
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
            return p.ProductId;
           

        }

        public void Delete(int id)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

            Product c = Read(id);
            DataSource.Products.Remove(c);
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

        }

        public Product? Read(int id)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");
            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
                return DataSource.Products.Single(p => p.ProductId == id);
            }
            catch
            {
                throw new DalExceptionIdNotExist("Product not exists");
            }
        }

        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

            if (filter == null)
                return new List<Product>(DataSource.Products);
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

            return DataSource.Products.Where(p => filter(p)).ToList();
        }

        public void Update(Product item)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

            Delete(item.ProductId);
            DataSource.Products.Add(item);
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");

        }

        public Product? Read(Func<Product, bool> filter)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Enter to function");

            try
            {
                LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, " Leava the function");
                return DataSource.Products.First(p => filter(p));
            }
            catch
            {
                throw new DalExceptionIdNotExist("Product not exists");

            }

        }

    }
}
