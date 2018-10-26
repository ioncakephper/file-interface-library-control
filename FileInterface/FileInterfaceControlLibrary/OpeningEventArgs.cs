using System;

namespace FileInterfaceControlLibrary
{
    public class OpeningEventArgs : EventArgs
    {
        public OpeningEventArgs()
        {
        }

        public bool Cancel { get; set; }
    }
}