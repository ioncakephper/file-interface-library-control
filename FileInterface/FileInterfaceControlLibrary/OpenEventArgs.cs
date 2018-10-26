using System;

namespace FileInterfaceControlLibrary
{
    public class OpenEventArgs : EventArgs
    {
        public OpenEventArgs()
        {
        }

        public bool Failed { get; internal set; }
        public string FileName { get; set; }
    }
}