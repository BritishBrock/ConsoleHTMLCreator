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
        public string Content { get; set; }

        public Blocks(string Name, string Content)
        {
            this.Name = Name;
            this.Content = Content;
        }
    }
}
