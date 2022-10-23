using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private GameObject[] pipes;
    
    [SerializeField]
    private GameObject prefab;

    private Transform t;
    private bool started;

    // Start is called before the first frame update
    void Start()
    {
        t = GameObject.FindWithTag("Player").transform;
        started = false;
        pipes = new GameObject[5];

        StartCoroutine(nameof(Spawn));
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; ; i = (i+1) % 5)
        {
            if (started)
            {
                if (pipes[i])
                    Destroy(pipes[i]);
                pipes[i] = Instantiate(prefab, new Vector3(10, Random.Range(-5f, -1.5f), 0), new Quaternion(0, 0, 0, 0));
                yield return new WaitForSeconds(Random.Range(2,4));
            }
            else
            {
                started = !t.position.y.Equals(-2f);
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}
