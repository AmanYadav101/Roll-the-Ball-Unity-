using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLineTrigger : MonoBehaviour
{
    /*
    public GameObject respawnPoint;*/

    [Header("-----------Camera and RB------------")]
    public CinemachineVirtualCamera ballCamera;
    public CinemachineVirtualCamera finishLineCamera;
    public Rigidbody rigidbody;

    [Header("-----------UI Elements------------")]
    public RawImage starImage; 
    public TextMeshProUGUI starText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI totalScoreText;
    public Button button;

    [Header("-----------Scene Name------------")]
    public string nextSceneName; // Name of the scene to load
    AudioManager audioManager;
    private void Awake()
    { 

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        
        if(collider.gameObject.name == "Sphere")
        { 

            //Unlocking new level
            UnlockNewLevel();
            //For playing audio at finish
            
            audioManager.PlaySFX(audioManager.finish);

            finishLineCamera.gameObject.SetActive(true);

            //Finish Line Camera Animation
            Animator animator = finishLineCamera.GetComponent<Animator>();
            Scene scene = SceneManager.GetActiveScene();
            animator.SetInteger("Level", int.Parse(scene.name.Substring(6)));
            
            //Making the ball stop at Finish Line
            rigidbody.isKinematic = true;

            //For Enabling the Win Screen
            winText.gameObject.SetActive(true);
            starImage.gameObject.SetActive(false);
            totalScoreText.gameObject.SetActive(true);
            starText.gameObject.SetActive(false);   
            button.gameObject.SetActive(true);
            

            //Loads the next Scene after a mentioned time in secs
            StartCoroutine(LoadNextSceneAfterDelay(5f)); 

        }
    }
    void UnlockNewLevel()
    {
       
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (unlockedLevel == currentLevelIndex) 
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevelIndex + 1);
            PlayerPrefs.Save();
        }
        
    }
    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
}
