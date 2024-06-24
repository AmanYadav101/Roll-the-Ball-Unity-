using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionScript : MonoBehaviour
{
    public GameObject SpawnPoint;
    public string Scene;
    private void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.name == "Sphere")
        {
            Debug.Log("Boom!!!");
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
            if (unlockedLevel == currentLevelIndex)
            {
                PlayerPrefs.SetInt("UnlockedLevel", currentLevelIndex + 1);
                PlayerPrefs.Save();
            }

            SceneManager.LoadScene(Scene);
        }

    }
   
}

