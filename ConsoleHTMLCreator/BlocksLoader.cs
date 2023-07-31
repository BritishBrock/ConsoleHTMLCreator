using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    static class BlocksLoader
    {
        //diferent type of blocks based on the folders they are in 
        public static List<Blocks> Basic { get; set; } = loadBlocks("Basic");
        public static List<Blocks> Responsive { get; set; } = loadBlocks("Responsive");

        static List<Blocks> loadBlocks(string fileLocation)
        {
            //test
           //gets the folder route based on the fileLocation which is the type
            string route = Path.GetFullPath(@"../../../webBlocks")+"\\" + fileLocation + "\\";
            List<Blocks> aux = new List<Blocks>();
            int index = 0;
            StreamReader sr;
            //goes throught the folder and grabs the files that are in it, but files can only be 0.txt,0.visual.txt and 0.css.txt, but will change in the future to be able to name it anything you want.
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
