using UnityEngine;
public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 150f;
    [SerializeField] private Transform playerBody = null;
    [SerializeField] private bool cursorStartsLocked = true;
    private float xRotation = 0f;
    private Vector2 mouse = Vector2.zero;
    private Transform trans;
    private void Start()
    {
        if (cursorStartsLocked) Cursor.lockState = CursorLockMode.Locked;
        trans = transform;
    }
    private void Update()
    {
        mouse.x = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouse.y = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouse.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Quaternion rotation = Quaternion.Euler(xRotation, 0f, 0f);

        trans.localRotation = rotation;
        playerBody.Rotate(Vector3.up * mouse.x);
    }
}