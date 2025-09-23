using UnityEngine;
using UnityEngine.SceneManagement;

public class pond : MonoBehaviour
{
  
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
