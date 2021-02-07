using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

[AddComponentMenu("Player/Movement/ViewDependent2DMove")]
public class ViewDependent2DMove : MonoBehaviour
{
    [Tooltip("The input bindings for this movement system")]
    public InputAction InputAction;

    [Tooltip("The movement speed multiplier for this movement system")]
    public float MoveSpeedMultiplier = 1.0f;

    private Rigidbody playerRigidBody;

    public void Start()
    {
        this.playerRigidBody = GetComponent<Rigidbody>();
        this.InputAction.Enable();
    }

    public void Update()
    {
        if (!this.InputAction.IsPressed())
        {
            return;
        }

        Vector2 inputVector = this.InputAction.ReadValue<Vector2>();
        Vector3 velocity = new Vector3(inputVector.x, 0, inputVector.y);

        this.playerRigidBody.MovePosition(
            this.playerRigidBody.position + velocity * (this.MoveSpeedMultiplier * Time.fixedDeltaTime)
        );
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }
}