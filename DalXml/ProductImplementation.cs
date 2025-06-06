﻿
using DalApi;
using DO;
using System.Xml.Serialization;

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
                //List<Product> products = new List<Product>();
                item = item with { ProductId = Config.ProductNextCode };
                products = DO.Tools.loadDataFromXmlFile(products, filePath, serializer);

                Product existProduct = products
                    .FirstOrDefault(product => product.ProductName.Equals(item.ProductName));
                if (existProduct != null)
                {
                    throw new DO.DalExceptionIdAllreadyExist("Product already exist");
                }

                products.Add(item);
                DO.Tools.saveDataToXmlFile(products, filePath, serializer);
                return item.ProductId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int id)
        {
            //List<Product> products = new List<Product>();
            try
            {
                products = DO.Tools.loadDataFromXmlFile(products, filePath, serializer);

                Product existProduct = products.FirstOrDefault(p => p.ProductId == id);
                if (existProduct == null)
                {
                    throw new DO.DalExceptionIdNotExist("Product not exist");
                }
                products.Remove(existProduct);
                DO.Tools.saveDataToXmlFile(products, filePath, serializer);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Product? Read(int id)
        {
            //List<Product> products = new List<Product>();
            try
            {
                products=DO.Tools.loadDataFromXmlFile(products, filePath, serializer);
                Product existProduct = products.FirstOrDefault(p => p.ProductId == id);
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
            //List<Product> products = new List<Product>();
            try
            {
                products = DO.Tools.loadDataFromXmlFile(products, filePath, serializer);
                Product existProduct = products.FirstOrDefault(filter);
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
            //List<Product> products = new List<Product>();
            try
            {
                products = DO.Tools.loadDataFromXmlFile(products, filePath, serializer);
                Console.WriteLine(products);
                if (filter == null)
                    return products;
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
            if(item==null)
                throw new DalExceptionNullReference("item is null");
            try
            {
                products = DO.Tools.loadDataFromXmlFile(products, filePath, serializer);
                Product existProduct = products
                   .FirstOrDefault(product => product.ProductName.Equals(item.ProductName));
                if (existProduct == null)
                {
                    throw new DO.DalExceptionIdNotExist("Product already exist");
                }
                products.Remove(existProduct);
                products.Add(item);
                DO.Tools.saveDataToXmlFile(products, filePath, serializer);
                //Delete(item.ProductId);
                //Create(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
