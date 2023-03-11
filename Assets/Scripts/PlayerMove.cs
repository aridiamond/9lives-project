using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] LayerMask regGround;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 350f;
    float moveLR;
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
        
        if (moveLR > 0f && !isCollidingRight())
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * moveLR);
        }
        if (moveLR < 0f && !isCollidingLeft())
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * moveLR);
        }
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, regGround);
    }
    bool isCollidingLeft()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, 0.1f, regGround);
    }
    bool isCollidingRight()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, 0.1f, regGround);
    }
}
