using FileInterfaceControlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewApplicationFile();
        }

        private void NewApplicationFile()
        {
            fileInterface1.NewApplicationFile();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewApplicationFile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileInterface1.AppFileName = fileInterface1.NewFileGenerator.Generate();
        }

        private void fileInterface1_AppFileNameChanged(object sender, EventArgs e)
        {
            this.Text = System.IO.Path.GetFileNameWithoutExtension(((FileInterface)sender).AppFileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            var knn = new Knn(5);
            for (int i = 0; i < 10000; i++)
            {
                var item = new Item(2);
                for (int j = 0; j < item.Items.Length; j++)
                {
                    if (j == 0) { item.Items[j] = r.Next(40, 120); }
                    else { item.Items[j] = r.Next(150, 220); }                  
                }
                knn.Items.Add(item);
            }
            var clusters = knn.BuildClusters();
            Console.WriteLine(clusters.ToString());
        }
    }
}
