using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Changes the GameObject's rigidbody rotation based on mouse input.
/// </summary>
[AddComponentMenu("Player/Movement/FreeLook")]
[RequireComponent(typeof(Rigidbody))]
public class FreeLook : MonoBehaviour
{
    [Tooltip("The input bindings for this movement system")]
    public InputAction InputAction;

    [Tooltip("Adjusts the sensitivity of the look movement.  Higher values equate to faster rotation speeds.")]
    public float LookSensitivityMultiplier = 0.1f;

    private Rigidbody playerRigidBody;
    private Camera playerCamera;
    public void Start()
    {
        this.playerRigidBody = GetComponent<Rigidbody>();
        this.playerCamera = GetComponentInChildren<Camera>();
        this.InputAction.Enable();
    }

    public void Update()
    {
        Vector2 inputVector = this.InputAction.ReadValue<Vector2>();
        Vector3 rotation = new Vector3(0, inputVector.x, 0) * this.LookSensitivityMultiplier;

        if (rotation == Vector3.zero)
        {
            return;
        }

        this.playerRigidBody.MoveRotation(playerRigidBody.rotation * Quaternion.Euler(rotation));

        Vector3 verticalRotation = new Vector3(inputVector.y, 0, 0) * this.LookSensitivityMultiplier;
        this.playerCamera.transform.Rotate(-verticalRotation);
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }
}
