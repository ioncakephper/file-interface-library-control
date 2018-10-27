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
        /// Defines the ContentChanged.
        /// </summary>
        [Description("Occurs whenever the application checks whether the content changed.")]
        public event EventHandler<ContentChangedEventArgs> ContentChanged;

        /// <summary>
        /// Defines the FileNewing.
        /// </summary>
        [Description("Occurs whenever a new file is created, before the file is created and decides to create a new file.")]
        public event EventHandler<FileNewingEventArgs> FileNewing;

        /// <summary>
        /// Defines the FileNewed.
        /// </summary>
        [Description("Occurs whenever a new file is created, after the file is created.")]
        public event EventHandler FileNewed;

        /// <summary>
        /// Defines the New.
        /// </summary> 
        [Description("Occurs whenever a new file is created.")]
        public event EventHandler<NewEventArgs> New;

        /// <summary>
        /// Defines the FileOpening.
        /// </summary>
        /// 
        [Description("Occurs whenever a file is opened, before the file is opened and decides to open a file.")]
        public event EventHandler<OpeningEventArgs> FileOpening;

        /// <summary>
        /// Defines the FileOpened.
        /// </summary>
        /// 
        [Description("Occurs whenever a file is opened, after the file is opened.")]
        public event EventHandler FileOpened;

        /// <summary>
        /// Defines the FileSaved.
        /// </summary>
        [Description("Occurs whenever a file is saved, after the file is saved.")]
        public event EventHandler FileSaved;

        /// <summary>
        /// Defines the FileSaving.
        /// </summary>
        /// 
        [Description("Occurs whenever a file is saved, before the file is saved and decides to save a file.")]
        public event EventHandler<FileSavingEventArgs> FileSaving;

        /// <summary>
        /// Defines the Open.
        /// </summary> 
        [Description("Occurs whenever a file is opened.")]
        public event EventHandler<OpenEventArgs> Open;

        /// <summary>
        /// Defines the Save.
        /// </summary>
        [Description("Occurs whenever a file is saved.")]
        public event EventHandler<SaveEventArgs> Save;

        /// <summary>
        /// Gets or sets the AppFileName.
        /// </summary>
        [Browsable(true)]
        [Description("The path to application file")]
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
        [Browsable(true)]
        [Description("The generator for a new application filename")]
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
        /// <returns>True if new application file is created, false otherwise.</returns>
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
        /// <returns>True if application file is opened, false otherwise.</returns>
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
        /// <returns>True if application file saved, false otherwise.</returns>
        public bool SaveApplicationFile()
        {
            return SaveAsApplicationFile();
        }

        /// <summary>
        /// The SaveAsApplicationFile.
        /// </summary>
        /// <returns>True if application file is saved with a different name, false otherwise.</returns>
        public bool SaveAsApplicationFile()
        {
            return SaveAsApplicationFile(false);
        }

        /// <summary>
        /// The SaveAsApplicationFile.
        /// </summary>
        /// <param name="askFileName">Indicates whether it will ask for a filename.</param>
        /// <returns>True if application file is saved with a different name, false otherwise.</returns>
        public bool SaveAsApplicationFile(bool askFileName)
        {
            string fileName = AppFileName;
            if (askFileName || string.IsNullOrEmpty(AppFileName))
            {
                fileName = GetSaveFileName(AppFileName);
                if (string.IsNullOrEmpty(fileName))
                {
                    return false;
                }
            }
            if (AllowSaveFile())
            {
                if (SaveFile(fileName))
                {
                    AppFileName = fileName;
                    OnFileSaved(new EventArgs());
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The OnFileNewed.
        /// </summary>
        /// <param name="e">The event argument.</param>
        protected virtual void OnFileNewed(EventArgs e)
        {
            FileNewed?.Invoke(this, e);
        }

        /// <summary>
        /// The OnNew.
        /// </summary>
        /// <param name="e">The new event args.</param>
        protected virtual void OnNew(NewEventArgs e)
        {
            New?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFileOpened.
        /// </summary>
        /// <param name="e">The event args.</param>
        protected virtual void OnFileOpened(EventArgs e)
        {
            FileOpened?.Invoke(this, e);
        }

        /// <summary>
        /// The OnOpen.
        /// </summary>
        /// <param name="e">The open event args.</param>
        protected virtual void OnOpen(OpenEventArgs e)
        {
            Open?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFileOpening.
        /// </summary>
        /// <param name="e">The opening event args.</param>
        protected virtual void OnFileOpening(OpeningEventArgs e)
        {
            FileOpening?.Invoke(this, e);
        }

        /// <summary>
        /// The OnChange.
        /// </summary>
        /// <param name="e">The content changed event args.</param>
        protected virtual void OnChange(ContentChangedEventArgs e)
        {
            ContentChanged?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFileSaved.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnFileSaved(EventArgs e)
        {
            FileSaved?.Invoke(this, e);
        }

        /// <summary>
        /// The OnSave.
        /// </summary>
        /// <param name="e">The save event arguments.</param>
        protected virtual void OnSave(SaveEventArgs e)
        {
            Save?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFileSaving.
        /// </summary>
        /// <param name="e">The file saving event arguments.</param>
        protected virtual void OnFileSaving(FileSavingEventArgs e)
        {
            FileSaving?.Invoke(this, e);
        }

        /// <summary>
        /// The NewFile.
        /// </summary>
        /// <param name="fileName">The path to file to create.</param>
        /// <returns>True if the file is created, false otherwise.</returns>
        private bool NewFile(string fileName)
        {
            var e = new NewEventArgs() { FileName = fileName, Failed = false };
            OnNew(e);
            return !e.Failed;
        }

        /// <summary>
        /// The NewFileName.
        /// </summary>
        /// <returns>Path to new application file.</returns>
        private string NewFileName()
        {
            return NewFileGenerator.Generate();
        }

        /// <summary>
        /// The AllowNewFile.
        /// </summary>
        /// <returns>True if a new file is allowed, false otherwise.</returns>
        private bool AllowNewFile()
        {
            var e = new FileNewingEventArgs() { Cancel = false };
            OnFileNewing(e);
            return !e.Cancel;
        }

        /// <summary>
        /// The OnFileNewing.
        /// </summary>
        /// <param name="e">The file newing event args.</param>
        private void OnFileNewing(FileNewingEventArgs e)
        {
            FileNewing?.Invoke(this, e);
        }

        /// <summary>
        /// The OpenFile.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>True if file is opened, false otherwise.</returns>
        private bool OpenFile(string fileName)
        {
            var e = new OpenEventArgs() { FileName = fileName, Failed = false };
            OnOpen(e);
            return !e.Failed;
        }

        /// <summary>
        /// The AllowOpenFile.
        /// </summary>
        /// <returns>True if opening a file is allowed, false otherwise.</returns>
        private bool AllowOpenFile()
        {
            var e = new OpeningEventArgs() { Cancel = false };
            OnFileOpening(e);
            return !e.Cancel;
        }

        /// <summary>
        /// The GetOpenFileName.
        /// </summary>
        /// <returns>Path of the file to open or empty string.</returns>
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
        /// <returns>True if content changes were detected, false otherwise.</returns>
        private bool IsContentChanged()
        {
            var e = new ContentChangedEventArgs() { Changed = false };
            OnChange(e);
            return e.Changed;
        }

        /// <summary>
        /// The SaveFile.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>True if file was saved, false otherwise.</returns>
        private bool SaveFile(string fileName)
        {
            var e = new SaveEventArgs() { FileName = fileName, Failed = false };
            OnSave(e);
            return !e.Failed;
        }

        /// <summary>
        /// The AllowSaveFile.
        /// </summary>
        /// <returns>True if saving the file is allowed, false otherwise.</returns>
        private bool AllowSaveFile()
        {
            var e = new FileSavingEventArgs() { Cancel = false };
            OnFileSaving(e);
            return !e.Cancel;
        }

        /// <summary>
        /// The GetSaveFileName.
        /// </summary>
        /// <param name="appFileName">Path to application filename.</param>
        /// <returns>Path of the file to create or empty string.</returns>
        private string GetSaveFileName(string appFileName)
        {
            AppSaveFileDialog.FileName = appFileName;
            AppSaveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(appFileName);
            var result = AppSaveFileDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                return AppSaveFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
