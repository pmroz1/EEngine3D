using OpenTK.Mathematics;

namespace EEngine.Core
{
    public class ActorCoords
    {
        public Vector2[] pts;

        public ActorCoords(Vector2[] coords)
        {
            pts = new Vector2[coords.Length];
            for (int i = 0; i < coords.Length; ++i)
            {
                pts[i] = coords[i];
            }
        }
    }
}