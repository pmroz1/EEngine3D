namespace EEngine.Core
{
    public readonly struct
        GameInfo
    {
        public GameWindowParams WindowParams { get; }
        public string Title { get; }
        private GameType GType { get; }
        private UpdateParameters UpdateParameters { get; }

        public GameInfo(GameType gType, string title, UpdateParameters updateParameters, GameWindowParams windowParams)
        {
            GType = gType;
            Title = title;
            UpdateParameters = updateParameters;
            WindowParams = windowParams;
        }

        public override string ToString() =>
            $"({Title}, {WindowParams.Height}, {WindowParams.Height},{Title}, {GType} {UpdateParameters.UpdatesPerSecond}, {UpdateParameters.FramesPerSecond})";
    }
}