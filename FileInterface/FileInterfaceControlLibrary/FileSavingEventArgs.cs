using System;

namespace FileInterfaceControlLibrary
{
    public class FileSavingEventArgs : EventArgs
    {
        public FileSavingEventArgs()
        {
        }

        public bool Cancel { get; set; }
    }
}