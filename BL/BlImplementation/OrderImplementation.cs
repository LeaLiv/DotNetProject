

using BlApi;
using BO;
using DO;

namespace BlImplementation;

public class OrderImplementation : IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public List<SaleInProduct> AddProductToOrder(Order order, int productId, int quantity)
    {
        try
        {

            DO.Product product = _dal.Product.Read(productId);
            ProductInOrder productInOrder = order.ProductsInOrder.Find(s => s.ProductId == productId);
            if (productInOrder != null)
            {
                if (quantity <= product.QuantityInStock)
                {
                    productInOrder.QuantityInOrder += quantity;
                }
                else
                {
                    throw new BLExceptionNotInStock("not enoght in stock");
                }
            }
            else
            {
                if (quantity <= product.QuantityInStock)
                {
                    productInOrder = new ProductInOrder { QuantityInOrder = quantity, BasePrice = product.Price, ProductId = productId, ProductName = product.ProductName, };
                    order.ProductsInOrder.Add(productInOrder);
                }

            }
            CalcTotalPriceForProduct(productInOrder);
            CalcTotalPrice(order);
            return productInOrder.SalesInProduct;
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }

    }

    public void CalcTotalPrice(Order order)
    {
        order.ProductsInOrder.ForEach(p => order.Price += p.FinalPrice);
    }


    public void CalcTotalPriceForProduct(ProductInOrder productInOrder)
    {
        int count = productInOrder.QuantityInOrder;
        List<SaleInProduct> saleInProducts = SearchSaleForProduct(productInOrder);
        foreach (var item in saleInProducts)
        {
            if (count < item.Quantity)
                continue;
            productInOrder.FinalPrice += count * item.Price;
            productInOrder.SalesInProduct.Add(item);
            count = 0;
            break;
        }
        if (count > 0)
        {
            productInOrder.FinalPrice += count * productInOrder.BasePrice;
        }

    }

    public void DoOrder(Order order)
    {
        try
        {
            //עבור כל מוצר בהזמנה, מייצרים בקשת עדכון ל DAL כדי להוריד ממלאי המוצר את הכמות שבהזמנה.
            foreach (var item in order.ProductsInOrder)
            {
                DO.Product product = _dal.Product.Read(item.ProductId);
                product = product.ChangeQuantity(item.QuantityInOrder);
                _dal.Product.Update(product);
            }
        }
        catch (DalExceptionIdNotExist e)
        {
            throw new BLExceptionIdNotExist(e.Message);
        }
    }

    public List<SaleInProduct> SearchSaleForProduct(ProductInOrder productInOrder, bool? isMemberClub = false)
    {
        List<SaleInProduct> saleInProducts
            = _dal.Sale.ReadAll(s => s.ProductId == productInOrder.ProductId).Where(s => s.StartSale <= DateTime.Now && s.FinishSale >= DateTime.Now
            && productInOrder.QuantityInOrder >= s.MinAmount)
            .Select(s => new SaleInProduct { IsForClubMembers = s.ClubSale, SaleId = s.SaleId, Price = (double)s.SalePrice, Quantity = productInOrder.QuantityInOrder }).ToList();
        if (isMemberClub == false)
        {
            saleInProducts = productInOrder.SalesInProduct.FindAll(s => s.IsForClubMembers == false).ToList();
        }
        return saleInProducts;
    }
}

