//------------------------------------------------------------------------------
// <copyright file="Form1.cs" company="Weblidity Software">
//      Copyright (c) Weblidity Software. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace FileInterface
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Form1" />
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The fileInterface1_AppFileNameChanged
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void fileInterface1_AppFileNameChanged(object sender, EventArgs e)
        {
            this.Text = System.IO.Path.GetFileName(fileInterface1.AppFileName);
        }

        /// <summary>
        /// The fileInterface1_Change
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="FileInterfaceControlLibrary.ContentChangedEventArgs"/></param>
        private void fileInterface1_Change(object sender, FileInterfaceControlLibrary.ContentChangedEventArgs e)
        {
            var result = MessageBox.Show("Has the content changed?", "Content Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Changed = result.Equals(DialogResult.Yes);
        }

        /// <summary>
        /// The Form1_Load
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            fileInterface1.AppFileName = fileInterface1.NewFileGenerator.Generate();
        }

        /// <summary>
        /// The NewApplicationFile
        /// </summary>
        private void NewApplicationFile()
        {
            fileInterface1.NewApplicationFile();
        }

        /// <summary>
        /// The newToolStripButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewApplicationFile();
        }

        /// <summary>
        /// The newToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewApplicationFile();
        }

        /// <summary>
        /// The OpenApplicationFile
        /// </summary>
        private void OpenApplicationFile()
        {
            fileInterface1.OpenApplicationFile();
        }

        /// <summary>
        /// The openToolStripButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenApplicationFile();
        }

        /// <summary>
        /// The openToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenApplicationFile();
        }

        /// <summary>
        /// The SaveApplicationFile
        /// </summary>
        private void SaveApplicationFile()
        {
            fileInterface1.SaveApplicationFile();
        }

        /// <summary>
        /// The SaveAsApplicationFile
        /// </summary>
        private void SaveAsApplicationFile()
        {
            fileInterface1.SaveAsApplicationFile(true);
        }

        /// <summary>
        /// The saveAsToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsApplicationFile();
        }

        /// <summary>
        /// The saveToolStripButton_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveApplicationFile();
        }

        /// <summary>
        /// The saveToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/></param>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveApplicationFile();
        }
    }
}
