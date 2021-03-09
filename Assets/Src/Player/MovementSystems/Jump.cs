using UnityEngine;
using UnityEngine.InputSystem;
using FPS.Player.Data;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MovementData))]
public class Jump : MonoBehaviour
{
    public InputAction InputAction;

    public float groundDistanceCheck = 1f;

    private MovementData playerMovementData;

    private Rigidbody rigidBody;

    public void Start()
    {
        this.playerMovementData = GetComponent<MovementData>();
        this.rigidBody = GetComponent<Rigidbody>();
        this.InputAction.Enable();
    }

    public void Update()
    {
        // TODO: fix for double jump?
        // TODO: this won't work if the player hits & releases the jump button in very rapid succession (IE: two sequential frames, before the player has really moved)
        if (this.isGrounded() && !this.InputAction.IsPressed())
        {
            this.playerMovementData.SetInactive(PlayerMovementStates.Jumping);
        }

        if (!this.InputAction.IsPressed() || this.playerMovementData.IsActive(PlayerMovementStates.Jumping))
        {
            return;
        }

        this.rigidBody.AddForce(new Vector3(0, this.playerMovementData.JumpForce, 0), ForceMode.Impulse);
        this.playerMovementData.SetActive(PlayerMovementStates.Jumping);
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }

    private bool isGrounded()
    {
        return Physics.Raycast(
            transform.position,
            transform.TransformDirection(Vector3.down),
            this.groundDistanceCheck
        );
    }
}
