using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerMovment : MonoBehaviour
{
    public float movespeed;
    private Animator spider;
    public float jumpHeight;
    public bool isGrounded = false;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    private float _movement;

    void Start()
    {
        spider = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb2d.linearVelocityX = _movement;

        if (_movement < -.1f)
        {
            spider.SetBool("IsMoving", true);
            sr.flipX = true;
        }
        else if (_movement > .1f)
        {
            spider.SetBool("IsMoving", true);
            sr.flipX = false;
        }
        else
        {
            spider.SetBool("IsMoving", false);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Collided with the Ground!");

            isGrounded = true;
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("left the Ground!");

            isGrounded = false;
        }
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>().x * movespeed;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (isGrounded == true)
        {
            if (ctx.ReadValue<float>() == 1)
            {
                rb2d.linearVelocityY = jumpHeight;
            }
        }
    }
}