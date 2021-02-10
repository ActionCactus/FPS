using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Crouch : MonoBehaviour
{
    public InputAction InputAction;

    private Collider playerCollider;
    private Transform playerTransform;
    private bool isCrouched;
    private Vector3 crouchedScale = new Vector3(1, 2, 3);
    private Vector3 fullScale;

    public void Start()
    {
        this.playerCollider = this.GetComponent<Collider>();
        this.playerTransform = this.GetComponent<Transform>();
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
            this.isCrouched = false;
        }
    }

    public void OnDestroy()
    {
        this.InputAction.Disable();
    }
}
