using System.Collections;
using UnityEngine;

public class personal : MonoBehaviour
{
    public float MoveSpeed = 1f;

    private SpriteRenderer sr;

    private Animator snail;

    Rigidbody2D rb;

    GameObject PlayerObj;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        StartCoroutine(ChasePlayer());
        sr = GetComponent<SpriteRenderer>();
        snail = GetComponent<Animator>();
    }
    void Update()
    {


        if (rb.linearVelocityX < -.1f)
        {

            sr.flipX = false;
        }
        else if (rb.linearVelocityX > .1f)
        {

            sr.flipX = true;
        }
        else
        {
            snail.SetBool("IsMoving", false);
        }
    }
    IEnumerator ChasePlayer()
    {
        Vector2 DirectionToPlayer = Direction2Points2D(this.transform.position, PlayerObj.transform.position);
        rb.linearVelocity = DirectionToPlayer * MoveSpeed;

        yield return new WaitForSeconds(0.1f);
        StartCoroutine(ChasePlayer());


    }

    Vector2 Direction2Points2D(Vector2 Point1, Vector2 Point2)
    {
        var Direction2D = Point2 - Point1;
        return Direction2D.normalized;
    }
}