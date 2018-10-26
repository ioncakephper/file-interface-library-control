using System;

namespace FileInterfaceControlLibrary
{
    public class ChangeEventArgs : EventArgs
    {
        public ChangeEventArgs()
        {
        }

        public bool Changed { get; set; }
    }
}