//-----------------------------------------------------------------------
// <copyright file="OpeningEventArgs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileInterfaceControlLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="OpeningEventArgs" />.
    /// </summary>
    public class OpeningEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningEventArgs"/> class.
        /// </summary>
        public OpeningEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether Cancel.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
