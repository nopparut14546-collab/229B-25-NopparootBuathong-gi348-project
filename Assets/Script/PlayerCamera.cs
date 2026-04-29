using UnityEngine;

public class DeadZoneCameraRMB : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0, 2, -6);

    public float deadZoneWidth = 2f;
    public float deadZoneHeight = 1.5f;

    public float followSpeed = 5f;

    public float rotationSpeed = 3f;

    float yaw;
    float pitch;

    void LateUpdate()
    {
        RotateCamera();
        Follow();
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(1)) // ???????????
        {
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * 100f * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * 100f * Time.deltaTime;

            yaw += mouseX;
            pitch -= mouseY;

            pitch = Mathf.Clamp(pitch, -30f, 60f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Follow()
    {
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0);
        Vector3 targetPos = target.position + rot * offset;

        Vector3 desiredPos = transform.position;

        // ?? Dead Zone X
        if (Mathf.Abs(targetPos.x - transform.position.x) > deadZoneWidth)
        {
            desiredPos.x = Mathf.Lerp(transform.position.x, targetPos.x, followSpeed * Time.deltaTime);
        }

        // ?? Dead Zone Y (????????????????)
        if (Mathf.Abs(targetPos.y - transform.position.y) > deadZoneHeight)
        {
            desiredPos.y = Mathf.Lerp(transform.position.y, targetPos.y, followSpeed * Time.deltaTime);
        }

        // Z ??? (?????? lock ?????)
        desiredPos.z = targetPos.z;

        transform.position = desiredPos;

        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}