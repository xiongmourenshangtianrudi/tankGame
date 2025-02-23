using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionPanel : basePanel
{

    public Slider vfx;
    public Slider music;
    public Toggle vfxToggle;
    public Toggle musicToggle;
    public Button closeButton;




    //修改设置属性
    public override void init()
    {
        inputManager.Instance.inputActions.Disable();
        GameManager.Instance.isGame = false;
        //关闭面板
        closeButton.onClick.AddListener(() =>
        {
            
            UImanager.Instance.hidePane<optionPanel>();
            inputManager.Instance.inputActions.Enable();
            GameManager.Instance.isGame = true;
        });
        vfxToggle.onValueChanged.AddListener((x) =>
        {
            GameDataManager.Instance.audio.onVfx = x;
            audioManager.Instance.UpdateAudioSound();
            GameDataManager.Instance.SaveGameData();

        });
        musicToggle.onValueChanged.AddListener((x) =>
        {
            GameDataManager.Instance.audio.onMusic = x;
            audioManager.Instance.UpdateAudioSound();
            GameDataManager.Instance.SaveGameData();
        });
        music.onValueChanged.AddListener((x) =>
        {
            GameDataManager.Instance.audio.musicVolume = x;
            audioManager.Instance.UpdateAudioSound();
            GameDataManager.Instance.SaveGameData();
        });
        vfx.onValueChanged.AddListener((x) =>
        {
            GameDataManager.Instance.audio.vfxVolume = x;
            audioManager.Instance.UpdateAudioSound();
            GameDataManager.Instance.SaveGameData();
        });



        updateData();
    }


    public void updateData()
    {
        vfx.value = GameDataManager.Instance.audio.vfxVolume;
        music.value = GameDataManager.Instance.audio.musicVolume;
        vfxToggle.isOn = GameDataManager.Instance.audio.onVfx;
        musicToggle.isOn = GameDataManager.Instance.audio.onMusic;
    }
}
