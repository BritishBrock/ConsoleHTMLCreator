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
            //saves htmlfile to a given output folder under the name out.html
            string output = Path.GetFullPath(@"../../../output/out.html");
            StreamWriter outputWriter = new StreamWriter(output);
            outputWriter.Write(file);
            outputWriter.Close();
            //creates the css file that acompanies the html
            saveCSSFile();
            //opens a new browser tab process to show of the html page you just made 
            Program.p.Close();
            Program.p.StartInfo = new ProcessStartInfo(Path.GetFullPath(@"../../../output/out.html"))
            {
                UseShellExecute = true
            };
            Program.p.Start();

        }
        private static void saveCSSFile()
        {
            //saves the css to out.css
            string output = Path.GetFullPath(@"../../../output/out.css");
            StreamWriter outputWriter = new StreamWriter(output);
            outputWriter.Write(CssCreator.getCssFromBoxes( Section.HtmlSections));
            outputWriter.Close();
        }
        public static void createHTMLFile()
        {
            //loops throught all the sections and adds the section blocks content which is the html we have chosen for eatch section; if there is no section it wont add aything
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
