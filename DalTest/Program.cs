
using DalApi;
using DalTest;
using DO;
using Tools;
using System.Reflection;

internal class Program
{
    private static readonly IDal s_dal = Factory.Get;

    public static void Main(string[] args)
    {
        try
        {
            Initialization.Initialize();
        }
        catch (Exception e)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, e.Message);
            Console.WriteLine(e);
        }
        try
        {
            int select = PrintMainMenu();
            while (select != 0)
            {
                switch (select)
                {
                    case 1:
                        ICrud<Customer> customerReference = s_dal.Customer;
                        SubMenuCustomer(customerReference);
                        break;
                    case 2:
                        ICrud<Product> productReference = s_dal.Product;
                        SubMenuProduct(productReference);
                        break;
                    case 3:
                        ICrud<Sale> saleReference = s_dal.Sale;
                        SubMenuSale(saleReference);
                        break;
                    case 4:
                        LogManager.cleanLogFolder();
                        break;
                    default:
                        Console.WriteLine("error choise, please select again");
                        break;
                }
                select = PrintMainMenu();
            }
        }
        catch (Exception e)
        {
            LogManager.writeToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, e.Message);
            Console.WriteLine(e);
        }

    }
    public static int PrintMainMenu()
    {
        Console.WriteLine(" for customer press 1");
        Console.WriteLine("for products press 2");
        Console.WriteLine("for sales press 3");
        Console.WriteLine("to clean log file press 4");
        Console.WriteLine("to exit press 0");
        int select;
        if (!int.TryParse(Console.ReadLine(), out select))
            select = -1;
        return select;

    }
    public static int PrintSubMenu(String item)
    {
        Console.WriteLine($"For add {item} press 1");
        Console.WriteLine($"For read {item} press 2");
        Console.WriteLine($"For read all {item}s press 3");
        Console.WriteLine($"For update {item} press 4");
        Console.WriteLine($"For delete {item} press 5");
        Console.WriteLine($"to go back press 0");
        int select;
        if (!int.TryParse(Console.ReadLine(), out select))
            select = -1;
        return select;
    }

    public static void SubMenuCustomer(ICrud<Customer> customerReference)
    {
        int select = PrintSubMenu("customer");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    CreateCustomer();
                    break;
                case 2:
                    Read("customer", customerReference);
                    break;
                case 3:
                    ReadAll(customerReference);
                    break;
                case 4:
                    UpdateCustomer();
                    break;
                case 5:
                    Delete("customer", customerReference);
                    break;
                default:
                    Console.WriteLine("error choise, please select again");
                    break;

            }
            select = PrintSubMenu("customer");
        }

    }
    public static void SubMenuProduct(ICrud<Product> productReference)
    {
        int select = PrintSubMenu("product");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    createProduct();
                    break;
                case 2:
                    Read("product", productReference);
                    break;
                case 3:
                    ReadAll(productReference);
                    break;
                case 4:
                    UpdateProduct();
                    break;
                case 5:
                    Delete("product", productReference);
                    break;
                default:
                    Console.WriteLine("error choise, please select again");
                    break;

            }
            select = PrintSubMenu("product");
        }

    }
    public static void SubMenuSale(ICrud<Sale> saleReference)
    {
        int select = PrintSubMenu("sale");
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    CreateSale();
                    break;
                case 2:
                    Read("sale", saleReference);
                    break;
                case 3:
                    ReadAll(saleReference);
                    break;
                case 4:
                    UpdateSale();
                    break;
                case 5:
                    Delete("sale", saleReference);
                    break;
                default:
                    Console.WriteLine("error choise, please select again");
                    break;

            }
            select = PrintSubMenu("sale");
        }

    }


    public static void Read<T>(string type, ICrud<T> icrud)
    {
        Console.WriteLine($"insert {type} id to read");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
            id = -1;
        Console.WriteLine(icrud.Read(id));
    }

    public static void ReadAll<T>(ICrud<T> icrud)
    {
        List<T> list = icrud.ReadAll();
        foreach (T item in list)
        {
            Console.WriteLine(item);
        }
    }
    public static void Delete<T>(string type, ICrud<T> icrud)
    {
        Console.WriteLine($"insert {type} id to delet");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
            id = -1;
        icrud.Delete(id);
    }
    public static Customer inputCustomerDetails()
    {
        int id;
        string name, addres, phoneNumber;
        Console.WriteLine("insert customer id ,customer name, customer addesr and customer phone number");
        if (!int.TryParse(Console.ReadLine(), out id))
            id = -1;
        name = Console.ReadLine();
        addres = Console.ReadLine();
        phoneNumber = Console.ReadLine();
        return new Customer(id, name, addres, phoneNumber);
    }
    public static void CreateCustomer()
    {

        s_dal.Customer.Create(inputCustomerDetails());

    }

    private static void UpdateCustomer()
    {
        s_dal.Customer.Update(inputCustomerDetails());
    }


    public static void createProduct()
    {
        s_dal.Product.Create(inputProductDetails());

    }
    private static void UpdateProduct()
    {
        s_dal.Product.Update(inputProductDetails());
    }
    public static Product inputProductDetails()
    {
        int QuantityInStock;
        string name;
        Category category;
        double price;
        Console.WriteLine("insert product name,product category, product price and product quantity in stock");
        name = Console.ReadLine();
        if (!Category.TryParse(Console.ReadLine(), out category))
            category = Category.בנים;
        if (!double.TryParse(Console.ReadLine(), out price))
            price = 0;
        if (!int.TryParse(Console.ReadLine(), out QuantityInStock))
            QuantityInStock = 0;
        return new Product(-1, name, category, price, QuantityInStock);
    }

    public static Sale inputSaleDetails()
    {
        int id, productId, minAmount;
        double salePrice;
        bool clubSale;
        DateTime startDate;
        DateTime finishDate;
        Console.WriteLine("insert sale id and to which product the sale is ,what min amount to this sale name, how much the sale is ,if the" +
            "sale is only for club sale,when the sale is start and when the sale is over ");
        if (!int.TryParse(Console.ReadLine(), out id))
            id = -1;
        if (!int.TryParse(Console.ReadLine(), out productId))
            productId = -1;
        if (!int.TryParse(Console.ReadLine(), out minAmount))
            minAmount = -1;
        double.TryParse(Console.ReadLine(), out salePrice);
        bool.TryParse(Console.ReadLine(), out clubSale);
        DateTime.TryParse(Console.ReadLine(), out startDate);
        DateTime.TryParse(Console.ReadLine(), out finishDate);
        return new Sale(id, productId, minAmount, salePrice, clubSale, startDate, finishDate);
    }

    public static void CreateSale()
    {

        s_dal.Sale.Create(inputSaleDetails());

    }

    private static void UpdateSale()
    {
        s_dal.Sale.Update(inputSaleDetails());
    }

}
