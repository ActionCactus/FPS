using UnityEngine;

namespace FPS.Player.MovementSystems
{
    public abstract class MoveSystem : MonoBehaviour
    {
        [Tooltip("The movement speed multiplier for this movement system")]
        public float MoveSpeedMultiplier = 1.0f;

        public void FixedUpdate()
        {
            this.move();
        }

        abstract protected void move();
    }
}
