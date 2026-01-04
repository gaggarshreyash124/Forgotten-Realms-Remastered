using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    public PlayerInput playerInput;
    public Vector2 MovementInput { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputReleased { get; private set; }
    private float JumpInputTimer;
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
        }
        else if (context.performed)
        {
        }
        else if (context.canceled)
        {
            JumpInput = false;
        }
    }


}
