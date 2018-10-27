//-----------------------------------------------------------------------
// <copyright file="NewEventArgs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="NewEventArgs" />
    /// </summary>
    public class NewEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewEventArgs"/> class.
        /// </summary>
        public NewEventArgs()
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
