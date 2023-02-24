using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] LayerMask jumpGround;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 500f;
    float moveLR;
    float moveUp;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        moveLR = Input.GetAxisRaw("Horizontal");
        
        if (moveLR != 0f)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * moveLR);
        }
        //fucked up? GetKeyDown and GetButtonDown make it work 20% of the time? why?
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpGround);
    }
}
