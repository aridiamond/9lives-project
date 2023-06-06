using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject creditsPanel;

    void Start()
    {
        Cursor.visible = true;
    }
    public void GoToMain()
    {
        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    public void GoToCredits()
    {
        creditsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level", 1));
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
