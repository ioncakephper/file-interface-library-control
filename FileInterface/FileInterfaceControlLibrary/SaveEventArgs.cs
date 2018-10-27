//-----------------------------------------------------------------------
// <copyright file="SaveEventArgs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="SaveEventArgs" />.
    /// </summary>
    public class SaveEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveEventArgs"/> class.
        /// </summary>
        public SaveEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether Failed.
        /// </summary>
        public bool Failed { get; set; }

        /// <summary>
        /// Gets or sets the FileName.
        /// </summary>
        public string FileName { get; set; }
    }
}
