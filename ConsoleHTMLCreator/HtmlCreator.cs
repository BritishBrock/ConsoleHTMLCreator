using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            
            string output = Path.GetFullPath(@"../../../output/out.html");
            StreamWriter outputWriter = new StreamWriter(output);
            outputWriter.Write(file);
            outputWriter.Close();
            saveCSSFile();
            Program.p.Close();
            Program.p.StartInfo = new ProcessStartInfo(Path.GetFullPath(@"../../../output/out.html"))
            {
                UseShellExecute = true
            };
            Program.p.Start();

        }
        private static void saveCSSFile()
        {

            string output = Path.GetFullPath(@"../../../output/out.css");
            StreamWriter outputWriter = new StreamWriter(output);
            outputWriter.Write(CssCreator.getCssFromBoxes( Section.HtmlSections));
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
            file.Append("<script type=\"text/javascript\" src=\"https://livejs.com/live.js\"></script></body></html>");
            saveHTMLFile(file.ToString());
        }

       
    }
}
