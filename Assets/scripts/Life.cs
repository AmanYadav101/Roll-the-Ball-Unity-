/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject Sphere;
    public GameManager gameManager;
    public AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name =="Sphere")
        {

            gameManager.GainLife();
            audioManager.PlaySFX(audioManager.lifePickup);

            Destroy(gameObject);
        }
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject Sphere;
    public GameManager gameManager;
    public AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Sphere")
        {
            gameManager.GainLife();
            audioManager.PlaySFX(audioManager.lifePickup);

            Destroy(gameObject);
        }
    }
}
