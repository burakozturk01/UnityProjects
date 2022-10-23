using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Death :(");
            Transform t = transform;
            Vector3 tmp = t.position;
            tmp.x = 0f;
            tmp.z = -45f;
            t.rotation = new Quaternion(0f, 0f, 0f,0f);
            t.position = tmp;
        }
    }
}
