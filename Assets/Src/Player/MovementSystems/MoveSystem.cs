using UnityEngine;

namespace FPS.Player.MovementSystems
{
    public abstract class MoveSystem : MonoBehaviour
    {
        public void FixedUpdate()
        {
            this.move();
        }

        abstract protected void move();
    }
}
