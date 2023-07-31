using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
           //gets the folder route based on the fileLocation which is the type
            string route = Path.GetFullPath(@"../../../webBlocks")+"\\" + fileLocation + "\\";
            List<Blocks> aux = new List<Blocks>();
            List<List<string>> blocks = new List<List<string>> { new List<string> { }, new List<string> { }, new List<string> { } };

            foreach(string file in Directory.GetFiles(route, "*.*")) {
                   if( file.Contains(".css.txt"))
                        blocks[1].Add(new StreamReader(file).ReadToEnd());
                    if(file.Contains(".visual.txt"))
                        blocks[2].Add(new StreamReader(file).ReadToEnd());
                    if (file.Contains(".html.txt"))
                        blocks[0].Add(new StreamReader(file).ReadToEnd());
            }
            for(int i = 0; i < blocks[0].Count; i++) {
                aux.Add(new Blocks(fileLocation + "_" + i, blocks[0][i],  blocks[1][i],  blocks[2][i]));
            }
            return aux;
        }
    }
}
