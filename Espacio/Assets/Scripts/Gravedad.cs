using UnityEngine;

public class Gravedad : MonoBehaviour
{
    public float planetMass = 100000f;  
    public float gravityConstant = 0.6674f;
    public float gravityForce = 9.81f;  
    public Rigidbody[] bodies;

    void FixedUpdate()
    {


        foreach (Rigidbody rb in bodies)
        {
            ApplyGravity(rb);
        }
    }

    void ApplyGravity(Rigidbody rb)
    {
        Vector3 direction = transform.position - rb.position;
        float distance = direction.magnitude;

        if (distance == 0f) return;

        direction.Normalize();

        float m1 = rb.mass;       
        float m2 = planetMass;    


        float forceMagnitude = gravityConstant * (m1 * m2) / (distance * distance);

        Vector3 force = direction * forceMagnitude;

        rb.AddForce(force);
    }
}