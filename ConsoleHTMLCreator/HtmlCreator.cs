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
            file.Append("<html><head><style>*{margin:0;padding:0;box-sizing:border-box} ºhtml,body{height:100%;width:100%}</style></head><body>");
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
            Console.WriteLine("What Block Would you like to add to this section: basic or responsive");
            string blockType = Console.ReadLine().ToLower();
             switch (blockType){
                case "basic" :
                    setSectionWithBlock(showBlocks(BlocksLoader.Basic), index);
                    break;
                case "responsive":
                    setSectionWithBlock(showBlocks(BlocksLoader.Responsive), index);
                    break;
            };
        }

        public static Blocks showBlocks(List<Blocks> blocks) {
            int index = 0;
            string movement;
            do {
                Console.Clear();
                int count = 0;
                 if (blocks.Count != null) count = blocks.Count;
                Console.WriteLine(Math.Abs(index) % blocks.Count + "/" +( count - 1));
                Console.WriteLine(blocks[Math.Abs(index )% blocks.Count].Name);
                Console.WriteLine(blocks[Math.Abs(index) % blocks.Count].Visual);
                Console.WriteLine("<<< >>>");
                movement = Console.ReadLine();
                if(movement.ToLower() == "left")index--;
                if (movement.ToLower() == "right") index++;

            } while (movement.ToLower() != "back");
            Console.WriteLine("What block would you like to add");
            for (int i = 0; i < blocks.Count; i++)
            {
                Console.WriteLine(blocks[i].Name);
            }

            int choice = int.Parse(Console.ReadLine());
            return blocks[choice];
        }

        private static void setSectionWithBlock(Blocks block,int sectionIndex) {
            HtmlSections[sectionIndex] = new Section(block);
        }
    }
}
