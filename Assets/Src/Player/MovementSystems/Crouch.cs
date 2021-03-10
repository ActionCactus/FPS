using UnityEngine;
using UnityEngine.InputSystem;
using FPS.Player.MovementSystems;
using FPS.Player.Data;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MoveSystem))]
[RequireComponent(typeof(MovementData))]
public class Crouch : MonoBehaviour
{
    // TODO: because this is so dumb, and does the same thing sprint does, sprinting while crouched will
    // mess up the move speed
    public InputAction InputAction;
    public float moveSpeedReductionMultiplier = 0.5f;

    private MovementData playerMovementData;
    private Collider playerCollider;
    private Transform playerTransform;
    private MoveSystem playerMoveSystem;
    private bool isCrouched;
    private float originalMoveSpeed;


    public void Start()
    {
        this.playerMovementData = this.GetComponent<MovementData>();
        this.playerCollider = this.GetComponent<Collider>();
        this.playerTransform = this.GetComponent<Transform>();
        this.playerMoveSystem = this.GetComponent<MoveSystem>();
        this.originalMoveSpeed = this.playerMovementData.MoveSpeedMultiplier;
        this.InputAction.Enable();
    }

    public void Update()
    {
        if (this.playerMovementData.IsActive(PlayerMovementStates.Sprinting))
        {
            // defer to the crouch slide component
            return;
        }

        if (!this.playerMovementData.IsActive(PlayerMovementStates.Crouched) && this.InputAction.IsPressed())
        {
            // shrink
            this.playerCollider.transform.localScale = CrouchUtil.shrink(this.playerCollider.transform.localScale);
            this.playerTransform.transform.localScale = CrouchUtil.shrink(this.playerTransform.transform.localScale);
            this.originalMoveSpeed = this.playerMovementData.MoveSpeedMultiplier;
            this.playerMovementData.MoveSpeedMultiplier = this.playerMovementData.MoveSpeedMultiplier * this.moveSpeedReductionMultiplier;
            this.playerMovementData.SetActive(PlayerMovementStates.Crouched);
        }
        else if (this.playerMovementData.IsActive(PlayerMovementStates.Crouched) && !this.InputAction.IsPressed())
        {
            // grow
            this.playerCollider.transform.localScale = CrouchUtil.unshrink(this.playerCollider.transform.localScale);
            this.playerTransform.transform.localScale = CrouchUtil.unshrink(this.playerTransform.transform.localScale);
            this.playerMovementData.MoveSpeedMultiplier = this.originalMoveSpeed;
            this.playerMovementData.SetInactive(PlayerMovementStates.Crouched);
        }
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }
}
