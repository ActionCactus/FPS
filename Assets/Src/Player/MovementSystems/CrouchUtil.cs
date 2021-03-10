using UnityEngine;

namespace FPS.Player.MovementSystems
{
    public class CrouchUtil
    {
        public static Vector3 shrink(Vector3 input)
        {
            input.y /= 2;
            return input;
        }

        public static Vector3 unshrink(Vector3 input)
        {
            input.y *= 2;
            return input;
        }
    }
}
