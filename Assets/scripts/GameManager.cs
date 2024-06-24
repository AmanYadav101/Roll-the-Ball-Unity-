/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int maxLives = 4;
    private static int currentLives;

    public GameObject[] lifeIcons;
    public TextMeshProUGUI gameOverText;
    public Button mainMenuButton;
    public PlaneTrigger planeTrigger;

    // Start is called before the first frame update
    private void Awake()
    {   
        planeTrigger = GameObject.FindGameObjectWithTag("PlaneTrigger").GetComponent<PlaneTrigger>();
        DontDestroyOnLoad(gameObject);
        if(currentLives == 0) 
        { 
        currentLives = maxLives;
        }
        UpdateLivesUI();
        gameOverText.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }
    
    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateLivesUI();

        }
        if (currentLives <= 0)
        {

            GameOver();
            
        }
    }

    public void GainLife()
    {
        if (currentLives < maxLives)
        {
            Debug.Log("if block -------- " + currentLives);
            currentLives++;
            planeTrigger.count--;
            Debug.Log("if block -------- " + currentLives);

            UpdateLivesUI();

        }
        else
        {
            Debug.Log("else block ----------" + currentLives);
            currentLives = maxLives;
            Debug.Log("else block ----------" + currentLives);
            UpdateLivesUI();

        }
    }


    private void UpdateLivesUI()
    {
        for(int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i<currentLives);
        }          
    }

    private void GameOver()
    {
        PlayerPrefs.DeleteAll();
        gameOverText.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    
}
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int maxLives = 4;
    private static int currentLives;

    public GameObject[] lifeIcons;
    public TextMeshProUGUI gameOverText;
    public Button mainMenuButton;
/*    public PlaneTrigger planeTrigger;
*/
    private void Awake()
    {
/*        planeTrigger = GameObject.FindGameObjectWithTag("PlaneTrigger").GetComponent<PlaneTrigger>();
*/        DontDestroyOnLoad(gameObject);
        if (currentLives == 0)
        {
            currentLives = maxLives;
        }
        UpdateLivesUI();
        gameOverText.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            UpdateLivesUI();
        }
        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    public void GainLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
/*            planeTrigger.count--;
*/            UpdateLivesUI();
        }
        else
        {
            currentLives = maxLives;
            UpdateLivesUI();
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i < currentLives);
        }
    }

    private void GameOver()
    {
        PlayerPrefs.DeleteAll();
        gameOverText.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
