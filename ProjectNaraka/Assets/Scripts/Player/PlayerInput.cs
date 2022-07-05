using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerControlScheme _input;
    private Vector2 _moveInput;

    public Vector2 MoveInput => _moveInput;

    private void OnEnable()
    {
        if (_input == null)
        {
            _input = new PlayerControlScheme();

            _input.Movement.Move.performed += _input => _moveInput = _input.ReadValue<Vector2>();
        }

        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}