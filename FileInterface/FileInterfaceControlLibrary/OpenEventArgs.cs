//-----------------------------------------------------------------------
// <copyright file="OpenEventArgs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="OpenEventArgs" />.
    /// </summary>
    public class OpenEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenEventArgs"/> class.
        /// </summary>
        public OpenEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether Failed.
        /// </summary>
        public bool Failed { get; internal set; }

        /// <summary>
        /// Gets or sets the FileName.
        /// </summary>
        public string FileName { get; set; }
    }
}
