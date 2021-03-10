using UnityEngine;
using FPS.Player.Data;

[RequireComponent(typeof(MovementData))]
public class CrouchSlide : MonoBehaviour
{
    private MovementData movementData;

    public void Start()
    {
        this.movementData = GetComponent<MovementData>();
    }

    public void Update()
    {
        if (this.movementData.IsActive(PlayerMovementStates.Sprinting))
        {

        }
    }
}
