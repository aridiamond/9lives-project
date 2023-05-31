using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerDead : MonoBehaviour
{
    [SerializeField] GameObject deadLight;
    public int lives;
    public TextMeshProUGUI livesText;

    void Start()
    {
        lives = 9;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && lives > 1)
        {
            Die();
        }
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
        lives -= 1;
        if(lives > 0)
        {
            Instantiate(deadLight, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y), Quaternion.identity);
            this.gameObject.transform.position = new Vector2(0, 0);
            if (lives != 1)
            {
                livesText.text = (lives.ToString() + " lives");
            }
            else
            {
                livesText.text = (lives.ToString() + " life");
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
