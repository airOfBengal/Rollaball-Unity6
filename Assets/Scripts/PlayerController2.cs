using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    PlayerControls controls;
    Vector2 moveInput;
    public float moveSpeed = 10f;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Buttons.performed += ctx => SendMessage();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void FixedUpdate() {
        Vector3 movement = moveSpeed * Time.fixedDeltaTime * new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(movement, Space.World);
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }

    void SendMessage()
    {
        Debug.Log("Button Pressed");
    }

    void SendMessage(Vector2 coordinates)
    {
        Debug.Log("Thumb-stick coordinates = " + coordinates);
    }
}
