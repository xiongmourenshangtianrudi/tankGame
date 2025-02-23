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
            //�˳���Ϸʱ��Ҫ��ʾ��Ϸ������Ϣ
            GameManager.Instance.isGame = false;
            UImanager.Instance.showPanel<quitGamePanel>();
        });
        gameSetting.onClick.AddListener(() =>
        {
            GameManager.Instance.isGame = false;
            UImanager.Instance.showPanel<optionPanel>();
        });


    }

    //����ui�ϵ�����
    public void AddScore(int sorce)
    {
        score.text = sorce.ToString();
    }


    public void updateFireBar(float time, float curentTime) //��������ʾ
    {
        havWeapon = true;
        //�������
        coolTimePersent = (float)curentTime / (float)time;
        fireCoolValue.fillAmount = coolTimePersent;//��������
    }

    public void updateHealhtBar(int maxHealth,int currentHealth) //�ܵ��˺������
    {
        //�������
       persent = (float)currentHealth / (float)maxHealth;
       healthBarValue.fillAmount = persent;//����������
    }

    public void updateTimer(float timer)//ÿ���ӵ���һ��
    {
        time.text = (Mathf.Floor(timer / 60) + "��" + Mathf.Floor(timer % 60) + "��").ToString();
    }


    public override void Update()
    {

        base.Update();

        if (healthBarBack.fillAmount !=persent) //����Ѫ���Ļ���Ч��
        {
            healthBarBack.fillAmount = Mathf.Lerp(healthBarBack.fillAmount, persent, 0.1f);
        }

        if (havWeapon)
        {
            if (fireCoolBack.fillAmount != coolTimePersent) //����Ѫ���Ļ���Ч��
            {
                fireCoolBack.fillAmount = Mathf.Lerp(fireCoolBack.fillAmount, coolTimePersent, 0.2f * Time.deltaTime);
            }
        }

      
        


    }

}
