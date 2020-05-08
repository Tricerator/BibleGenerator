using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblickyGenerator
{
    public class CreateFiles
    {
        private static string[] directories = { "Models", "PlainTexts", "Results", "SourceTXTFiles", "Temp" };

        public static bool manageDirectories()
        {

            if (createFiles()) return true;
            else return false;
        } 
        

        public static string getMainDirectory()
        {
            var root = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
                
            return root;
        }

        public static string getSpecifiedDirectory(string dir)
        {
            if (directories.Contains(dir)) return getMainDirectory() + "\\" + dir;
            else return "ERROR";
        }

        private static bool createFiles()
        {
            string[] directories = { "Models", "PlainTexts", "Results", "SourceTXTFiles", "Temp" };
            foreach (var dir in directories)
            {

                string directoryPath = getMainDirectory() + "\\" + dir;
                if (!Directory.Exists(directoryPath))
                {

                    Directory.CreateDirectory(directoryPath);
                    if(dir == "PlainTexts")
                    {

                        using (StreamWriter sw = new StreamWriter(File.Create(getMainDirectory() + "\\" + dir + "\\testFile.txt")))
                        {
                            sw.WriteLine("Žluťoučký kůň byl včera večer doma, ale já o tom nevím.");
                            sw.WriteLine();
                            sw.WriteLine("Byl jsem v té době v práci a šéf zrovna křičel: \"Hrom do tebe!\" Ale hrom nezahřměl...");
                        }
                    }
                }
            }

            return true;
        } 



    }
}
