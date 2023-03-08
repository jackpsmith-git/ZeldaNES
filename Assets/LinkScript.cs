using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkScript : MonoBehaviour
{
    Rigidbody2D body;
    BoxCollider2D feetHitbox;

    float horizontal;
    float vertical;
    float moveLimiter = .7f;

    public float runSpeed = 1f;
    public int maxHealth = 3;
    public float currentHealth = 3f;

    public string direction = "";
    private Animator animator;
    Collision2D collision;

    // Awake is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", false);
        feetHitbox = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (body.velocity.x == 0 && body.velocity.y == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        if (body.velocity.x > 0 && body.velocity.y == 0)
        {
            setDirection("right");
        }
        if (body.velocity.x < 0 && body.velocity.y == 0)
        {
            setDirection("left");
        }
        if (body.velocity.x == 0 && body.velocity.y > 0)
        {
            setDirection("up");
        }
        if (body.velocity.x == 0 && body.velocity.y < 0)
        {
            setDirection("down");
        }

        if (body.velocity.x > 0 && body.velocity.y > 0)
        {
            if (Mathf.Abs(body.velocity.x) >= Mathf.Abs(body.velocity.y))
            {
                setDirection("right");
            }
            else
            {
                setDirection("up");
            }
        }
        if (body.velocity.x > 0 && body.velocity.y < 0)
        {
            if (Mathf.Abs(body.velocity.x) >= Mathf.Abs(body.velocity.y))
            {
                setDirection("right");
            }
            else
            {
                setDirection("down");
            }
        }
        if (body.velocity.x < 0 && body.velocity.y > 0)
        {
            if (Mathf.Abs(body.velocity.x) >= Mathf.Abs(body.velocity.y))
            {
                setDirection("left");
            }
            else
            {
                setDirection("up");
            }
        }
        if (body.velocity.x < 0 && body.velocity.y < 0)
        {
            if (Mathf.Abs(body.velocity.x) >= Mathf.Abs(body.velocity.y))
            {
                setDirection("left");
            }
            else
            {
                setDirection("down");
            }
        }
    
        if (direction == "up")
        {
            animator.SetBool("facingUp", true);
            animator.SetBool("facingDown", false);
            animator.SetBool("facingLeft", false);
            animator.SetBool("facingRight", false);
        }
        if (direction == "down")
        {
            animator.SetBool("facingUp", false);
            animator.SetBool("facingDown", true);
            animator.SetBool("facingLeft", false);
            animator.SetBool("facingRight", false);
        }
        if (direction == "left")
        {
            animator.SetBool("facingUp", false);
            animator.SetBool("facingDown", false);
            animator.SetBool("facingLeft", true);
            animator.SetBool("facingRight", false);
        }
        if (direction == "right")
        {
            animator.SetBool("facingUp", false);
            animator.SetBool("facingDown", false);
            animator.SetBool("facingLeft", false);
            animator.SetBool("facingRight", true);
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    public void setDirection(string newDirection)
    {
        direction = newDirection;
    }

    
    
}
