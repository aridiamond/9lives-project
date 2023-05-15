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
    private Animator anim;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        moveLR = Input.GetAxisRaw("Horizontal");
        
        if (moveLR > 0f && !isCollidingRight())
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * moveLR);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetBool("running", true);
        }
        if (moveLR < 0f && !isCollidingLeft())
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * moveLR);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetBool("running", true);
        }
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        if (moveLR == 0f)
        {
            anim.SetBool("running", false);
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
