namespace ConsoleHTMLCreator
{
    internal class Program{

        static void Main() {

            Console.WriteLine("how many sections do you want");
            int amountSections = int.Parse(Console.ReadLine());
            HtmlCreator.setSections(amountSections);
            Console.WriteLine("which section would you like to add html block to ");
            for (int i = 0; i < HtmlCreator.HtmlSections.Count(); i++)
            {
                Console.WriteLine(i + " - Section " + i);
            }
        }
    
    }
}