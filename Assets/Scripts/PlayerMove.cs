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
    enum MovementState { idle, running, jumping, falling }
    
    void Start()
    {
        Cursor.visible = false;
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
        }
        if (moveLR < 0f && !isCollidingLeft())
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * moveLR);
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        
        UpdateAnimationState();
    }
    void UpdateAnimationState()
    {
        MovementState state;

        if (moveLR != 0f && isGrounded())
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }        
        anim.SetInteger("state", (int)state);
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
