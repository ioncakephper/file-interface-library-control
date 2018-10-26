using System;

namespace FileInterfaceControlLibrary
{
    public class NewEventArgs : EventArgs
    {
        public NewEventArgs()
        {
        }

        public bool Failed { get; set; }
        public string FileName { get; set; }
    }
}