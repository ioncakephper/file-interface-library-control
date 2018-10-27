//-----------------------------------------------------------------------
// <copyright file="FileInterface.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="FileInterface" />.
    /// </summary>
    public partial class FileInterface : Component
    {
        /// <summary>
        /// Defines the appFileName.
        /// </summary>
        private string appFileName = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileInterface"/> class.
        /// </summary>
        public FileInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileInterface"/> class.
        /// </summary>
        /// <param name="container"></param>
        public FileInterface(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Defines the AppFileNameChanged.
        /// </summary>
        public event EventHandler AppFileNameChanged;

        /// <summary>
        /// Defines the Change.
        /// </summary>
        public event EventHandler<ChangeEventArgs> Change;

        /// <summary>
        /// Defines the FileNewing.
        /// </summary>
        public event EventHandler<FileNewingEventArgs> FileNewing;

        /// <summary>
        /// Defines the FileNewed.
        /// </summary>
        public event EventHandler FileNewed;

        /// <summary>
        /// Defines the New.
        /// </summary>
        public event EventHandler<NewEventArgs> New;

        /// <summary>
        /// Defines the FileOpening.
        /// </summary>
        public event EventHandler<OpeningEventArgs> FileOpening;

        /// <summary>
        /// Defines the FileOpened.
        /// </summary>
        public event EventHandler FileOpened;

        /// <summary>
        /// Defines the FileSaved.
        /// </summary>
        public event EventHandler FileSaved;

        /// <summary>
        /// Defines the FileSaving.
        /// </summary>
        public event EventHandler<FileSavingEventArgs> FileSaving;

        /// <summary>
        /// Defines the Open.
        /// </summary>
        public event EventHandler<OpenEventArgs> Open;

        /// <summary>
        /// Defines the Save.
        /// </summary>
        public event EventHandler<SaveEventArgs> Save;

        /// <summary>
        /// Gets or sets the AppFileName.
        /// </summary>
        public string AppFileName
        {
            get
            {
                return appFileName;
            }

            set
            {
                appFileName = value;
                OnAppFileNameChanged(new EventArgs());
            }
        }

        /// <summary>
        /// Gets or sets the New File Generator. 
        /// </summary>
        public NewFileGenerator NewFileGenerator
        {
            get
            {
                return newFileGenerator1;
            }

            set
            {
                newFileGenerator1 = value;
            }
        }

        /// <summary>
        /// The OnAppFileNameChanged.
        /// </summary>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        protected virtual void OnAppFileNameChanged(EventArgs e)
        {
            AppFileNameChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Gets or sets the AppOpenFileDialog.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the AppSaveFileDialog.
        /// </summary>
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

        /// <summary>
        /// The NewApplicationFile.
        /// </summary>
        /// <returns></returns>
        public bool NewApplicationFile()
        {
            if (IsContentChanged())
            {
                if (!SaveApplicationFile())
                {
                    return false;
                }
            }

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

            return false;
        }

        /// <summary>
        /// The OpenApplicationFile.
        /// </summary>
        /// <returns></returns>
        public bool OpenApplicationFile()
        {
            string fileName = GetOpenFileName();
            if (!string.IsNullOrEmpty(fileName))
            {
                if (IsContentChanged())
                {
                    if (!SaveApplicationFile())
                    {
                        return false;
                    }
                }
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
            return false;
        }

        /// <summary>
        /// The SaveApplicationFile.
        /// </summary>
        /// <returns></returns>
        public bool SaveApplicationFile()
        {
            return SaveAsApplicationFile();
        }

        /// <summary>
        /// The SaveAsApplicationFile.
        /// </summary>
        /// <returns></returns>
        public bool SaveAsApplicationFile()
        {
            return SaveAsApplicationFile(false);
        }

        /// <summary>
        /// The SaveAsApplicationFile.
        /// </summary>
        /// <param name="askFileName"></param>
        /// <returns></returns>
        public bool SaveAsApplicationFile(bool askFileName)
        {
            if (askFileName || string.IsNullOrEmpty(AppFileName))
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

        /// <summary>
        /// The OnFileNewed.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileNewed(EventArgs e)
        {
            FileNewed?.Invoke(this, e);
        }

        /// <summary>
        /// The OnNew.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnNew(NewEventArgs e)
        {
            New?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFileOpened.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileOpened(EventArgs e)
        {
            FileOpened?.Invoke(this, e);
        }

        /// <summary>
        /// The OnOpen.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnOpen(OpenEventArgs e)
        {
            Open?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFileOpening.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileOpening(OpeningEventArgs e)
        {
            FileOpening?.Invoke(this, e);
        }

        /// <summary>
        /// The OnChange.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChange(ChangeEventArgs e)
        {
            Change?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFileSaved.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileSaved(EventArgs e)
        {
            FileSaved?.Invoke(this, e);
        }

        /// <summary>
        /// The OnSave.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSave(SaveEventArgs e)
        {
            Save?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFileSaving.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileSaving(FileSavingEventArgs e)
        {
            FileSaving?.Invoke(this, e);
        }

        /// <summary>
        /// The NewFile.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool NewFile(string fileName)
        {
            var e = new NewEventArgs() { FileName = fileName, Failed = false };
            OnNew(e);
            return !e.Failed;
        }

        /// <summary>
        /// The NewFileName.
        /// </summary>
        /// <returns></returns>
        private string NewFileName()
        {
            return NewFileGenerator.Generate();
        }

        /// <summary>
        /// The AllowNewFile.
        /// </summary>
        /// <returns></returns>
        private bool AllowNewFile()
        {
            var e = new FileNewingEventArgs() { Cancel = false };
            OnFileNewing(e);
            return !e.Cancel;
        }

        /// <summary>
        /// The OnFileNewing.
        /// </summary>
        /// <param name="e"></param>
        private void OnFileNewing(FileNewingEventArgs e)
        {
            FileNewing?.Invoke(this, e);
        }

        /// <summary>
        /// The OpenFile.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool OpenFile(string fileName)
        {
            var e = new OpenEventArgs() { FileName = fileName, Failed = false };
            OnOpen(e);
            return !e.Failed;
        }

        /// <summary>
        /// The AllowOpenFile.
        /// </summary>
        /// <returns></returns>
        private bool AllowOpenFile()
        {
            var e = new OpeningEventArgs() { Cancel = false };
            OnFileOpening(e);
            return !e.Cancel;
        }

        /// <summary>
        /// The GetOpenFileName.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// The IsContentChanged.
        /// </summary>
        /// <returns></returns>
        private bool IsContentChanged()
        {
            var e = new ChangeEventArgs() { Changed = false };
            OnChange(e);
            return e.Changed;
        }

        /// <summary>
        /// The SaveFile.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool SaveFile(string fileName)
        {
            var e = new SaveEventArgs() { FileName = fileName, Failed = false };
            OnSave(e);
            return !e.Failed;
        }

        /// <summary>
        /// The AllowSaveFile.
        /// </summary>
        /// <returns></returns>
        private bool AllowSaveFile()
        {
            var e = new FileSavingEventArgs() { Cancel = false };
            OnFileSaving(e);
            return !e.Cancel;
        }

        /// <summary>
        /// The GetSaveFileName.
        /// </summary>
        /// <param name="appFileName"></param>
        /// <returns></returns>
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
