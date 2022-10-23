using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public Transform pl;

    public float speed = 5f;
    public float horizontalSpeed = 10f;

    void FixedUpdate()
    {
        Vector3 tmp = rb.velocity;
        tmp.z = speed;

        float dir = Input.GetAxis("Horizontal");

        if (dir < 0 && pl.position.x > -6.5f)
            tmp.x = -horizontalSpeed;
        else if (dir > 0 && pl.position.x < 6.5f)
            tmp.x = horizontalSpeed;
        else
            tmp.x = 0;

        rb.velocity = tmp;
    }
}
