using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace ConsoleHTMLCreator
{
    internal class Program{

        public static Process p = new Process();
        static void Main() {
            //pick between creating files quickly or to create html from those files
            Console.WriteLine("would you like to create a file, or would you like to create a html page");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "Html":
                    CreateHtml();
                break;
                case "File":
                    CreateFile();
                break;
            }

        }


        

        static void CreateHtml() {
            //Asking the amount of sections the html page will have
            Console.WriteLine("how many sections do you want");
            int amountSections = int.Parse(Console.ReadLine());
            Section.setSections(amountSections);

            //continualy asks if you want to add html to the sections until you write yes
            string exit;
            do
            {
                Console.WriteLine("which section would you like to add html block to ");
                //loops through the sections and asks which to choose
                for (int i = 0; i < Section.HtmlSections.Count(); i++)
                {
                    Console.WriteLine(i + " - Section " + i);
                }
                int sectionIndex = int.Parse(Console.ReadLine());
                //starts the edit section method to add or change html block.
                Section.editSection(sectionIndex);
                Console.WriteLine("would you like to exit");
                exit = Console.ReadLine();
            } while (exit.ToLower() != "yes");
            HtmlCreator.createHTMLFile();
        }

        static void CreateFile() {
            string fileLocation = Console.ReadLine();
            string Name;
            do
            {
                Name = Console.ReadLine();
                string path = Path.GetFullPath(@"../../../webBlocks") + "\\" + fileLocation + "\\";
                new StreamWriter(path + Name + ".css.txt");
                new StreamWriter(path + Name + ".html.txt");
                new StreamWriter(path + Name + ".visual.txt");
            } while (Name != "exit");

        }




    
    }
}