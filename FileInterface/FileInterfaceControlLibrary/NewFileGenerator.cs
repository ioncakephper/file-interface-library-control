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
    /// Defines the <see cref="NewFileGenerator" />
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

        public string Generate()
        {
            if (NotFound(ProposedFileName()))
            {
                return ProposedFileName();
            }
            int lastCount = GetGreatestCount(ProposedFileName());
            return ProposedFileName(lastCount + 1);
        }

        private string ProposedFileName(int v)
        {
            throw new NotImplementedException();
        }

        private int GetGreatestCount(string v)
        {
            throw new NotImplementedException();
        }

        private string ProposedFileName()
        {
            throw new NotImplementedException();
        }

        private bool NotFound(string p)
        {
            throw new NotImplementedException();
        }
    }
}
