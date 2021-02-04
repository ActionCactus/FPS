using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class Network : NetworkBehaviour
{
    void Update()
    {
        if (isLocalPlayer)
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard == null)
            {
                return;
            }


            int horizontalMove = 0;
            if (keyboard.IsPressed((float)Key.A))
            {
                horizontalMove = -1;
            }
            Vector3 movement = new Vector3(horizontalMove, 0, 0);
            transform.position = transform.position + movement;
        }
    }
}
