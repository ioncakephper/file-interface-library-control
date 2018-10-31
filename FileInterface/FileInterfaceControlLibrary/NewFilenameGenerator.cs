//------------------------------------------------------------------------------------
// <copyright file="NewFilenameGenerator.cs" company="Ion Gireada">
//    Copyright (c) 2018 Ion Gireada
// </copyright>
//------------------------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System.ComponentModel;
    using System.IO;

    /// <summary>
    /// Defines the <see cref="NewFilenameGenerator" />
    /// </summary>
    public partial class NewFilenameGenerator : Component
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewFilenameGenerator"/> class.
        /// </summary>
        public NewFilenameGenerator()
        {
            InitializeComponent();
            InitializeProperties();
        }

        /// <summary>
        /// The InitializeProperties
        /// </summary>
        private void InitializeProperties()
        {
            RootName = "Application";
            FileExtension = "txt";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewFilenameGenerator"/> class.
        /// </summary>
        /// <param name="container">The container<see cref="IContainer"/></param>
        public NewFilenameGenerator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            InitializeProperties();
        }

        /// <summary>
        /// Gets or sets the FileExtension
        /// </summary>
        [DefaultValue("txt")]
        public string FileExtension { get; set; }

        /// <summary>
        /// Gets or sets the RootName
        /// </summary>
        [DefaultValue("Application")]
        public string RootName { get; set; }

        /// <summary>
        /// Gets or sets the InitialDirectory
        /// </summary>
        public string InitialDirectory { get; set; }

        /// <summary>
        /// The Generate
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public string Generate()
        {
            var index = 1;
            var fileName = BuildNewFileName(index);
            while (System.IO.File.Exists(fileName))
            {
                index++;
                fileName = BuildNewFileName(index);
            }
            return fileName;
        }

        /// <summary>
        /// The BuildNewFileName
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        private string BuildNewFileName(int index)
        {
            var extension = (string.IsNullOrEmpty(FileExtension)) ? "" : "." + FileExtension.Trim();
            var initialDirectory = string.IsNullOrEmpty(InitialDirectory) ? Directory.GetCurrentDirectory() : InitialDirectory.Trim();
            return string.Format(@"{0}\{1}{2}", initialDirectory, RootName + index, extension);
        }
    }
}
