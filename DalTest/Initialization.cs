using DO;
using DalApi;

namespace DalTest; 
    public static class Initialization
    {
    private static IDal s_dal;

        private static void createProducts()
        {
            s_dal.Product.Create(new Product(0, "סרט לשיער", Category.אקססוריז, 14.9, 30));
            s_dal.Product.Create(new Product(0, "מכנס דגמח", Category.בנים, 100, 10));
            s_dal.Product.Create(new Product(0, "אוברול", Category.תינוקות, 80, 70));
            s_dal.Product.Create(new Product(0, "חצאית קפלים", Category.בנות, 120, 50));
            s_dal.Product.Create(new Product(0, "חליפה 2 חלקים", Category.אלגנט, 250, 25));
        }

        private static void createCustomers()
        {
            s_dal.Customer.Create(new Customer(789, "יהודית כהן", "נתיבות המשפט 5", "0545555555"));
            s_dal.Customer.Create(new Customer(663, "שמעונה סגל", " ירושלים 15", "054566666"));
            s_dal.Customer.Create(new Customer(747, "יוספה לוי", "מרומי שדה 8", "058566666"));
            s_dal.Customer.Create(new Customer(886, "אברהם שכטר", "מסילת יוסף 21", "053566666"));
            s_dal.Customer.Create(new Customer(320, "יונה לנג", "נתיבות שלום 7", "052566666"));
        }

        private static void createSales()
        {
            s_dal.Sale.Create(new Sale(0, 100, 1, 12, true, DateTime.Now, new DateTime(2024, 12, 5)));
            s_dal.Sale.Create(new Sale(0, 101, 1, 90, false, DateTime.Now, new DateTime(2024, 12, 5)));
            s_dal.Sale.Create(new Sale(0, 102, 3,70, true, DateTime.Now, new DateTime(2024, 12, 5)));
            s_dal.Sale.Create(new Sale(0, 103, 2, 100, false, DateTime.Now, new DateTime(2024, 12, 5)));
            s_dal.Sale.Create(new Sale(0, 104, 4, 200, true, DateTime.Now, new DateTime(2024, 12, 5)));
        }
    public static void Initialize()
    {
        s_dal = Factory.Get;
        createCustomers();
        createProducts();
        createSales();

    }

}


