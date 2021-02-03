using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Network : NetworkBehaviour
{
    void Update()
    {
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
            transform.position = transform.position + movement;
        }
    }
}
