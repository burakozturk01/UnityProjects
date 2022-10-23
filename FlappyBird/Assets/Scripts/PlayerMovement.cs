using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;

    [SerializeField]
    private float jumpForce = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        player.gravityScale = 0f;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            player.gravityScale = 3f;
            Vector2 tmp = player.velocity;
            tmp.y = tmp.y < 0 ? jumpForce : jumpForce * 1.5f;
            player.velocity = tmp;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Ceil"))
            Debug.Log("Game over");
    }
}
