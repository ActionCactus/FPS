using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class FirstPersonInfantryMove : MonoBehaviour
{
    double MoveSpeed = 0.1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveAction(InputAction.CallbackContext context)
    {
        // if (isLocalPlayer)
        // {
        Debug.Log("Here");
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
        // }

        Debug.Log(context.ToString());
    }
}
