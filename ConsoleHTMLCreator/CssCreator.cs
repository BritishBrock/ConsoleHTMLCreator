using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    static class CssCreator
    {

        public static string getCssFromBoxes(Section[] sections)
        {
            StringBuilder css = new StringBuilder();
            css.Append(preCss());
            List<string> names = new List<string>();
            for (int i = 0; i < sections.Length; i++)
            {
                if (!(names.Contains(sections[i].SectionBlock.Name)))
                {
                    css.Append(sections[i].SectionBlock.CSS);
                    names.Add(sections[i].SectionBlock.Name);
                }
            }
            return css.ToString();
        }


        private static string preCss()
        {
            return "*{margin:0;padding:0;box-sizing:border-box} html,body{height:100%;width:100%}";
        }

    }
    

}
