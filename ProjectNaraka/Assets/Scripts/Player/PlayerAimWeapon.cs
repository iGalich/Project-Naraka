using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimWeapon : MonoBehaviour
{
    [SerializeField] private Transform _pivotTransform;
    private Transform _myTrasform;

    private void Start()
    {
        _myTrasform = transform;
    }

    private void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = mousePosition - _myTrasform.position;
        aimDirection.Normalize();

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        _pivotTransform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        worldPosition.z = 0f;
        return worldPosition;
    }
}