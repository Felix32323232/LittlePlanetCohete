using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoLittle : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public Transform planet;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        AlignToPlanet();
    }

    void Move()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) input.y += 1;
        if (Keyboard.current.sKey.isPressed) input.y -= 1;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;

        Vector3 up = (transform.position - planet.position).normalized;
        Vector3 forward = Vector3.Cross(transform.right, up).normalized;
        Vector3 right = Vector3.Cross(up, forward).normalized;

        Vector3 moveDir = (forward * input.y + right * input.x).normalized;

        rb.AddForce(moveDir * moveSpeed, ForceMode.Acceleration);


        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(up * jumpForce, ForceMode.Impulse);
        }
    }

    void AlignToPlanet()
    {
        Vector3 up = (transform.position - planet.position).normalized;

        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, up) * rb.rotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime));
    }
}