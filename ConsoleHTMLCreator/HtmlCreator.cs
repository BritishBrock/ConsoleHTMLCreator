using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    static class HtmlCreator
    {
        
        private static void saveHTMLFile(string file)
        {
            
            string output = "C:\\projects\\ConsoleHTMLCreator\\ConsoleHTMLCreator\\output\\out.html";
            StreamWriter outputWriter = new StreamWriter(output);
            outputWriter.Write(file);
            outputWriter.Close();
            saveCSSFile();
        }
        private static void saveCSSFile()
        {
            string output = "C:\\projects\\ConsoleHTMLCreator\\ConsoleHTMLCreator\\output\\out.css";
            StreamWriter outputWriter = new StreamWriter(output);
            outputWriter.Write(CssCreator.getCssFromBoxes(  Section.HtmlSections));
            outputWriter.Close();
        }
        public static void createHTMLFile()
        {
  
            StringBuilder file = new StringBuilder();
            file.Append("<html><head><link rel=\"stylesheet\" type=\"text/css\" href=\"out.css\"></head><body>");
            for(int i = 0; i < Section.HtmlSections.Length; i++)
            {
                if (Section.HtmlSections[i] != null)
                {
                    file.Append(Section.HtmlSections[i].SectionBlock.Content);
                }
            }
            file.Append("</body></html>");
            saveHTMLFile(file.ToString());
        }

       
    }
}
