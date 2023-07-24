using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    static class HtmlCreator
    {
        public static Section[] HtmlSections;

        public static void setSections(int amount)
        {
            HtmlSections = new Section[amount];
        }
        private static void createHTMLFile(string file)
        {
            string output = "C:\\Users\\Brock\\source\\repos\\CreadorDePlantillaHtml\\CreadorDePlantillaHtml\\output\\out.html";
            StreamWriter outputWriter = new StreamWriter(output);
            outputWriter.Write(file);
            outputWriter.Close();
        }
        public static void editSection(int index) {
            Console.WriteLine("What Block Would you like to add to this section");
            string blockType = Console.ReadLine();
             switch (blockType){
                case "Basic" :
                    showBlocks(BlocksLoader.Basic);
                    break;
            };
        }
        public static void showBlocks(List<Blocks> blocks) {
            for (int i = 0; i < blocks.Count; i++) {
                Console.WriteLine(blocks[i].Name);
            }
        }
    }
}
