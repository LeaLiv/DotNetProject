
using System.Xml.Serialization;

namespace DO
{
    public static class Tools
    {
        public static List<T> loadDataFromXmlFile<T>(List<T> items,string file_path, XmlSerializer serializer)
        {
            try
            {
                if (File.Exists(file_path))
                {
                    using (FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read))
                    {
                        items = (List<T>)serializer.Deserialize(fs);
                    }
                    return items;
                }
            }
            catch (Exception e)
            {

                throw new Exception("בעיה בקריאת קובץ XML: הקובץ כנראה פגום או לא מתאים למבנה הנתונים.", e);
            }
            return new List<T>();
           
        }

        public static void saveDataToXmlFile<T>(List<T> items, string file_path, XmlSerializer serializer)
        {
            try
            {
                using (FileStream fs = new FileStream(file_path, FileMode.Create))
                {
                    serializer.Serialize(fs, items);
                }
            }
            catch (Exception)
            {

                throw ;
            }

        }

    }
}
