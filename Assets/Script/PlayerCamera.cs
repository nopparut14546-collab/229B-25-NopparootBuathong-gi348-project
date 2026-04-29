using UnityEngine;

public class SimpleTPDCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -4);

    public float mouseSensitivity = 3f;
    public float smoothSpeed = 10f;

    float yaw;
    float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // ??????????????
    }

    void LateUpdate()
    {
        RotateCamera();
        FollowPlayer();
    }

    void RotateCamera()
    {
        // ? ???????????????????????
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

            yaw += mouseX;
            pitch -= mouseY;

            pitch = Mathf.Clamp(pitch, -30f, 60f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void FollowPlayer()
    {
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }

    // ?? ??? Player ??? yaw ????? (??????????????????)
    public float GetYaw()
    {
        return yaw;
    }
}