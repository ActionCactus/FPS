using UnityEngine;
using UnityEngine.InputSystem;
using FPS.Player.MovementSystems;

[RequireComponent(typeof(MoveSystem))]
public class Sprint : MonoBehaviour
{
    public InputAction sprintButton;
    private MoveSystem playerMovementSystem;
    private System.Type movementSystemType;
    private System.Type currentMoveSystemType;
    private float originalMoveSpeed;
    private bool isSprinting = false;


    void Start()
    {
        this.playerMovementSystem = GetComponent<MoveSystem>();
        this.movementSystemType = this.playerMovementSystem.GetType();
        this.currentMoveSystemType = this.movementSystemType;
        this.originalMoveSpeed = this.playerMovementSystem.MoveSpeedMultiplier;
        this.sprintButton.Enable();
    }

    void Update()
    {
        this.currentMoveSystemType = GetComponent<MoveSystem>().GetType();
        if (this.movementSystemType != this.currentMoveSystemType)
        {
            // May not be needed this frequently - probably will need to be optimized
            // Since MoveSystems will possibly be swappable, make sure we check if
            // it's been changed.
            this.playerMovementSystem = GetComponent<MoveSystem>();
            this.movementSystemType = this.playerMovementSystem.GetType();
            this.originalMoveSpeed = this.playerMovementSystem.MoveSpeedMultiplier;
        }

        // Don't need a null check because of the RequireComponent attribute
        if (!this.isSprinting && this.sprintButton.IsPressed())
        {
            Debug.Log("Pressed!");
            this.playerMovementSystem.MoveSpeedMultiplier = this.playerMovementSystem.MoveSpeedMultiplier * 2;
            this.isSprinting = true;
        }
        else if (this.isSprinting && !this.sprintButton.IsPressed())
        {
            Debug.Log("Released!");
            this.playerMovementSystem.MoveSpeedMultiplier = this.originalMoveSpeed; // division is apparently expensive?  We'll save a tick or two here lol
            this.isSprinting = false;
        }
    }

    public void OnDestroy()
    {
        this.sprintButton.Disable();
    }
}