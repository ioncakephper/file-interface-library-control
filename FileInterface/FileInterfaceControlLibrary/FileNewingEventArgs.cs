//-----------------------------------------------------------------------
// <copyright file="FileNewingEventArgs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="FileNewingEventArgs" />.
    /// </summary>
    public class FileNewingEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileNewingEventArgs"/> class.
        /// </summary>
        public FileNewingEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether Cancel.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
