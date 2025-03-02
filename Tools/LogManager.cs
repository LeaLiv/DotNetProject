
namespace Tools
{
    public static class LogManager
    {
        private const string path = "Log";
        public static string tabs = "";

        public static string getCurrentFolderPath()
        {
            return $@"{Directory.GetParent(Directory.GetCurrentDirectory()).FullName}\bin\{path}";
        }

        public static string getCurrentFilePath()
        {
            return $@"{getCurrentFolderPath()}\{DateTime.Now.Year}.{DateTime.Now.Month}\{DateTime.Now.Day}.txt";
        }

        public static void writeToLog(string projectName, string funcName, string message)
        {
            string folderPath = getCurrentFolderPath()+$"\\{DateTime.Now.Year}.{DateTime.Now.Month}";
            string filePath = getCurrentFilePath();
            if (!File.Exists(filePath))
            {
                //   Console.WriteLine(  $"{ projectName}.{ funcName}:\t{ message}");
                //Console.WriteLine( folderPath);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);

                }

                File.Create(filePath).Close();
            }
            File.AppendAllText(filePath, $"{tabs}{DateTime.Now}\t{projectName}.{funcName}:\t{message}" + Environment.NewLine);
            //Console.WriteLine($"{tabs}{DateTime.Now}\t{projectName}.{funcName}:\t{message}");
        }
        public static void cleanLogFolder()
        {
            string[] folders = Directory.GetDirectories(getCurrentFolderPath());
            int month = DateTime.Now.AddMonths(-2).Month, year = DateTime.Now.AddMonths(-2).Year;
            foreach (string folder in folders)
            {
                Console.WriteLine(Path.GetFileName(folder).CompareTo($"{year}.{month}"));
                if (Path.GetFileName( folder).CompareTo($"{year}.{month}") < 0)
                    Directory.Delete(folder);
            }

        }

    }
}

