using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    internal static class Tools
    {
        public static void loadDataFromXmlFile(List<T> items,string file path, XmlSerializer serializer)
        {
            try
            {
                if (File.Exists(file_path))
                {
                    using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.ReadWrite))
                    {
                        items = (List<T>)serializer.Deserialize(fs);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }

        public static void SaveDataTomlFile(List<T> items, string file path, XmlSerializer serializer)
        {
            try
            {
                using (FileStream fs = new FileStream(file_path, FileMode.Open))
                {
                    serializer.Serialize(fs, items);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }

    }
}
