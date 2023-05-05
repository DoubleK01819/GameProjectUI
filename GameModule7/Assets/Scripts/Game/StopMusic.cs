using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    [SerializeField] private AudioSource stopMusic;

    public void EndMusic()
    {
        if (stopMusic.isPlaying)
        {
            stopMusic.Pause();
        }
        else
        {
            stopMusic.Play();
        }
        
    }
}
