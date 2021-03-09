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
        if (!this.playerMovementData.IsActive(PlayerMovementStates.Crouched) && this.InputAction.IsPressed())
        {
            // shrink
            this.playerCollider.transform.localScale = new Vector3(
                this.playerCollider.transform.localScale.x,
                this.playerCollider.transform.localScale.y / 2,
                this.playerCollider.transform.localScale.z
            );
            this.playerTransform.transform.localScale = new Vector3(
                this.playerTransform.transform.localScale.x,
                this.playerTransform.transform.localScale.y / 2,
                this.playerTransform.transform.localScale.z
            );
            this.originalMoveSpeed = this.playerMovementData.MoveSpeedMultiplier;
            this.playerMovementData.MoveSpeedMultiplier = this.playerMovementData.MoveSpeedMultiplier * this.moveSpeedReductionMultiplier;
            this.playerMovementData.SetActive(PlayerMovementStates.Crouched);
        }
        else if (this.playerMovementData.IsActive(PlayerMovementStates.Crouched) && !this.InputAction.IsPressed())
        {
            // grow
            this.playerCollider.transform.localScale = new Vector3(
                this.playerCollider.transform.localScale.x,
                this.playerCollider.transform.localScale.y * 2,
                this.playerCollider.transform.localScale.z
            );
            this.playerTransform.transform.localScale = new Vector3(
                this.playerTransform.transform.localScale.x,
                this.playerTransform.transform.localScale.y * 2,
                this.playerTransform.transform.localScale.z
            );
            this.playerMovementData.MoveSpeedMultiplier = this.originalMoveSpeed;
            this.playerMovementData.SetInactive(PlayerMovementStates.Crouched);
        }
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }
}
