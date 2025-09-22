using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Player;
    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Attack!");
            Player.GetComponent<Health>().health -= damage;

        }
        if (Player.GetComponent<Health>().health < 0)
        {
            Debug.Log("Player is dead");
        }
    }
}
