

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

    }
}