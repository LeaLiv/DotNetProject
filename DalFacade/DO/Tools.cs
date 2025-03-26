
using System.Xml.Serialization;

namespace DO
{
    public static class Tools
    {
        public static void loadDataFromXmlFile(List<T> items,string file_path, XmlSerializer serializer)
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

        public static void saveDataToXmlFile(List<T> items, string file_path, XmlSerializer serializer)
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
