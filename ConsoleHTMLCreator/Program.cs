namespace ConsoleHTMLCreator
{
    internal class Program{

        static void Main() {

            Console.WriteLine("how many sections do you want");
            int amountSections = int.Parse(Console.ReadLine());
            HtmlCreator.setSections(amountSections);

            string exit;
            do{
                Console.WriteLine("which section would you like to add html block to ");
                for (int i = 0; i < HtmlCreator.HtmlSections.Count(); i++)
                {
                    Console.WriteLine(i + " - Section " + i);
                }
                int sectionIndex = int.Parse(Console.ReadLine());
                HtmlCreator.editSection(sectionIndex);
                Console.WriteLine("would you like to exit");
                exit = Console.ReadLine();
            } while (exit.ToLower() != "yes");
            HtmlCreator.createHTMLFile();
        }
    
    }
}