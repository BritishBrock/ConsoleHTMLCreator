using System;
using System.Collections.Generic;
using System.Drawing;
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
            List<List<string>> blocks = new List<List<string>> { new List<string> { },new List<string> { }, new List<string> { } };
            List<Bitmap> img = new List<Bitmap>() { };
            foreach(string file in Directory.GetFiles(route, "*.*")) {
                if (!blocks[0].Contains(Path.GetFileName(file).Split(".")[0]))
                    blocks[0].Add(Path.GetFileName(file).Split(".")[0]);
                   if ( file.Contains(".css.txt"))
                        blocks[2].Add(new StreamReader(file).ReadToEnd());
                    if(file.Contains(".html.txt"))
                        blocks[1].Add(new StreamReader(file).ReadToEnd());
                    if (file.Contains(".png"))
                        img.Add((Bitmap)Image.FromFile(file));
            }

            for(int i = 0; i < blocks[0].Count; i++) {
                aux.Add(new Blocks(fileLocation + "_" + blocks[0][i], blocks[1][i], blocks[2][i], img[i]));
            }
            return aux;
        }
    }
}
