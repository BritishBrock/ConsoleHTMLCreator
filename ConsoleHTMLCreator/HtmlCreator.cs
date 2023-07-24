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
        private static void saveHTMLFile(string file)
        {
            string output = "C:\\projects\\ConsoleHTMLCreator\\ConsoleHTMLCreator\\output\\out.html";
            StreamWriter outputWriter = new StreamWriter(output);
            outputWriter.Write(file);
            outputWriter.Close();
        }
        public static void createHTMLFile()
        {
            StringBuilder file = new StringBuilder();
            file.Append("<html><head></head><body>");
            for(int i = 0; i < HtmlSections.Length; i++)
            {
                if (HtmlSections[i] != null)
                {
                    file.Append(HtmlSections[i].SectionBlock.Content);
                }
            }
            file.Append("</body></html>");
            saveHTMLFile(file.ToString());
        }

        public static void editSection(int index) {
            Console.WriteLine("What Block Would you like to add to this section: basic");
            string blockType = Console.ReadLine().ToLower();
             switch (blockType){
                case "basic" :
                    setSectionWithBlock(showBlocks(BlocksLoader.Basic), index);
                    break;
                case "responsive":
                    setSectionWithBlock(showBlocks(BlocksLoader.Basic), index);
                    break;
            };
        }

        public static Blocks showBlocks(List<Blocks> blocks) {
            Console.WriteLine("What Block Would you like to add to this section: basic");
            for (int i = 0; i < blocks.Count; i++) {
                Console.WriteLine(i +" - "+ blocks[i].Name);
            }
            int choice = int.Parse(Console.ReadLine());
            return blocks[choice];
        }

        private static void setSectionWithBlock(Blocks block,int sectionIndex) {
            HtmlSections[sectionIndex] = new Section(block);
        }
    }
}
