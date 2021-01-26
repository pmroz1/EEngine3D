using System;
using EEngine.Core;
using EEngine.Display;


namespace Runner3D
{
    public static class Runner3D
    {
        public static void Main()
        {
            Console.WriteLine("Hello World");
            var info = new GameInfo(
                GameType.Game3D, "Runner3D",
                new UpdateParameters(60, 30),
                new GameWindowParams(800, 480)
            );
            EWindow game = new EWindow(true, info);

            game.SetUpWindow();
            game.Run();
        }
    }
}