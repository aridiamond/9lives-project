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
    int KYS;

    void Start()
    {
        lives = 9;
        KYS = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && lives > 1 && KYS > 0)
        {
            Die();
            KYS -= 1;
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
            Instantiate(deadLight, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - .5f), Quaternion.identity);
            this.gameObject.transform.position = new Vector2(GameObject.Find("StartPoint").transform.position.x, GameObject.Find("StartPoint").transform.position.y);
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
            this.gameObject.transform.position = new Vector2(GameObject.Find("StartPoint").transform.position.x, GameObject.Find("StartPoint").transform.position.y);
            GameObject[] deadPlayer = GameObject.FindGameObjectsWithTag("DeadPlayer");
            foreach(GameObject dead in deadPlayer)
            {
                GameObject.Destroy(dead);
            }
        }
    }
}
