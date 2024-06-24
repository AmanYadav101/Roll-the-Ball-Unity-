using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("---------Audio Clip----------")]
    public AudioClip portal;
    public AudioClip jump;
    public AudioClip speedUP;
    public AudioClip finish;
    public AudioClip gameStart;
    public AudioClip star;
    public AudioClip death;
    public AudioClip lifePickup;
    public AudioClip buttonPressed;
    public static AudioManager instance;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    } 



    //Plays sound when a button is pressed (Not Implemented)
    public void ButtonPressed()
    {
        instance.PlaySFX(instance.buttonPressed);
    }
    
    //Plays sound at the start of the game
    private void Start()
    {
        musicSource.clip = gameStart;
        musicSource.Play();
        
    }

    //For pausing the music
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    // For Resuming the music
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }



    public void PlaySFX(AudioClip clip)
    {
     sfxSource.PlayOneShot(clip);
    }
}

