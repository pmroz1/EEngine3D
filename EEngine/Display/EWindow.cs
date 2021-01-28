using System;
using System.Collections.Generic;
using System.Drawing;
using EEngine.Actors;
using EEngine.Core;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
// using OpenTK.Graphics.OpenGL4;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EEngine.Display
{
    public class EWindow
    {
        private GameWindow _window;

        //private bool _logEnabled;
        private readonly GameInfo _gameInfo;
        //private GraphicsMode gm;
        private List<IActor> _actors;
        
        public EWindow(string gameTitle, int width, int height, GameInfo gameInfo)
        {
            _gameInfo = gameInfo;
            _actors = new List<IActor>();
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(_gameInfo.WindowParams.Width, _gameInfo.WindowParams.Height),
                Title = _gameInfo.Title,
            };
            _window = new GameWindow(GameWindowSettings.Default, nativeWindowSettings);
            _window.UpdateFrame += UpdateFrame;
            _window.RenderFrame += RenderFrame;
            _window.Load += OnLoad;
            _window.Unload += OnUnload;

            GL.Enable(EnableCap.Texture2D);
            Console.WriteLine("EEWindow is connected");
        }

        private void OnLoad()
        {
            _window.VSync = VSyncMode.On;
        }

        private void RenderFrame(FrameEventArgs obj)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            ClearBackground();
            Console.WriteLine("Clearing Background");
            foreach (IActor a in _actors)
            {
                a.Render();
                Console.WriteLine("RenderingObject");
            }
            //without swapping we will have 2-3fps
            _window.SwapBuffers();
            //_window.SwapBuffers();
        }

        private void UpdateFrame(FrameEventArgs obj)
        {
            foreach (var actor in _actors)
            {
                actor.Update();
            }
        }

        public void AddActor(Actor3D ac)
        {
            _actors.Add(ac);
        }
        
        private void ClearBackground()
        {
            //clears all color pixels
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.Bisque);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        public void Cube(float size)
        {
            // GL.Color3(col);
            // GL.Begin(PrimitiveType.Quads);
            // GL.Vertex3(x, y, z);
            // GL.Vertex3(x + cx, y, z);
            // GL.Vertex3(x + cx, y + cy, z);
            // GL.Vertex3(x, y + cy, z);
            // GL.End();


            float[,] n = new float[,]
            {
                {-1.0f, 0.0f, 0.0f},
                {0.0f, 1.0f, 0.0f},
                {1.0f, 0.0f, 0.0f},
                {0.0f, -1.0f, 0.0f},
                {0.0f, 0.0f, 1.0f},
                {0.0f, 0.0f, -1.0f}
            };
            int[,] faces = new int[,]
            {
                {0, 1, 2, 3},
                {3, 2, 6, 7},
                {7, 6, 5, 4},
                {4, 5, 1, 0},
                {5, 6, 2, 1},
                {7, 4, 0, 3}
            };
            float[,] v = new float[8, 3];
            int i;

            v[0, 0] = v[1, 0] = v[2, 0] = v[3, 0] = -size / 2;
            v[4, 0] = v[5, 0] = v[6, 0] = v[7, 0] = size / 2;
            v[0, 1] = v[1, 1] = v[4, 1] = v[5, 1] = -size / 2;
            v[2, 1] = v[3, 1] = v[6, 1] = v[7, 1] = size / 2;
            v[0, 2] = v[3, 2] = v[4, 2] = v[7, 2] = -size / 2;
            v[1, 2] = v[2, 2] = v[5, 2] = v[6, 2] = size / 2;
            
            GL.Begin(BeginMode.Quads);
            for (i = 5; i >= 0; i--)
            {
                GL.Normal3(ref n[i, 0]);
                GL.Vertex3(ref v[faces[i, 0], 0]);
                GL.Vertex3(ref v[faces[i, 1], 0]);
                GL.Vertex3(ref v[faces[i, 2], 0]);
                GL.Vertex3(ref v[faces[i, 3], 0]);
            }

            GL.End();
        }

        protected void OnUnload()
        {
            // Unbind all the resources by binding the targets to 0/null.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);
            // GL.DeleteProgram(_shader.Handle);
        }

        public void Run()
        {
            _window.Run();
        }
    }
}