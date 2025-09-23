using UnityEngine;
using UnityEngine.Rendering;

public class Attaxk : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public Animator spider;

    public SpriteRenderer sr;

    public GameObject AttackPoint;

    public float Radius;

    public float damage = 1;

    public LayerMask ENEMIES;
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
    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(AttackPoint.transform.position, Radius, ENEMIES);
        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Attacked enemy");
            enemyGameObject.GetComponent<EnemyHealth>().Health -= damage; 
        }
    }
    public void endAttack()
    {
        spider.SetBool("IsAttacking", false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPoint.transform.position, Radius);
    }
}
