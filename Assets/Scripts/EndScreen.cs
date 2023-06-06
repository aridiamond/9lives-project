using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    void Start()
    {
        Cursor.visible = true;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("Level", 1);
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("Level", 1);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
