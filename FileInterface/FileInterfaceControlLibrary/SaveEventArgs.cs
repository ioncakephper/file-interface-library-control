using System;

namespace FileInterfaceControlLibrary
{
    public class SaveEventArgs : EventArgs
    {
        public SaveEventArgs()
        {
        }

        public bool Failed { get; set; }
        public string FileName { get; set; }
    }
}