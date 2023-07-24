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
    }
}
