using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource hitSound;
    public AudioSource hurtSound;
    public AudioSource loseSound;
    public AudioSource winSound;
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void HitSound()
    {
        hitSound.Play();
    }
    public void HurtSound()
    {
        hurtSound.Play();
    }
    public void WinSound()
    {
        winSound.Play();
    }
    public void LoseSound()
    {
        loseSound.Play();
    }
}
