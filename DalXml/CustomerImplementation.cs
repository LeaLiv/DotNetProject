
using DalApi;
using DO;
using System.Xml.Serialization;

namespace Dal;

internal class CustomerImplementation : ICustomer
{
    static string file_path = "../xml/customers.xml";
    static XmlSerializer serializer = new XmlSerializer(typeof(List<Customer>));
    public static List<Customer> customers = new List<Customer>();
    public int Create(Customer item)
    {
        try
        {
            //List<Customer> customers = new List<Customer>();
            
            customers= DO.Tools.loadDataFromXmlFile(customers, file_path, serializer);
            Customer existsCustomer = customers.FirstOrDefault(c => c.Id == item.Id);
            //foreach (Customer customer in customers) 
            //    Console.WriteLine(customer.Name);
            if (existsCustomer != null)
            {

                Console.WriteLine("id already exists");
                throw new DO.DalExceptionIdAllreadyExist("id already exists");
            }
            customers.Add(item);
            DO.Tools.saveDataToXmlFile(customers,file_path, serializer);
            return item.Id;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void Delete(int id)
    {
        //List<Customer> customers = new List<Customer>();
        try
        {
            customers=DO.Tools.loadDataFromXmlFile(customers, file_path, serializer);
            Customer existsCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existsCustomer == null)
                throw new DO.DalExceptionIdNotExist("id not exists");
            customers.Remove(existsCustomer);
            DO.Tools.saveDataToXmlFile(customers, file_path, serializer);

        }
        catch (Exception )
        {

            throw;
        }
    }

    public Customer? Read(int id)
    {
        //List<Customer> customers = new List<Customer>();
        try
        {
            customers = DO.Tools.loadDataFromXmlFile(customers, file_path, serializer);
            Customer existsCustomer = customers.FirstOrDefault(c => c.Id == id);
            if (existsCustomer != null)
                return existsCustomer;
            throw new DO.DalExceptionIdNotExist("id not exists");
        }
        catch (Exception e)
        {

            throw e;
        }
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        //List<Customer> customers = new List<Customer>();
        try
        {
            customers = DO.Tools.loadDataFromXmlFile(customers, file_path, serializer);
            Customer existsCustomer = customers.FirstOrDefault(filter);
            return existsCustomer;
        }
        catch (Exception e)
        {

            throw e;
        }

    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        //List<Customer> customers = new List<Customer>();
        try
        {
            customers = DO.Tools.loadDataFromXmlFile(customers, file_path, serializer);
        if (filter == null)
            return customers;
        var filterList = from c in customers
                         where filter(c)
                         select c;
        return filterList.ToList();
        }
        catch (Exception e)
        {

            throw e;
        }

    }

    public void Update(Customer item)
    {
        try
        {
            Delete(item.Id);
            Create(item);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}
