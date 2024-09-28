using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static PlayerInput _playerInput;
    public static Vector2 MoveInput { get; set; }
    public static bool _isThrowPressed { get; set; }

    private InputAction _moveAction;
    private InputAction _throwAction;


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _moveAction = _playerInput.actions["Move"];
        _throwAction = _playerInput.actions["Throw"];
    }

    private void Update()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();

        _isThrowPressed = _throwAction.WasPressedThisFrame();
    }
}