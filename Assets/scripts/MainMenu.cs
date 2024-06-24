using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        AudioManager.instance.ResumeMusic();
        SceneManager.LoadScene(unlockedLevel);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
