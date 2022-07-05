using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerControlScheme _input;
    private Vector2 _moveInput;
    private bool _attack;

    public Vector2 MoveInput => _moveInput;
    public bool Attack => _attack;

    private void OnEnable()
    {
        if (_input == null)
        {
            _input = new PlayerControlScheme();

            _input.Movement.Move.performed += _input => _moveInput = _input.ReadValue<Vector2>();
            _input.Movement.Attack.started += _input => _attack = true;
        }

        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void LateUpdate()
    {
        _attack = false;
    }
}