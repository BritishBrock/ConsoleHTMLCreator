using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    public class Blocks
    {
        private string _Name { get; set; }
        private string _Content { get; set; }

        public Blocks(string Name, string Content)
        {
            this._Name = Name;
            this._Content = Content;
        }
    }
}
