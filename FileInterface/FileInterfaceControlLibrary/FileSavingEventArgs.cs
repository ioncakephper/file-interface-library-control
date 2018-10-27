//-----------------------------------------------------------------------
// <copyright file="FileSavingEventArgs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="FileSavingEventArgs" />.
    /// </summary>
    public class FileSavingEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileSavingEventArgs"/> class.
        /// </summary>
        public FileSavingEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether Cancel.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
