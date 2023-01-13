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
    private Animator animator;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //obtenener el valor de la direccion de movimiento
        horizontal = Input.GetAxisRaw("Horizontal");


        //------------Rotacion---------
        if (horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        //Animacion cuando se mueve
        animator.SetBool("running", horizontal != 0.0f);

        //dibuja un rayo
        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);

        //Lanza un rayo 
        grounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f) ? true : false;
        //if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        //    grounded = true;
        //else
        //    grounded = false;

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
