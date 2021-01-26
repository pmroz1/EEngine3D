using System;
using EEngine.Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace EEngine.Display
{
    public class EWindow
    {
        private GameWindow _window;
        //private bool _logEnabled;

        private readonly GameInfo _gameInfo;

        //private GraphicsMode gm;
        private

            //
            private readonly float[] _vertices =
            {
                -0.5f, -0.5f, 0.0f, // Bottom-left vertex
                0.5f, -0.5f, 0.0f, // Bottom-right vertex
                0.0f, 0.5f, 0.0f // Top vertex
            };

        private int _vertexBufferObject;

        private int _vertexArrayObject;

        private Shader _shader;
        //

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
                _window.UpdateFrame += UpdateFrame;
                _window.RenderFrame += RenderFrame;
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't create window : " + e);
            }
        }

        private static void RenderFrame(FrameEventArgs obj)
        {
            throw new NotImplementedException();
        }

        private static void UpdateFrame(FrameEventArgs obj)
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            _window.Run();
        }
    }
}