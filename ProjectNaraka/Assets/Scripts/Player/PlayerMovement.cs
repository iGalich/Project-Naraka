using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    private PlayerInput _playerInput;
    private Rigidbody2D _body;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _body.velocity = _moveSpeed * _playerInput.MoveInput * Time.fixedDeltaTime;
    }
}