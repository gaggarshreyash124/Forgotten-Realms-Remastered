using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
public class InputHandler : MonoBehaviour
{
    public PlayerInput playerInput;
    public Vector2 MovementInput { get; private set; }
    public bool JumpInput;
    private float JumpInputTimer;
    public bool CanCayoteeJump;
    void Awake()
    {
        playerInput = new PlayerInput();
    }
    void OnEnable()
    {
        playerInput.Enable();
    }
    void OnDisable()
    {
        playerInput.Disable();
    }
    public void onMovePerformed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MovementInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            MovementInput = Vector2.zero;
        }
    }

    public void onJumpPerformed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputTimer = Time.time;
        }
        else if (context.performed)
        {
            if (JumpInputTimer + 0.2f <= Time.time)
            {
                CanCayoteeJump = true;
            }
            else
            {
                CanCayoteeJump = false;
            }
        }
        else if (context.canceled)
        {
            JumpInput = false;
        }

    }
}
