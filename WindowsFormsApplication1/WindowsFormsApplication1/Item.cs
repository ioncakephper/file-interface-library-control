using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Item
    {
        public double[] Items { get; set; }

        public Item()
        {
            Items = new double[1];
        }

        public Item(int attrCount) : this()
        {
            Items = new double[attrCount];
        }
    }
}