using System;

namespace FileInterfaceControlLibrary
{
    public class AppFileNameChangedEventArgs : EventArgs
    {
        public AppFileNameChangedEventArgs()
        {
        }

        public string FileName { get; set; }
    }
}