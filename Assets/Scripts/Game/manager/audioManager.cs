using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManager :Singleton<audioManager>
{

    public AudioMixer musicMixe;
  
    float f;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        UpdateAudioSound();
    }


    public void UpdateAudioSound() //外部调用，更新音量大小
    {
      
        if (musicMixe != null)
        {
            if (GameDataManager.Instance.audio.onMusic)
            {
                musicMixe.SetFloat("music", changeData( GameDataManager.Instance.audio.musicVolume));
               

            }
            else
            {
                musicMixe.SetFloat("music", -80);
            }
            if (GameDataManager.Instance.audio.onVfx)
            {
                musicMixe.SetFloat("vfx", changeData( GameDataManager.Instance.audio.vfxVolume));
            }
            else
            {
                musicMixe.SetFloat("vfx", -80);
            }
        }
    }
    public float changeData(float value)
    {
        return -80 + (20 - (-80)) * value;
    }


}
