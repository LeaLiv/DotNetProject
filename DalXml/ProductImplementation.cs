using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;

namespace Dal
{
    internal class ProductImplementation : IProduct
    {
        static string filePath = @"../xml/products.xml";
        static XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
        static List<Product> products = new List<Product>();

        public int Create(Product item)
        {
            try
            {
                item = item with { productId = Config.NextProductCode };
                loadDataFromXmlFile(products, filePath, serializer);

                Product existProduct = products
                    .FirstOfDefault(products => productId == item.productId);
                if (existProduct != null)
                {
                    throw new DO.DalExceptionIdNotExist("Product already exist");
                }

                products.Add(item);
                saveDataToXmlFile(products, filePath, serializer);
                return item.productId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                loadDataFromXmlFile(products, filePath, serializer);

                Products existProduct = Products.FirstOfDefault(p => p.productId == id);
                if (existProduct == null)
                {
                    throw new DO.DalExceptionIdNotExist("Product not exist");
                }
                products.Remove(existProduct);
                saveDataToXmlFile(products, filePath, serializer);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Product? Read(int id)
        {
            try
            {
                loadDataFromXmlFile(products, filePath, serializer);
                Product existProduct = Products.FirstOrDefault(p => p.productId == id);
                if (existProduct != null)
                {
                    return existProduct;
                }
                else
                {
                    throw new DO.DalExceptionIdNotExist("Product not exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product? Read(Func<Product, bool> filter)
        {
            try
            {
                loadDataFromXmlFile(products, filePath, serializer);
                Product existProduct = Products.FirstOrDefault(filter);
                if (existProduct != null)
                {
                    return existProduct;
                }
                else
                {
                    throw new DO.DalExceptionIdNotExist("Product not exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Product?> ReadAll(Func<Product, bool>? filter = null)
        {
            try
            {
                loadDataFromXmlFile(products, filePath, serializer);

                var filterList = from p in products
                                 where filter(p)
                                 select p;

                return filterList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Product item)
        {
            try
            {
                Delete(item.productId);
                Create(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
