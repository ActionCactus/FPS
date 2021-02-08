using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public InputAction InputAction;

    public float jumpForce = 5f;
    public float groundDistanceCheck = 1f;

    private Rigidbody rigidBody;

    private bool isJumping = false;
    public void Start()
    {
        this.rigidBody = GetComponent<Rigidbody>();
        this.InputAction.Enable();
    }

    public void Update()
    {
        // TODO: fix for double jump?
        // TODO: this won't work if the player hits & releases the jump button in very rapid succession (IE: two sequential frames, before the player has really moved)
        if (this.isGrounded() && !this.InputAction.IsPressed())
        {
            this.isJumping = false;
        }

        if (!this.InputAction.IsPressed() || this.isJumping)
        {
            return;
        }

        this.rigidBody.AddForce(new Vector3(0, this.jumpForce, 0), ForceMode.Impulse);
        this.isJumping = true;
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
