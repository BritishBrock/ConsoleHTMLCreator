using System.Diagnostics;
using System.Runtime.InteropServices;
namespace ConsoleHTMLCreator
{
    internal class Program{

        public static Process p = new Process();
        static void Main() {


            Console.WriteLine("how many sections do you want");
            int amountSections = int.Parse(Console.ReadLine());
            Section.setSections(amountSections);

            string exit;
            do{
                Console.WriteLine("which section would you like to add html block to ");
                for (int i = 0; i < Section.HtmlSections.Count(); i++)
                {
                    Console.WriteLine(i + " - Section " + i);
                }
                int sectionIndex = int.Parse(Console.ReadLine());
                Section.editSection(sectionIndex);
                Console.WriteLine("would you like to exit");
                exit = Console.ReadLine();
            } while (exit.ToLower() != "yes");
            HtmlCreator.createHTMLFile();

        }
    
    }
}