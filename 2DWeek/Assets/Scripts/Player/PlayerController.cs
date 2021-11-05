using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody2d;

    public float runSpeed = 5f;
    public float jumpSpeed = 200f;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            int levelMask = LayerMask.GetMask("Level");

            if (Physics2D.BoxCast(transform.position, new Vector2(1, .1f), 0f, Vector2.down, .01f, levelMask))
            {
                Jump();
            }
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rigidBody2d.velocity = new Vector2(runSpeed*Time.deltaTime*horizontalInput, rigidBody2d.velocity.y);

        //Vector2 direction = new Vector2(horizontalInput * runSpeed * Time.deltaTime, 0);

        //rigidBody2d.AddForce(direction);

        if (rigidBody2d.velocity.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(rigidBody2d.velocity.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        if (Mathf.Abs(horizontalInput) > 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, jumpSpeed);
    }
}
