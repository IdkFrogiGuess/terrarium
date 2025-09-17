using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlatformerMovment : MonoBehaviour
{
    public float movespeed;
    public float jumpHeight;
    public bool isGrounded = false;
    public Rigidbody2D rb2d;

    private float _movement;

    void Start()
    {

    }

    void Update()
    {
        rb2d.linearVelocityX = _movement;

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