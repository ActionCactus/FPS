using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public InputAction InputAction;

    private Rigidbody rigidBody;
    public void Start()
    {
        this.rigidBody = GetComponent<Rigidbody>();
        this.InputAction.Enable();
    }

    public void Update()
    {
        if (!this.InputAction.IsPressed())
        {
            return;
        }

        if (this.rigidBody.velocity.y != 0)
        {
            // If the player is falling, they can't jump!
            // This is stupid, btw.  Use a proper state check
            return;
        }

        this.rigidBody.MovePosition(this.rigidBody.position + new Vector3(0, 0.1f, 0));
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }
}
