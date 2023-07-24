using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    internal class Section
    {
        Blocks SectionBlock { get; set; }
        public Section(Blocks Block)
        {
            this.SectionBlock = Block;
        }
    }
}
