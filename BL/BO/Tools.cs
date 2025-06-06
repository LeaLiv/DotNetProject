﻿
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace BO;
internal static class Tools
{

    public static string ToStringProperty<T>(this T obj, string prefix = "")
    {
        if (obj == null)
            return $"{prefix}null";

        Type type = obj.GetType();
        var sb = new StringBuilder();

        foreach (FieldInfo field in type.GetFields())
        {
            object? value = field.GetValue(obj);
            sb.AppendLine($"{prefix}{field.Name} = {value}");
        }

        return sb.ToString();
    }

    public static DO.Customer Convert(this BO.Customer customer)
    {
        return new DO.Customer(customer.Id, customer.Name, customer.Address, customer.PhoneNumber);
    }
    public static BO.Customer Convert(this DO.Customer customer)
    {
        return new BO.Customer(customer.Id, customer.Name, customer.Address, customer.PhoneNumber);
    }
    public static DO.Product Convert(this BO.Product product)
    {
        return new DO.Product(product.ProductId, product.ProductName, (DO.Category?)product.category, product.Price, product.QuantityInStock);
    }
    public static BO.Product Convert(this DO.Product product)
    {
        return new BO.Product(product.ProductId, product.ProductName, (BO.Category?)product.category, product.Price, product.QuantityInStock);
    }
    public static DO.Sale Convert(this BO.Sale sale) 
    { 
        return new DO.Sale(sale.SaleId,sale.ProductId,sale.MinAmount,sale.SalePrice,sale.ClubSale,sale.StartSale,sale.FinishSale);
    }
    public static BO.Sale Convert(this DO.Sale sale)
    {
        return new BO.Sale(sale.SaleId, sale.ProductId, sale.MinAmount, (double)sale.SalePrice, sale.ClubSale, sale.StartSale, sale.FinishSale);
    }

    public static DO.Product ChangeQuantity(this DO.Product product, int quantity) => new DO.Product { ProductId = product.ProductId, ProductName = product.ProductName, QuantityInStock =product.QuantityInStock-quantity, Price = product.Price, category = product.category };
}
