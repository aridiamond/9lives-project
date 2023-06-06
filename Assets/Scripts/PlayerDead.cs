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
    bool dying;
    public Renderer rend;
    public Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        lives = 9;
        KYS = 1;
        dying = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && lives > 1 && KYS > 0 && dying == false)
        {
            StartCoroutine(Death());
            KYS -= 1;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Obstacle") && dying == false)
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        dying = true;
        rend.enabled = false;
        body.constraints = RigidbodyConstraints2D.FreezeAll;
        lives -= 1;
        if(lives > 0)
        {
            Instantiate(deadLight, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - .5f), Quaternion.identity);
        }
        else
        {
            GameObject[] deadPlayer = GameObject.FindGameObjectsWithTag("DeadPlayer");
            foreach(GameObject dead in deadPlayer)
            {
                GameObject.Destroy(dead);
            }
        }
        yield return new WaitForSeconds(0.5f);
        this.gameObject.transform.position = new Vector2(GameObject.Find("StartPoint").transform.position.x, 0);
        if (lives != 1)
        {
            livesText.text = (lives.ToString() + " lives");
        }
        else
        {
            livesText.text = (lives.ToString() + " life");
        }
        rend.enabled = true;
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        dying = false;
    }
}
