using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimWeapon : MonoBehaviour
{
    [SerializeField] private Transform _pivotTransform;
    [SerializeField] private Transform _sprite;
    private Vector3 _mousePosition;
    private Transform _myTrasform;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        _myTrasform = transform;
    }

    private void Update()
    {
        _mousePosition = GetMouseWorldPosition();
        HandleWeaponAim(_mousePosition);
        FlipSprite(_mousePosition);
    }

    private void OnAttack()
    {
        
    }

    private void HandleWeaponAim(Vector3 mousePosition)
    {
        Vector3 aimDirection = mousePosition - _myTrasform.position;
        aimDirection.Normalize();

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _pivotTransform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void FlipSprite(Vector3 mousePosition)
    {
        var num = (mousePosition.x > _myTrasform.position.x) ? 1 : -1;
        _sprite.localScale = new Vector3(num, 1f, 1f);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 worldPosition = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        worldPosition.z = 0f;
        return worldPosition;
    }
}