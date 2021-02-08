using UnityEngine;
using UnityEngine.InputSystem;

[AddComponentMenu("Player/Movement/FreeLook")]
[RequireComponent(typeof(Rigidbody))]
public class FreeLook : MonoBehaviour
{
    [Tooltip("The input bindings for this movement system")]
    public InputAction InputAction;

    [Tooltip("Adjusts the sensitivity of the look movement.  Higher values equate to faster rotation speeds.")]
    public float LookSensitivityMultiplier = 1.0f;

    private Rigidbody playerRigidBody;
    public void Start()
    {
        this.playerRigidBody = GetComponent<Rigidbody>();
        this.InputAction.Enable();
    }

    public void Update()
    {
        Vector2 inputVector = this.InputAction.ReadValue<Vector2>();
        Vector3 rotation = new Vector3(0, inputVector.x, 0);

        if (rotation == Vector3.zero)
        {
            return;
        }

        this.playerRigidBody.MoveRotation(playerRigidBody.rotation * Quaternion.Euler(rotation));
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }
}
