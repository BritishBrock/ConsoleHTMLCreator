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
            string route = "C:\\projects\\ConsoleHTMLCreator\\ConsoleHTMLCreator\\webBlocks\\" + fileLocation + "\\";
            List<Blocks> aux = new List<Blocks>();
            int index = 0;
            StreamReader sr;
            while (File.Exists(route + index + ".txt"))
            {
                sr = new StreamReader(route + index + ".txt");
                aux.Add(new Blocks(fileLocation + "_" + index, sr.ReadToEnd()));
                index++;
                sr.Close();
            }
            return aux;
        }
    }
}
