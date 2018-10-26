using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileInterfaceControlLibrary
{
    public partial class FileInterface : Component
    {
        private string appFileName = string.Empty;

        public FileInterface()
        {
            InitializeComponent();
        }

        public FileInterface(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string AppFileName
        {
            get
            {
                return appFileName;
            }

            set
            {
                appFileName = value;
            }
        }

        public OpenFileDialog AppOpenFileDialog
        {
            get
            {
                return openFileDialog1;
            }

            set
            {
                openFileDialog1 = value;
            }
        }

        public SaveFileDialog AppSaveFileDialog
        {
            get
            {
                return saveFileDialog1;
            }

            set
            {
                saveFileDialog1 = value;
            }
        }
    }
}
