using UnityEngine;
using UnityEngine.InputSystem;
using FPS.Player.MovementSystems;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MoveSystem))]
public class Crouch : MonoBehaviour
{
    // TODO: because this is so dumb, and does the same thing sprint does, sprinting while crouched will
    // mess up the move speed
    public InputAction InputAction;
    public float moveSpeedReductionMultiplier = 0.5f;

    private Collider playerCollider;
    private Transform playerTransform;
    private MoveSystem playerMoveSystem;
    private bool isCrouched;
    private float originalMoveSpeed;


    public void Start()
    {
        this.playerCollider = this.GetComponent<Collider>();
        this.playerTransform = this.GetComponent<Transform>();
        this.playerMoveSystem = this.GetComponent<MoveSystem>();
        this.originalMoveSpeed = this.playerMoveSystem.MoveSpeedMultiplier;
        this.InputAction.Enable();
    }

    public void Update()
    {
        if (!this.isCrouched && this.InputAction.IsPressed())
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
            this.originalMoveSpeed = this.playerMoveSystem.MoveSpeedMultiplier;
            this.playerMoveSystem.MoveSpeedMultiplier = this.playerMoveSystem.MoveSpeedMultiplier * this.moveSpeedReductionMultiplier;
            this.isCrouched = true;
        }
        else if (this.isCrouched && !this.InputAction.IsPressed())
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
            this.playerMoveSystem.MoveSpeedMultiplier = this.originalMoveSpeed;
            this.isCrouched = false;
        }
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }
}
