using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;         // ??????????
    public float doubleJumpForce = 3f;   // ?? ????????????????????? 2 ???
    public float freezeTime = 1.5f;
    public float climbSpeed = 3f;

    public Transform cameraTransform; // ??? Main Camera ?????

    private Rigidbody rb;
    private bool isGrounded;
    private bool canDoubleJump;
    private bool isFrozen;
    private bool isClimbing;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isClimbing)
        {
            Climb();
            return; // ?? ???????????/???????????????
        }

        if (!isFrozen)
        {
            Move();
            RotateWithMouse();
        }

        Jump();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ??????????????????? (TPS ???????????)
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        // ?????? Y ??? (?????????????)
        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 move = camForward * v + camRight * h;
        Vector3 velocity = move * moveSpeed;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }

    void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * 200f * Time.deltaTime;

        // ??????????????????? (??? Y)
        transform.Rotate(0, mouseX, 0);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ??????????????
            if (isGrounded)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
                canDoubleJump = false;
            }
            // ?? ?????????????? 2 (????????????)
            else if (canDoubleJump)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, doubleJumpForce, rb.linearVelocity.z);
                canDoubleJump = false;
            }
        }
    }

    void Climb()
    {
        float v = Input.GetAxis("Vertical"); // W/S

        // ???????/????? input
        rb.linearVelocity = new Vector3(0, v * climbSpeed, 0);

        // ? ?????????
        if (Mathf.Abs(v) < 0.1f)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    void StartClimbing()
    {
        isClimbing = true;

        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;
    }

    void StopClimbing()
    {
        isClimbing = false;

        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            StartClimbing();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Climb"))
        {
            canDoubleJump = true;

            if (!isFrozen)
            {
                StartCoroutine(FreezePlayer());
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            StopClimbing();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    IEnumerator FreezePlayer()
    {
        isFrozen = true;

        rb.linearVelocity = Vector3.zero;
        rb.useGravity = false;

        yield return new WaitForSeconds(freezeTime);

        rb.useGravity = true;
        isFrozen = false;
    }
}