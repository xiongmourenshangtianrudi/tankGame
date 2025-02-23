using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfxComp : MonoBehaviour
{
    AudioSource audioPlayer;
    // Start is called before the first frame update
    bool isPlayed = false;
    public void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }


   public void setAudio(AudioClip source)
    {
        audioPlayer.clip = source;
        audioPlayer.Play();
        isPlayed = true;
     
    }
    private void Update()
    {
        if (!audioPlayer.isPlaying && isPlayed)
        {
            Destroy(gameObject);
        }
    }
}
