using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponObj : MonoBehaviour
{
    public GameObject bullet; //ʵ�������ӵ�����
    public Transform[] shootPos;

    public float coolTimer;
    public float timer;
    public bool canFire;
    //����˭������
    public BaseTank fatherObj;

    public void setFather(BaseTank fatherObj)
    {
        this.fatherObj = fatherObj;
    }

    private void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            UImanager.Instance.getPanel<gameInfoPanel>().updateFireBar(coolTimer, timer);
        }
       
       
        if (timer >= coolTimer)
        {
            canFire = true;
            timer = 0;
           
        }

       
        
    }



    public void fire()
    {
        if (canFire)
        {
            UImanager.Instance.getPanel<gameInfoPanel>().updateFireBar(coolTimer, timer);
            canFire = false;
            for (int i = 0; i < shootPos.Length; i++)
            {
                GameObject bulletobj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
                //�����ӵ�������
                bulletobj.GetComponent<bulletObj>().setFather(fatherObj);
            }
        }
           
    }
}
