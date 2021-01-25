using System;
using OpenTK;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace EEngine.Core
{
    public class EEWindow
    {
        public EEWindow(Boolean logEnabled)
        {
            if (!logEnabled) return;
            
            Console.WriteLine("EEWindow is connected");
            Window win = new Window();
        }
    }
}