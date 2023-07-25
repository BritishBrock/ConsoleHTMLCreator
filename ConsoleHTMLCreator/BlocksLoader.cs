using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    static class BlocksLoader
    {
        public static List<Blocks> Basic { get; set; } = loadBlocks("Basic");
        public static List<Blocks> Responsive { get; set; } = loadBlocks("Responsive");

        static List<Blocks> loadBlocks(string fileLocation)
        {
            string route = Path.GetFullPath(@"../../../webBlocks")+"\\" + fileLocation + "\\";
            List<Blocks> aux = new List<Blocks>();
            int index = 0;
            StreamReader sr;
            while (File.Exists(route + index + ".txt"))
            {
                sr = new StreamReader(route + index + ".txt");
                string content = sr.ReadToEnd();
                sr = new StreamReader(route + index + ".css.txt");
                string css = sr.ReadToEnd();
                sr = new StreamReader(route + index + ".visual.txt");
                string visual = sr.ReadToEnd();
                aux.Add(new Blocks(fileLocation + "_" + index, content,css,visual));
                index++;
                sr.Close();
            }
            return aux;
        }
    }
}
