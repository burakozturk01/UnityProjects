using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform pl;

    private Vector3 d;
    
    // Start is called before the first frame update
    void Start()
    {
        d = transform.position - pl.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pl)
        {
            Destroy(this);
            return;
        }
        Vector3 newPos = pl.position + d;
        newPos.x = 0;
        transform.position = newPos;
    }
}
