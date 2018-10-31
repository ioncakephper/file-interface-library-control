//------------------------------------------------------------------------------------
// <copyright file="FileInterface.cs" company="Ion Gireada">
//    Copyright (c) 2018 Ion Gireada
// </copyright>
//------------------------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="FileInterface" />
    /// </summary>
    public partial class FileInterface : Component
    {
        /// <summary>
        /// Defines the appFileName
        /// </summary>
        private string appFileName = string.Empty;

        /// <summary>
        /// Defines the Change
        /// </summary>
        [Description("Occurs whenever the application needs to know whether content has changed.")]
        public event EventHandler<ChangeEventArgs> Change;

        /// <summary>
        /// Defines the FileNewing
        /// </summary>
        [Description("Occurs whenever the application creates a new file, before the file has been created and specifies whether creating the file was cancelled.")]
        public event EventHandler<FileNewingEventArgs> FileNewing;

        /// <summary>
        /// Defines the FileNewed
        /// </summary>
        [Description("Occurs whenever the application creates a new file, after the file has been created.")]
        public event EventHandler FileNewed;

        /// <summary>
        /// Defines the FileOpening
        /// </summary>
        /// 
        [Description("Occurs whenever the application opens a file, before the file has been opened and specifies whether opening the file was cancelled.")]
        public event EventHandler<OpeningEventArgs> FileOpening;

        /// <summary>
        /// Defines the FileOpened
        /// </summary>
        /// 
        [Description("Occurs whenever the application opens a file, after the file has been opened.")]
        public event EventHandler FileOpened;

        /// <summary>
        /// Defines the FileSaved
        /// </summary>
        /// 
        [Description("Occurs whenever the application saves a file, after the file has been saved.")]
        public event EventHandler FileSaved;

        /// <summary>
        /// Defines the FileSaving
        /// </summary>
        [Description("Occurs whenever the application saves a file, before the file has been saved and specifies whether saving the file was cancelled.")]
        public event EventHandler<FileSavingEventArgs> FileSaving;

        /// <summary>
        /// Defines the Open
        /// </summary>
        /// 
        [Description("Occurs whenever the application opens a file.")]
        public event EventHandler<OpenEventArgs> Open;

        /// <summary>
        /// Defines the Save
        /// </summary>
        /// 
        [Description("Occurs whenever the application saves a file.")]
        public event EventHandler<SaveEventArgs> Save;

        /// <summary>
        /// Defines the New
        /// </summary>
        [Description("Occurs whenever the application creates a new file.")]
        public event EventHandler<NewEventArgs> New;

        /// <summary>
        /// Defines the AppFileNameChanged
        /// </summary>
        public event EventHandler AppFileNameChanged;

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
        /// <param name="container">The container<see cref="IContainer"/></param>
        public FileInterface(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the AppFileName
        /// </summary>
        [Browsable(true)]
        [Description("The current filename the application is using.")]
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

        /// <summary>
        /// Gets or sets the AppOpenFileDialog
        /// </summary>
        [Browsable(true)]
        public OpenFileDialog OpenFileDialog
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
        /// Gets or sets the AppSaveFileDialog
        /// </summary>
        /// 
        [Browsable(true)]
        public SaveFileDialog SaveFileDialog
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
        /// Gets or sets the NewFileGenerator
        /// </summary>
        [Browsable(true)]
        [Description("Generates the next application filename.")]
        public NewFilenameGenerator NewFilenameGenerator
        {
            get { return newFileGenerator1; }
            set { newFileGenerator1 = value; }
        }

        /// <summary>
        /// The NewApplicationFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool NewApplicationFile()
        {
            if (AllowNewFile())
            {
                if (SaveApplicationFile())
                {
                    var fileName = NewFileName();
                    if (NewFile(fileName))
                    {
                        AppFileName = fileName;
                        OnAppFileNameChanged(new AppFileNameChangedEventArgs() { FileName = AppFileName });
                        OnFileNewed(new EventArgs());
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The OnAppFileNameChanged
        /// </summary>
        /// <param name="e">The e<see cref="AppFileNameChangedEventArgs"/></param>
        protected virtual void OnAppFileNameChanged(AppFileNameChangedEventArgs e)
        {
            AppFileNameChanged?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFileNewed
        /// </summary>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        protected virtual void OnFileNewed(EventArgs e)
        {
            FileNewed?.Invoke(this, e);
        }

        /// <summary>
        /// The NewFile
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool NewFile(string fileName)
        {
            var e = new NewEventArgs() { FileName = fileName, Failed = false };
            OnNew(e);
            return !e.Failed;
        }

        /// <summary>
        /// The OnNew
        /// </summary>
        /// <param name="e">The e<see cref="NewEventArgs"/></param>
        protected virtual void OnNew(NewEventArgs e)
        {
            New?.Invoke(this, e);
        }

        /// <summary>
        /// The NewFileName
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        private string NewFileName()
        {
            return NewFilenameGenerator.Generate();
        }

        /// <summary>
        /// The AllowNewFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool AllowNewFile()
        {
            var e = new FileNewingEventArgs() { Cancel = false };
            OnFileNewing(e);
            return !e.Cancel;
        }

        /// <summary>
        /// The OnFileNewing
        /// </summary>
        /// <param name="e">The e<see cref="FileNewingEventArgs"/></param>
        private void OnFileNewing(FileNewingEventArgs e)
        {
            FileNewing?.Invoke(this, e);
        }

        /// <summary>
        /// The OpenApplicationFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool OpenApplicationFile()
        {
            var fileName = GetOpenFileName();
            if (!string.IsNullOrEmpty(fileName) && SaveApplicationFile() && AllowOpenFile() && OpenFile(fileName))
            {
                AppFileName = fileName;
                OnAppFileNameChanged(new AppFileNameChangedEventArgs() { FileName = AppFileName });
                OnFileOpened(new EventArgs());
                return true;
            }

            return false;
        }

        /// <summary>
        /// The OnFileOpened
        /// </summary>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        protected virtual void OnFileOpened(EventArgs e)
        {
            FileOpened?.Invoke(this, e);
        }

        /// <summary>
        /// The OpenFile
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool OpenFile(string fileName)
        {
            var e = new OpenEventArgs() { FileName = fileName, Failed = false };
            OnOpen(e);
            return !e.Failed;
        }

        /// <summary>
        /// The OnOpen
        /// </summary>
        /// <param name="e">The e<see cref="OpenEventArgs"/></param>
        protected virtual void OnOpen(OpenEventArgs e)
        {
            Open?.Invoke(this, e);
        }

        /// <summary>
        /// The AllowOpenFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool AllowOpenFile()
        {
            var e = new OpeningEventArgs() { Cancel = false };
            OnFileOpening(e);
            return !e.Cancel;
        }

        /// <summary>
        /// The OnFileOpening
        /// </summary>
        /// <param name="e">The e<see cref="OpeningEventArgs"/></param>
        protected virtual void OnFileOpening(OpeningEventArgs e)
        {
            FileOpening?.Invoke(this, e);
        }

        /// <summary>
        /// The GetOpenFileName
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        private string GetOpenFileName()
        {
            OpenFileDialog.FileName = string.Empty;
            var result = OpenFileDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                return OpenFileDialog.FileName;
            }
            return string.Empty;
        }

        /// <summary>
        /// The SaveApplicationFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool SaveApplicationFile()
        {
            return SaveAsApplicationFile(IsContentChanged());
        }

        /// <summary>
        /// The IsContentChanged
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool IsContentChanged()
        {
            var e = new ChangeEventArgs() { Changed = false };
            OnChange(e);
            return e.Changed;
        }

        /// <summary>
        /// The OnChange
        /// </summary>
        /// <param name="e">The e<see cref="ChangeEventArgs"/></param>
        protected virtual void OnChange(ChangeEventArgs e)
        {
            Change?.Invoke(this, e);
        }

        /// <summary>
        /// The SaveAsApplicationFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool SaveAsApplicationFile()
        {
            return SaveAsApplicationFile(false);
        }

        /// <summary>
        /// The SaveAsApplicationFile
        /// </summary>
        /// <param name="askFileName">The askFileName<see cref="bool"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool SaveAsApplicationFile(bool askFileName)
        {
            if (askFileName || string.IsNullOrEmpty(AppFileName))
            {
                var fileName = GetSaveFileName(AppFileName);
                if (!string.IsNullOrEmpty(fileName) && AllowSaveFile() && SaveFile(fileName))
                {
                    AppFileName = fileName;
                    OnAppFileNameChanged(new AppFileNameChangedEventArgs() { FileName = AppFileName });
                    OnFileSaved(new EventArgs());
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The OnFileSaved
        /// </summary>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        protected virtual void OnFileSaved(EventArgs e)
        {
            FileSaved?.Invoke(this, e);
        }

        /// <summary>
        /// The SaveFile
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool SaveFile(string fileName)
        {
            var e = new SaveEventArgs() { FileName = fileName, Failed = false };
            OnSave(e);
            return !e.Failed;
        }

        /// <summary>
        /// The OnSave
        /// </summary>
        /// <param name="e">The e<see cref="SaveEventArgs"/></param>
        protected virtual void OnSave(SaveEventArgs e)
        {
            Save?.Invoke(this, e);
        }

        /// <summary>
        /// The AllowSaveFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        private bool AllowSaveFile()
        {
            var e = new FileSavingEventArgs() { Cancel = false };
            OnFileSaving(e);
            return !e.Cancel;
        }

        /// <summary>
        /// The OnFileSaving
        /// </summary>
        /// <param name="e">The e<see cref="FileSavingEventArgs"/></param>
        protected virtual void OnFileSaving(FileSavingEventArgs e)
        {
            FileSaving?.Invoke(this, e);
        }

        /// <summary>
        /// The GetSaveFileName
        /// </summary>
        /// <param name="appFileName">The appFileName<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        private string GetSaveFileName(string appFileName)
        {
            SaveFileDialog.FileName = appFileName;
            var result = SaveFileDialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                return SaveFileDialog.FileName;
            }

            return string.Empty;
        }
    }
}
