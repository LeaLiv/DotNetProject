

using System.Security.Principal;
using System.Xml.Linq;

namespace Dal;

static internal class Config
{
    private static string fileName = "../xml/data-config";

    public static int SaleNextCode {
        get 
        { 
            XElement xml=XElement.Load(fileName);
            int code=(int)xml.Element("SaleNextCode");
            xml.Element("SaleNextCode").SetValue((code + 1).ToString());
            xml.Save(fileName);
            return code;
        } 
    }

    public static int ProductNextCode
    {
        get
        {
            XElement xml = XElement.Load(fileName);
            int code = (int)xml.Element("ProductNextCode");
            xml.Element("ProductNextCode").SetValue((code + 1).ToString());
            xml.Save(fileName);
            return code;
        }
    }
}
