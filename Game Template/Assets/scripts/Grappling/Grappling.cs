using UnityEngine;


public class Grappling : MonoBehaviour
{
    Rigidbody2D rb;
    LineRenderer lr;
    DistanceJoint2D dj;
    public LayerMask Grappleable;
    public bool isGrappling;
    Vector3 point;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        dj = GetComponent<DistanceJoint2D>();
        dj.enabled = false;
        lr.enabled = false;
        dj.enableCollision = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.OverlapCircle(point, 0.1f, Grappleable))
            {
                isGrappling = true;
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, point);

                dj.enabled = true;
                dj.connectedAnchor = point;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isGrappling = false;
            lr.enabled = false;
            dj.enabled = false;
        }
        if (isGrappling)
        {
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, point);
        }
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        print(collision);
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Collided with the Ground Grapple is off!");

            isGrappling = false;
            lr.enabled = false;
            dj.enabled = false;
        }
    }
}
