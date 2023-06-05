using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    bool levelFinished = false;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
            levelFinished = true;
        }
    }

    void Update()
    {
        if (levelFinished == true && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
