using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    static class CssCreator
    {


        /*
            Takes in all the sections and gets the css without duplicates from each one of the blocks from the section.
         */
        public static string getCssFromBoxes(Section[] sections)
        {
            StringBuilder css = new StringBuilder();
            css.Append(preCss());
            List<string> names = new List<string>();
            //loops through the sections
            for (int i = 0; i < sections.Length; i++)
            {
                //checks if the sections are null
                if (sections[i] != null) {
                    //check if the css has already been added, so we dont get any duplicates
                    if (!(names.Contains(sections[i].SectionBlock.Name)))
                    {
                        //adds the css to the stringbuilder and adds the name to the names array so we can check the name for future sections.
                        css.Append(sections[i].SectionBlock.CSS);
                        names.Add(sections[i].SectionBlock.Name);
                    }
                }
                
            }
            return css.ToString();
        }

        private static string preCss()
        {
            //just some basic css i like to add to all my css files
            return "*{margin:0;padding:0;box-sizing:border-box} html,body{height:100%;width:100%}";
        }

    }
    

}
