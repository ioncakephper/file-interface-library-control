using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenApplicationFile();
        }

        private void OpenApplicationFile()
        {
            fileInterface1.OpenApplicationFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsApplicationFile();
        }

        private void SaveAsApplicationFile()
        {
            fileInterface1.SaveAsApplicationFile(true);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewApplicationFile();
        }

        private void NewApplicationFile()
        {
            fileInterface1.NewApplicationFile();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewApplicationFile();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenApplicationFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveApplicationFile();
        }

        private void SaveApplicationFile()
        {
            fileInterface1.SaveApplicationFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveApplicationFile();
        }

        private void fileInterface1_AppFileNameChanged(object sender, EventArgs e)
        {
            this.Text = System.IO.Path.GetFileName(fileInterface1.AppFileName);
        }
    }
}
