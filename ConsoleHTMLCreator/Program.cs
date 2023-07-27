using System.Diagnostics;
using System.Runtime.InteropServices;
namespace ConsoleHTMLCreator
{
    internal class Program{

        public static Process p = new Process();
        static void Main() {
           //Asking the amount of sections the html page will have
            Console.WriteLine("how many sections do you want");
            int amountSections = int.Parse(Console.ReadLine());
            Section.setSections(amountSections);

            //continualy asks if you want to add html to the sections until you write yes
            string exit;
            do{
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
    
    }
}