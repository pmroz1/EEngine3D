using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using EEngine.Core;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace EEngine.Actors
{
    public class Actor3D : IActor
    {
        private ActorCoords coords;
        private string actorName;
        public Actor3D(ActorCoords ac, string name)
        {
            coords = ac;
            actorName = name;
        }
        
        public void Render()
        {
            try
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(Color.Aqua);
                foreach (Vector2 x in coords.pts)
                {
                    Console.WriteLine("loading vertice");
                    //GL.Color3(Color.Aqua);
                    // if (color != null)
                    // {
                    //     GL.Color3(color);
                    // }
                    GL.Vertex2(x);
                }
                GL.End();
            }
            catch (Exception e)
            {
                throw new System.NotImplementedException();
            }
        }

        public void Update()
        {
            //throw new System.NotImplementedException();
        }
    }
}