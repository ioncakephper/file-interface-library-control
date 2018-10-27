//-----------------------------------------------------------------------
// <copyright file="ChangeEventArgs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="ChangeEventArgs" />.
    /// </summary>
    public class ChangeEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeEventArgs"/> class.
        /// </summary>
        public ChangeEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether Changed.
        /// </summary>
        public bool Changed { get; set; }
    }
}
