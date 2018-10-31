using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class ClusterCentroid
    {
        public double[] Score { get; set; }

        public ClusterCentroid(int attrCount)
        {
            Score = new double[attrCount];
        }
    }
}