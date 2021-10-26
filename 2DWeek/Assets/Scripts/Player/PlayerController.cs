using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody2d;

    public float runSpeed = 5f;
    public float jumpSpeed = 200f;

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
            Jump();
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizontalInput * runSpeed * Time.deltaTime, 0);

        rigidBody2d.AddForce(direction);
    }

    void Jump()
    {
        rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, jumpSpeed);
    }
}
