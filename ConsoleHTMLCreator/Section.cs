﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHTMLCreator
{
    class Section
    {
        public static Section[] HtmlSections;

        public Blocks SectionBlock { get; set; }
        public Section(Blocks Block)
        {
            this.SectionBlock = Block;
        }
        public static void setSections(int amount)
        {
            //set the global amount of sections the html will have
            HtmlSections = new Section[amount];
        }
        public static void editSection(int index)
        {
            //Chooses the type of blocks you would like to use depending on the type.
            //there will be more type of blocks to add.
            Console.WriteLine("What Block Would you like to add to this section: basic or responsive");
            string blockType = Console.ReadLine().ToLower();
            switch (blockType)
            {
                case "basic":
                    if (BlocksLoader.Basic.Count == 0) return;
                    setSectionWithBlock(showBlocks(BlocksLoader.Basic), index);
                    break;
                case "responsive":
                    if (BlocksLoader.Responsive.Count == 0) return;
                    setSectionWithBlock(showBlocks(BlocksLoader.Responsive), index);
                    break;
            };
        }

        public static Blocks showBlocks(List<Blocks> blocks)
        {
            int index = 0;
            string movement;
            do
            {
                //displays to the user the visual file in a block, where it gives you a preview of the html to help you choose which one to pick
                Console.Clear();
                int count = 0;
                if (blocks.Count != null) count = blocks.Count;
                Console.WriteLine(Math.Abs(index) % blocks.Count + "/" + (count - 1));
                Console.WriteLine(blocks[Math.Abs(index) % blocks.Count].Name);
                LoadVisual(blocks[Math.Abs(index) % blocks.Count].Visual);
                Console.WriteLine("Left<<<       >>>Right");
                movement = Console.ReadLine();
                if (movement.ToLower() == "left") index--;
                if (movement.ToLower() == "right") index++;

            } while (movement.ToLower() != "back");
            Console.WriteLine("What block would you like to add");
            //loops through the blocks array and helps you choose which one you want based on name 
            //#TODO maybe add a paginator where if the amount is higher than ten you can go through the list, or show them next to eatch other
            for (int i = 0; i < blocks.Count;)
            {
                Console.WriteLine(i + "-" + blocks[i].Name + "          " + (i + 1 < blocks.Count ? i + 1 + "-" + blocks[i + 1].Name + "          " : "") + (i + 2 < blocks.Count ? i + 2 + "-" + blocks[i + 2].Name + "          " : ""));
                i += 3;
            }
            int choice = int.Parse(Console.ReadLine());

            return blocks[choice];
        }
        public static void LoadVisual(Bitmap original) {
            
            Bitmap bit = new Bitmap(original, new Size(original.Width / 32, original.Height / 32));
            ConsoleColor cached = new ConsoleColor();
            ConsoleColor chose;
            for (int i = 0,j = 0; i * j <= (bit.Height-1) * (bit.Width-1); i++)
            {
                if (i > bit.Width-1) {
                    j++;
                    i = 0;
                    Console.WriteLine();
                }
                chose = GetConsoleColor(bit.GetPixel(i, j));
                if ( cached != chose )
                {
                    cached = chose;
                    Console.ForegroundColor = cached;
                }
               
                Console.Write("█");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static ConsoleColor GetConsoleColor(Color color)
        {
            int index = (color.R > 128 | color.G > 128 | color.B > 128) ? 8 : 0;
            index |= (color.R > 64) ? 4 : 0;
            index |= (color.G > 64) ? 2 : 0;
            index |= (color.B > 64) ? 1 : 0;
            return (ConsoleColor)index;
        }


        private static void setSectionWithBlock(Blocks block, int sectionIndex)
        {
            //sets the sections block 
            Section.HtmlSections[sectionIndex] = new Section(block);
        }
    }
}
