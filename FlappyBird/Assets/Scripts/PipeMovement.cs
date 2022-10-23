using UnityEditor;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private Transform t;
    private GameObject obj;
    
    // Start is called before the first frame update
    void Start()
    {
        t = transform;
        obj = t.gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*if (t.position.x < -20)
        {
            Destroy(obj);
        }
        else
        {*/
            Vector2 tmp = t.position;
            tmp.x -= speed * Time.deltaTime;
            t.position = tmp;

            //t.rotation = new Quaternion(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            //}
    }
}
