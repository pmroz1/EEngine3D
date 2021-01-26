using System;
using EEngine.Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace EEngine.Display
{
    public class EWindow
    {
        private GameWindow _window;
        //private bool _logEnabled;

        private readonly GameInfo _gameInfo;
        //private GraphicsMode gm;

        public EWindow(bool logEnabled, GameInfo gameInfo)
        {
            _gameInfo = gameInfo;
            if (!logEnabled)
            {
                //_logEnabled = false;
                return;
            }
            Console.WriteLine("EEWindow is connected");
        }

        public void SetUpWindow()
        {
            try
            {
                // _gameInfo = gameInfo;
                // _window = new GameWindow(
                //     _gameInfo.WindowParams.Width,
                //     _gameInfo.WindowParams.Height,
                //     GraphicsMode.Default
                // );
                var nativeWindowSettings = new NativeWindowSettings()
                {
                    Size = new Vector2i(_gameInfo.WindowParams.Width, _gameInfo.WindowParams.Height),
                    Title = _gameInfo.Title,
                };
                _window = new GameWindow(GameWindowSettings.Default, nativeWindowSettings);
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't create window : " + e);
            }
        }

        public void Run()
        {
            _window.Run();
        }
    }
}