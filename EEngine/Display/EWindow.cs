using System;
using System.Collections.Generic;
using EEngine.Actors;
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
        private List<IActor> _actors;

        //
        private readonly float[] _vertices =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
            0.5f, -0.5f, 0.0f, // Bottom-right vertex
            0.0f, 0.5f, 0.0f // Top vertex
        };

        private int _vertexBufferObject;

        private int _vertexArrayObject;

        //private Shader _shader;
        //

        public EWindow(bool logEnabled, GameInfo gameInfo)
        {
            _gameInfo = gameInfo;
            _actors = new List<IActor>();
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

        private void RenderFrame(FrameEventArgs obj)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            foreach (var actor in _actors)
            {
                actor.Render();
            }

            _window.SwapBuffers();
        }

        private void UpdateFrame(FrameEventArgs obj)
        {
            foreach (var actor in _actors)
            {
                actor.Update();
            }

            _window.SwapBuffers();
        }

        public void Run()
        {
            _window.Run();
        }
    }
}