//-----------------------------------------------------------------------
// <copyright file="NewFileGenerator.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Defines the <see cref="NewFileGenerator" />.
    /// </summary>
    public partial class NewFileGenerator : Component
    {
        /// <summary>
        /// Defines the rootName.
        /// </summary>
        private string rootName;

        /// <summary>
        /// Defines the extension.
        /// </summary>
        private string extension;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewFileGenerator"/> class.
        /// </summary>
        public NewFileGenerator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewFileGenerator"/> class.
        /// </summary>
        /// <param name="container"></param>
        public NewFileGenerator(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the RootName.
        /// </summary>
        /// 
        [Description("The root name of application filename.")]
        [DefaultValue("Application")]
        public string RootName
        {
            get
            {
                return rootName;
            }

            set
            {
                rootName = value;
            }
        }

        /// <summary>
        /// Gets or sets the Extension.
        /// </summary>
        /// 
        [Description("The file extension for generated filename")]
        [DefaultValue("txt")]
        public string Extension
        {
            get
            {
                return extension;
            }

            set
            {
                extension = value;
            }
        }

        /// <summary>
        /// The Generate.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string Generate()
        {
            int i = 1;
            string fileName = ProposedFileName(i);
            while (System.IO.File.Exists(fileName))
            {
                i++;
                fileName = ProposedFileName(i);
            }
            return fileName;
        }

        /// <summary>
        /// The ProposedFileName.
        /// </summary>
        /// <param name="v">The <see cref="int"/> suffix of application filename.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string ProposedFileName(int v)
        {
            var currentFolder = System.IO.Directory.GetCurrentDirectory();
            var fileExtension = (!string.IsNullOrEmpty(Extension)) ? "." + Extension : Extension;
            return string.Format(@"{0}\{1}{2}{3}", currentFolder, RootName, v.ToString(), fileExtension);
        }
    }
}
