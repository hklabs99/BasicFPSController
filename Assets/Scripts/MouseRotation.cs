using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;
    [Space]
    [SerializeField] private Transform _playerBody;

    private float _xRotation = 0;

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _playerBody.Rotate(Vector3.up * mouseX);

        if (UIManager.IsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}