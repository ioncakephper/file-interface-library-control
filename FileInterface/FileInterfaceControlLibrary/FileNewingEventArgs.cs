using System;

namespace FileInterfaceControlLibrary
{
    public class FileNewingEventArgs : EventArgs
    {
        public FileNewingEventArgs()
        {
        }

        public bool Cancel { get; set; }
    }
}