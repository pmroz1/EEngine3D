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
    public class EWindow : GameWindow
    {
        public EWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(
            gameWindowSettings, nativeWindowSettings)
        {
            
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            Title = "Runner 3D";
            GL.ClearColor(Color.Aqua);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            SwapBuffers();
            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
 
            GL.MatrixMode(MatrixMode.Modelview);
 
            GL.LoadMatrix(ref modelview);
            GL.Begin(BeginMode.Triangles);
            GL.Vertex3(-1.0f, -1.0f, 4.0f);
 
            GL.Vertex3(1.0f, -1.0f, 4.0f);
 
            GL.Vertex3(0.0f, 1.0f, 4.0f);
            GL.End();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            base.OnResize(e);
 
            GL.Viewport(200, 200, 800, 480);
 
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, 800 / (float)480, 1.0f, 64.0f);
 
            GL.MatrixMode(MatrixMode.Projection);
 
            GL.LoadMatrix(ref projection);
        }
    }
}