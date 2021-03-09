using UnityEngine;
using UnityEngine.InputSystem;
using FPS.Player.MovementSystems;
using FPS.Player.Data;

/// <summary>
/// Transforms the rigidbody's position based on input from the configured InputAction.  Ignores vertical rotations,
/// effectively only moving the GameObject on flat surfaces.
/// </summary>
[AddComponentMenu("Player/Movement/ViewDependent2DMove")]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MovementData))]
public class ViewDependent2DMove : MoveSystem
{
    [Tooltip("The input bindings for this movement system")]
    public InputAction InputAction;

    private MovementData playerMovementData;
    private Rigidbody playerRigidBody;
    private const float internalMoveSpeedAdjustmentModifier = 10.0f;

    public void Start()
    {
        this.playerMovementData = GetComponent<MovementData>();
        this.playerRigidBody = GetComponent<Rigidbody>();
        this.InputAction.Enable();
    }

    protected override void move()
    {
        if (!this.InputAction.IsPressed())
        {
            return;
        }

        Vector2 inputVector = this.InputAction.ReadValue<Vector2>();
        Vector3 velocity = new Vector3(inputVector.x, 0, inputVector.y);
        velocity = transform.TransformDirection(velocity);

        this.playerRigidBody.MovePosition(
            this.playerRigidBody.position + velocity
            * this.playerMovementData.MoveSpeedMultiplier
            * Time.fixedDeltaTime
            * internalMoveSpeedAdjustmentModifier
        );
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }
}