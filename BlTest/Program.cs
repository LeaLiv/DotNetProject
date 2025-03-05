

using DalTest;
using System.Reflection;
using Tools;

public class program
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
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
        bool flag;
        Console.WriteLine("insert your id ");
        string x=Console.ReadLine();
        if (x !="0")
            flag = true;
        Console.WriteLine("insert product details");
        int choise = 1;
        while (choise == 1)
        {
            Console.ReadLine();
        }

    }
}