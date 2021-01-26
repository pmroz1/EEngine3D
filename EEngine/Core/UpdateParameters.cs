namespace EEngine.Core
{
    public readonly struct UpdateParameters
    {
        public UpdateParameters(int framesPerSecond, int updatesPerSecond)
        {
            FramesPerSecond = framesPerSecond;
            UpdatesPerSecond = updatesPerSecond;
        }

        public int UpdatesPerSecond { get; }
        public int FramesPerSecond { get; }
    }
}