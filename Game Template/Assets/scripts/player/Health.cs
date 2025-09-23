using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public Text healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log(health);
        }
    }
}
