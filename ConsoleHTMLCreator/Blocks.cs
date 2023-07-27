using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    public class Blocks
    {
        public string Name { get; set; }
        public string CSS { get; set; }
        public string Visual { get; set; }
        public string Content { get; set; }

        //contains the name of the type of block plus file name, content which contains the html, the css that contains css and the visual which is the preview of the html that you will choose
        public Blocks(string Name, string Content,string css, string visual)
        {
            this.Name = Name;
            this.Content = Content;
            this.CSS = css;
            this.Visual = visual;
        }
    }
}
