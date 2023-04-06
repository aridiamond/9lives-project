using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDead : MonoBehaviour
{
    [SerializeField] GameObject deadLight;
    public int lives;

    void Start()
    {
        lives = 9;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    void Die()
    {
        if(lives > 0)
        {
            lives -= 1;
            Instantiate(deadLight, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y), Quaternion.identity);
            this.gameObject.transform.position = new Vector2(0, 0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
