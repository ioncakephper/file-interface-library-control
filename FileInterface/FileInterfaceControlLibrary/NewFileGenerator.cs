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
        private string rootName = "Application";

        /// <summary>
        /// Defines the extension.
        /// </summary>
        private string extension = ".txt";

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
            while (System.IO.File.Exists(ProposedFileName(i)))
            {
                i++;
            }
            return ProposedFileName(i);
        }

        /// <summary>
        /// The ProposedFileName.
        /// </summary>
        /// <param name="v">The v<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string ProposedFileName(int v)
        {
            var currentFolder = System.IO.Directory.GetCurrentDirectory();
            return string.Format(@"{0}\{1}{2}{3}", currentFolder, RootName, v.ToString(), Extension);
        }
    }
}
