using UnityEngine;

public class Cohete : MonoBehaviour
{
    public Rigidbody rb;

    public float acceleration;
    public float Newtons;

    public bool isLaunching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        acceleration = Newtons / rb.mass;
    }
    
    public void Launch()
    {
        isLaunching = true;
    }

    void FixedUpdate()
    {
        if (isLaunching)
        {
            rb.AddForce(Vector3.up * acceleration, ForceMode.Acceleration);
        }
    }
}