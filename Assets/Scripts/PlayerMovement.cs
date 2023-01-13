using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 150f;

    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    private bool grounded;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y) * speed;
    }
}
