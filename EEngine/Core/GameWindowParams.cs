namespace EEngine.Core
{
    public readonly struct
        GameWindowParams
    {
        public int Width { get; }
        public int Height { get; }

        public GameWindowParams(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}