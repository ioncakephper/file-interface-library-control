using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Cluster
    {
        public Cluster()
        {
            Items = new List<Item>();
        }

        public List<Item> Items
        {
            get; set;
        }

        public ClusterCentroid ClusterCentroid
        {
            get; set;
        }

        internal void ComputeCentroid()
        {
            int attrCount = Items[0].Items.Length;
            ClusterCentroid = new ClusterCentroid(attrCount);
            foreach (var item in Items)
            {
                for (int i = 0; i < attrCount; i++)
                {
                    ClusterCentroid.Score[i] += item.Items[i];
                }
            }
            for (int i = 0; i < attrCount; i++)
            {
                ClusterCentroid.Score[i] /= (double)Items.Count;
            }
        }
    }
}