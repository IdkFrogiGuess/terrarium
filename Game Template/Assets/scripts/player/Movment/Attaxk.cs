using UnityEngine;
using UnityEngine.Rendering;

public class Attaxk : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Animator spider;
    public SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spider = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spider.SetBool("IsAttacking", true);
        }
        
    }
    public void endAttack()
    {
        spider.SetBool("IsAttacking", false);
    }
}
