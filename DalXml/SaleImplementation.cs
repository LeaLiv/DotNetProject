

using System.Xml.Linq;
using System.Xml.Serialization;
using DalApi;
using DO;

namespace Dal;


internal class SaleImplementation : ISale
{
    static string filePath = @"..\xml\sales.xml";
    static XElement saleXml=XElement.Load(filePath);

    private const string SALE = "sale";
    private const string SALE_ID = "SaleId";
    private const string PRODUCT_ID = "ProductId";
    private const string MINAMOUNT = "MinAmount";
    private const string SALE_PRICE = "SalePrice";
    private const string CLUBSALE = "ClubSale";
    private const string START_SALE = "StartSale";
    private const string FINISH_SALE = "FinishSale";
    public int Create(Sale item)
    {
        try
        {
            saleXml = XElement.Load(filePath);
            if (File.Exists(filePath))
            {
                item = item with { SaleId = Config.SaleNextCode };
                saleXml.Add(new XElement(SALE,
                    new XElement(SALE_ID, item.SaleId),
                    new XElement(PRODUCT_ID, item.ProductId),
                    new XElement(MINAMOUNT, item.MinAmount),
                    new XElement(SALE_PRICE, item.SalePrice),
                    new XElement(CLUBSALE, item.ClubSale),
                    new XElement(START_SALE, item.StartSale),
                    new XElement(FINISH_SALE, item.FinishSale)
                    ));

            }
            saleXml.Save(filePath);
            return item.SaleId;
        }
        catch(Exception e) { throw e; }
    }

    public void Delete(int id)
    {
        saleXml = XElement.Load(filePath);
        try
        {
            if (File.Exists(filePath))
            {
                if (Read(id) != null) { 
                    saleXml.Elements().Single(s=>s.Element(SALE_ID).Value.Equals(id)).Remove();
                    saleXml.Save(filePath);

            }}
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public Sale? Read(int id)
    {
        try
        {
            if (File.Exists(filePath)) { 
            XElement item = saleXml.Descendants(SALE).Single(s=>s.Element(SALE_ID).Value==id.ToString());
            if (item!=null)
                return new Sale((int)item.Element(SALE_ID),
                   (int)item.Element(PRODUCT_ID),
                   (int)item.Element(MINAMOUNT),
                   (int)item.Element(SALE_PRICE),
                   (bool)item.Element(CLUBSALE),
                   (DateTime)item.Element(START_SALE),
                   (DateTime)item.Element(FINISH_SALE)
                    );
            else throw new DO.DalExceptionIdNotExist("id not exists");
            }
            return null;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        try
        {
            if (File.Exists(filePath))
            {
                List<Sale> list = saleXml.Elements(SALE).Select(item=>
                new Sale((int)item.Element(SALE_ID),
                   (int)item.Element(PRODUCT_ID),
                   (int)item.Element(MINAMOUNT),
                   (int)item.Element(SALE_PRICE),
                   (bool)item.Element(CLUBSALE),
                   (DateTime)item.Element(START_SALE),
                   (DateTime)item.Element(FINISH_SALE))).ToList();
                return list.FirstOrDefault(filter);
            }
            return null ;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        try
        {
            if (File.Exists(filePath))
            {
                List<Sale> list = saleXml.Elements(SALE).Select(item =>
                new Sale((int)item.Element(SALE_ID),
                   (int)item.Element(PRODUCT_ID),
                   (int)item.Element(MINAMOUNT),
                   (int)item.Element(SALE_PRICE),
                   (bool)item.Element(CLUBSALE),
                   (DateTime)item.Element(START_SALE),
                   (DateTime)item.Element(FINISH_SALE))).ToList();
                if (filter != null)
                    return (from s in list where filter(s) select s).ToList();
                else
                    return list;
            }
            return null;
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public void Update(Sale item)
    {
        try
        {
            if (File.Exists(filePath))
            {
                XElement sale = saleXml.Elements().SingleOrDefault(s => s.Element(SALE_ID).Value.Equals(item.SaleId.ToString()));
                if (sale != null) {
                    sale.Element(PRODUCT_ID).SetValue(item.ProductId);
                    sale.Element(MINAMOUNT).SetValue(item.MinAmount);
                    sale.Element(SALE_PRICE).SetValue(item.SalePrice);
                    sale.Element(CLUBSALE).SetValue(item.ClubSale);
                    sale.Element(START_SALE).SetValue(item.StartSale);
                    sale.Element(FINISH_SALE).SetValue(item.FinishSale);
                    saleXml.Save(filePath);
                }
                else
                {
                    throw new DalExceptionIdNotExist("sale not exist");
                }
            }
        }
        catch (Exception e)
        {

            throw e;
        }
    }
}
