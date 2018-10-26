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

        public event EventHandler<ChangeEventArgs> Change;
        public event EventHandler<FileNewingEventArgs> FileNewing;
        public event EventHandler FileNewed;
        public event EventHandler<NewEventArgs> New;
        public event EventHandler<OpeningEventArgs> FileOpening;
        public event EventHandler FileOpened;
        public event EventHandler FileSaved;
        public event EventHandler<FileSavingEventArgs> FileSaving;
        public event EventHandler<OpenEventArgs> Open;
        public event EventHandler<SaveEventArgs> Save;

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

        public bool NewApplicationFile()
        {
            if (SaveApplicationFile())
            {
                if (AllowNewFile())
                {
                    string fileName = NewFileName();
                    if (NewFile(fileName))
                    {
                        AppFileName = fileName;
                        OnFileNewed(new EventArgs());
                        return true;
                    }
                }
            }

            return false;
        }

        protected virtual void OnFileNewed(EventArgs e)
        {
            FileNewed?.Invoke(this, e);
        }

        private bool NewFile(string fileName)
        {
            var e = new NewEventArgs() { FileName = fileName, Failed = false };
            OnNew(e);
            return !e.Failed;            
        }

        protected virtual void OnNew(NewEventArgs e)
        {
            New?.Invoke(this, e);
        }

        private string NewFileName()
        {
            return string.Empty;
        }

        private bool AllowNewFile()
        {
            var e = new FileNewingEventArgs() { Cancel = false };
            OnFileNewing(e);
            return !e.Cancel;
        }

        private void OnFileNewing(FileNewingEventArgs e)
        {
            FileNewing?.Invoke(this, e);
        }

        public bool OpenApplicationFile()
        {
            string fileName = GetOpenFileName();
            if (!string.IsNullOrEmpty(fileName))
            {
                if (SaveApplicationFile())
                {
                    if (AllowOpenFile())
                    {
                        if (OpenFile(fileName))
                        {
                            AppFileName = fileName;
                            OnFileOpened(new EventArgs());
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        protected virtual void OnFileOpened(EventArgs e)
        {
            FileOpened?.Invoke(this, e);
        }

        private bool OpenFile(string fileName)
        {
            var e = new OpenEventArgs() { FileName = fileName, Failed = false };
            OnOpen(e);
            return !e.Failed;
        }

        protected virtual void OnOpen(OpenEventArgs e)
        {
            Open?.Invoke(this, e);
        }

        private bool AllowOpenFile()
        {
            var e = new OpeningEventArgs() { Cancel = false };
            OnFileOpening(e);
            return !e.Cancel;
        }

        protected virtual void OnFileOpening(OpeningEventArgs e)
        {
            FileOpening?.Invoke(this, e);
        }

        private string GetOpenFileName()
        {
            AppOpenFileDialog.FileName = string.Empty;
            var result = AppOpenFileDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                return AppOpenFileDialog.FileName;
            }
            return string.Empty;
        }

        public bool SaveApplicationFile()
        {
            return SaveAsApplicationFile(IsContentChanged());
        }

        private bool IsContentChanged()
        {
            var e = new ChangeEventArgs() { Changed = false };
            OnChange(e);
            return e.Changed;
        }

        protected virtual void OnChange(ChangeEventArgs e)
        {
            Change?.Invoke(this, e);
        }

        public bool SaveAsApplicationFile()
        {
            return SaveAsApplicationFile(false);
        }

        public bool SaveAsApplicationFile(bool askFileName)
        {
            if (askFileName || IsContentChanged() || string.IsNullOrEmpty(AppFileName))
            {
                string fileName = GetSaveFileName(AppFileName);
                if (!string.IsNullOrEmpty(fileName))
                {
                    if (AllowSaveFile())
                    {
                        if (SaveFile(fileName))
                        {
                            AppFileName = fileName;
                            OnFileSaved(new EventArgs());
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        protected virtual void OnFileSaved(EventArgs e)
        {
            FileSaved?.Invoke(this, e);
        }

        private bool SaveFile(string fileName)
        {
            var e = new SaveEventArgs() { FileName = fileName, Failed = false };
            OnSave(e);
            return !e.Failed;
        }

        protected virtual void OnSave(SaveEventArgs e)
        {
            Save?.Invoke(this, e);
        }

        private bool AllowSaveFile()
        {
            var e = new FileSavingEventArgs() { Cancel = false };
            OnFileSaving(e);
            return !e.Cancel;
        }

        protected virtual void OnFileSaving(FileSavingEventArgs e)
        {
            FileSaving?.Invoke(this, e);
        }

        private string GetSaveFileName(string appFileName)
        {
            AppSaveFileDialog.FileName = appFileName;
            var result = AppSaveFileDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                return AppSaveFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
