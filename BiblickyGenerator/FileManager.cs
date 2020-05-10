using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblickyGenerator
{

    /// <summary>
    /// This class creates needed files for the program and 
    ///        gives paths to directories
    /// Most of the created directories are empty except PlainTexts where is 
    ///    one little txt file for test purposes
    /// </summary>
    public class FileManager
    {
        private static string[] directories = { "Models", "PlainTexts", "Results", "SourceTXTFiles", "Temp" };


        /// <summary>
        /// This method creates file 
        /// </summary>
        /// <returns></returns>
        public static bool ManageDirectories()
        {

            if (CreateFiles()) return true;
            else return false;
        } 
        

        public static string GetMainDirectory()
        {
            //if running in debug mode
           // var root = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));


            //after creating exe file
            var root = Directory.GetCurrentDirectory();
            return root;
        }

        public static string GetSpecifiedDirectory(string dir)
        {
            if (directories.Contains(dir)) return GetMainDirectory() + "\\" + dir;
            else return "ERROR";
        }

        private static bool CreateFiles()
        {
            string[] directories = { "Models", "PlainTexts", "Results", "SourceTXTFiles", "Temp" };
            foreach (var dir in directories)
            {

                string directoryPath = GetMainDirectory() + "\\" + dir;
                if (!Directory.Exists(directoryPath))
                {

                    Directory.CreateDirectory(directoryPath);
                    if(dir == "PlainTexts")
                    {

                        using (StreamWriter sw = new StreamWriter(File.Create(GetMainDirectory() + "\\" + dir + "\\testFile.txt")))
                        {
                            sw.WriteLine("Červený kůň byl včera večer doma, ale já o tom nevím.");
                            sw.WriteLine("Modrý kůň tam nebyl. Zelený kůň byl tam, kde byl modrý kůň.");
                            sw.WriteLine("Vlastně byl modrý kůň tam, kde nebyl červený kůň.");
                            sw.WriteLine("Byl jsem v té době v práci a šéf zrovna křičel: \"Hrom do tebe!\" Ale hrom nezahřměl...");
                        }
                    }
                }
            }

            return true;
        } 



    }
}
