using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerControlSystem inputActions;
    public Vector2 moveInput;
    public bool jumpInput;
    public float JumpInputHoldTimer;
    public bool Attack;

    private void Awake()
    {
        inputActions = new PlayerControlSystem();
    }
    public void OnEnable()
    {
        inputActions.Enable();
    }
    public void OnDisable()
    {
        inputActions.Disable();
    }

    public void MoveInputCancelled()
    {
        inputActions.Player1.Move.Disable();
    }
    public void MoveInputPerformed()
    {
        inputActions.Player1.Move.Enable();
    }
    void Update()
    {
        inputActions.Player1.Attack.performed += ctx => Attack = true;
        inputActions.Player1.Attack.canceled += ctx => Attack = false;
        
    }

    public void OnmoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveInput = Vector2.zero;
        }
    }
    public void OnjumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpInput = true;
            JumpInputHoldTimer = Time.time;
        }
        else if (context.performed)
        {
            if (Time.time - JumpInputHoldTimer >= 0.2f)
            {
                jumpInput = false;
            }
        }
        else if (context.canceled)
        {
            jumpInput = false;
        }
    }

}
