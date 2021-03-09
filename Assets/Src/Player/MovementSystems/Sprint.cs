using UnityEngine;
using UnityEngine.InputSystem;
using FPS.Player.MovementSystems;
using FPS.Player.Data;

[RequireComponent(typeof(MoveSystem))]
[RequireComponent(typeof(MovementData))]
public class Sprint : MonoBehaviour
{
    public InputAction sprintButton;
    public float sprintMultiplier = 1.5f;

    private MovementData playerMovementData;
    private MoveSystem playerMovementSystem;
    private System.Type movementSystemType;
    private System.Type currentMoveSystemType;
    private float originalMoveSpeed;


    public void Start()
    {
        this.playerMovementData = GetComponent<MovementData>();
        this.playerMovementSystem = GetComponent<MoveSystem>();
        this.movementSystemType = this.playerMovementSystem.GetType();
        this.currentMoveSystemType = this.movementSystemType;
        this.originalMoveSpeed = this.playerMovementData.MoveSpeedMultiplier;
        this.sprintButton.Enable();
    }

    public void Update()
    {
        this.currentMoveSystemType = GetComponent<MoveSystem>().GetType();
        if (this.movementSystemType != this.currentMoveSystemType)
        {
            // May not be needed this frequently - probably will need to be optimized
            // Since MoveSystems will possibly be swappable, make sure we check if
            // it's been changed.
            this.playerMovementSystem = GetComponent<MoveSystem>();
            this.movementSystemType = this.playerMovementSystem.GetType();
            this.originalMoveSpeed = this.playerMovementData.MoveSpeedMultiplier;
        }

        // Don't need a null check because of the RequireComponent attribute
        if (!this.playerMovementData.IsActive(PlayerMovementStates.Sprinting) && this.sprintButton.IsPressed())
        {
            this.playerMovementData.MoveSpeedMultiplier = this.playerMovementData.MoveSpeedMultiplier * this.sprintMultiplier;
            this.playerMovementData.SetActive(PlayerMovementStates.Sprinting);
        }
        else if (this.playerMovementData.IsActive(PlayerMovementStates.Sprinting) && !this.sprintButton.IsPressed())
        {
            this.playerMovementData.MoveSpeedMultiplier = this.originalMoveSpeed; // division is apparently expensive?  We'll save a tick or two here lol
            this.playerMovementData.SetInactive(PlayerMovementStates.Sprinting);
        }
    }

    public void OnDestroy()
    {
        this.sprintButton.Disable();
    }
}
