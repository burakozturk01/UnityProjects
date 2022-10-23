using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 25f;

    [SerializeField]
    private bool isGrounded;

    private float movementX;
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walking";
    private string GROUND_TAG = "GroundT";
    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        isGrounded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        movementX = Input.GetAxisRaw("Horizontal");
        //Debug.Log(movementX);
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

        //Player Animation
        if (movementX == 0)
            anim.SetBool(WALK_ANIMATION, false);
        else
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = (movementX < 0);
        }
    }

    void FixedUpdate()
    {
        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Landing collision
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;

        if (col.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }


}
