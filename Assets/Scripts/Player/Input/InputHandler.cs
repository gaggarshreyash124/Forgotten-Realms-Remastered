using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    public PlayerInput playerInput;
    public Vector2 MovementInput { get; private set; }
    public bool JumpInput { get; private set; }
    void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Enable();
        
        playerInput.Player.Move.performed += ctx => MovementInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled += ctx => MovementInput = Vector2.zero;
        playerInput.Player.Jump.performed += ctx => JumpInput = true;
        playerInput.Player.Jump.canceled += ctx => JumpInput = false;
    }

    void Update()
    {
    }

    public void onMovePerformed(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

}
