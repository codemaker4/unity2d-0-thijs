using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player : MonoBehaviour {
    public float moveSpeed = 10.0f;
    bool facingRight = true;
    public Animator anim;
    public Rigidbody2D rb;
    public float moveY;
    public int jumps_top;
    private int jumps;
    private float x_vel;

    // Use this for initialization
    void Start () {
        jumps = jumps_top;
    }

    void FlipFacing() {
        facingRight = !facingRight;
        Vector3 charScale = transform.localScale;
        charScale.x = charScale.x * -1;
        transform.localScale = charScale;
    }

    // if  touch anything reset jumps 
    void OnCollisionEnter2D()
    {
        jumps = jumps_top;
    }

    void FixedUpdate() {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        if (move > 0 && !facingRight)
        {
            FlipFacing();
        }
        else if (move < 0 && facingRight)
        {
            FlipFacing();
        }

        // jump
        if (jumps > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                x_vel = rb.velocity.x;
                rb.velocity = new Vector2(x_vel, moveY * Time.deltaTime);
                jumps--;
                if (jumps <= 0)
                {
                    jumps = 0;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
