using System;
using EEngine.Actors;
using EEngine.Core;
using EEngine.Display;
using OpenTK.Mathematics;


namespace Runner3D
{
    public static class Runner3D
    {
        public static void Main()
        {
            Console.WriteLine("Hello World");
            var info = new GameInfo(
                GameType.Game3D, "Runner3D",
                new UpdateParameters(24, 12),
                new GameWindowParams(800, 480)
            );
            
            
            ActorCoords acPlayer = new ActorCoords(new Vector2[]
            {
                new Vector2(0, 0),
                new Vector2(0.2f, 0),
                new Vector2(0.2f, -0.3f),
                new Vector2(0, -0.3f)
            });

            Actor3D ac = new Actor3D(acPlayer, "camera");
            EWindow game = new EWindow("Runner3D", 800, 480, info);
            game.AddActor(ac);
            game.Run();
        }
    }
}