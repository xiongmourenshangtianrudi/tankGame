using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monsterHealth : MonoBehaviour
{
    public Camera MainCamera;
    public Image healthBarBack;
    public Image healthBarValue;
    public float time;
    public float persent =1;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
       

    }


    public void updateHealhtBar(int maxHealth, int currentHealth) //�ܵ��˺������
    {
        if (maxHealth == 0)
        {
            persent = 0;
           
        }
        //�������
        persent = (float)currentHealth / (float)maxHealth;
       
        healthBarValue.fillAmount = persent;//����������
    }




    // Update is called once per frame
    void Update()
    {
        if(time >= 2)
        {
            this.gameObject.SetActive(false);
            time = 0;
        }
        Vector3 dir = MainCamera.transform.position - transform.position;
        Vector3 back = -dir;
        Quaternion q = Quaternion.LookRotation(back);
        transform.rotation = q;

        
        if (healthBarBack.fillAmount != persent) //����Ѫ���Ļ���Ч��
        {
            healthBarBack.fillAmount = Mathf.Lerp(healthBarBack.fillAmount, persent, 0.1f);
        }

    }
}
