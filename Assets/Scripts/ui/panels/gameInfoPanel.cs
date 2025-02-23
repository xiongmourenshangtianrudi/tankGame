using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class gameInfoPanel : basePanel
{
    public Text score;
    public Text time;
    public Button gameExit;
    public Button gameSetting;
    public Image healthBarBack;
    public Image healthBarValue;

    public Image fireCoolBack;
    public Image fireCoolValue;

    float persent;
    float coolTimePersent;

    public bool havWeapon;
    public override void init()
    {
        


        gameExit.onClick.AddListener(() =>
        {
            //退出游戏时需要显示游戏过程信息
            GameManager.Instance.isGame = false;
            UImanager.Instance.showPanel<quitGamePanel>();
        });
        gameSetting.onClick.AddListener(() =>
        {
            GameManager.Instance.isGame = false;
            UImanager.Instance.showPanel<optionPanel>();
        });


    }

    //更新ui上的数据
    public void AddScore(int sorce)
    {
        score.text = sorce.ToString();
    }


    public void updateFireBar(float time, float curentTime) //武器的显示
    {
        havWeapon = true;
        //计算比例
        coolTimePersent = (float)curentTime / (float)time;
        fireCoolValue.fillAmount = coolTimePersent;//置填充比例
    }

    public void updateHealhtBar(int maxHealth,int currentHealth) //受到伤害后调用
    {
        //计算比例
       persent = (float)currentHealth / (float)maxHealth;
       healthBarValue.fillAmount = persent;//设置填充比例
    }

    public void updateTimer(float timer)//每秒钟调用一次
    {
        time.text = (Mathf.Floor(timer / 60) + "分" + Mathf.Floor(timer % 60) + "秒").ToString();
    }


    public override void Update()
    {

        base.Update();

        if (healthBarBack.fillAmount !=persent) //设置血条的缓动效果
        {
            healthBarBack.fillAmount = Mathf.Lerp(healthBarBack.fillAmount, persent, 0.1f);
        }

        if (havWeapon)
        {
            if (fireCoolBack.fillAmount != coolTimePersent) //设置血条的缓动效果
            {
                fireCoolBack.fillAmount = Mathf.Lerp(fireCoolBack.fillAmount, coolTimePersent, 0.2f * Time.deltaTime);
            }
        }

      
        


    }

}
