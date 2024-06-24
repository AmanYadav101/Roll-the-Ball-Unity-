using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stars : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] private GameObject floatingTextPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag=="Player")
        {
            ShowText("+1");
            audioManager.PlaySFX(audioManager.star);//Plays the sound for collecting the star
            var ballMovement = collider.gameObject.GetComponent<BallMovement>();
            ballMovement.numberofStars++; //Updates the count of number of stars
            UIMAnager.Instance.UpdateStarUI(ballMovement.numberofStars);
            Destroy(gameObject);//Destroys the object after colliding with sphere


        }

    }
    void ShowText(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab,transform.localPosition,Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
}
