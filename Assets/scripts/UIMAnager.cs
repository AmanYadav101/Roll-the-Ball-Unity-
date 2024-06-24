using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMAnager : MonoBehaviour
{
    public static UIMAnager Instance { get; private set; }

    public TextMeshProUGUI starText;
    public TextMeshProUGUI totalScore;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
/*            DontDestroyOnLoad(gameObject);
*/        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateStarUI( int numberofStars)
    {
        starText.text =  numberofStars.ToString();
        totalScore.text = "Final Score: " + numberofStars.ToString();
    }
}
