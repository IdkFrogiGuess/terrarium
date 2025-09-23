using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health;
    public GameObject self;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            Destroy(self);
            Debug.Log(" Enemy Has died");
        }
    }
}
