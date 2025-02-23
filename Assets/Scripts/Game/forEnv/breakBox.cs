using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakBox : MonoBehaviour
{
    public GameObject breakBoxEffect;
    public List<GameObject> rewoard = new List<GameObject>();
    public AudioClip vfxSource;
    private void OnCollisionEnter(Collision collision)
    {

        //���������Ʒ
        if (collision.gameObject.CompareTag("bullet"))
        {
            //��ը��ʱ�򴴽�����һ���������󲥷�����
            GameObject vfxObj = Instantiate(Resources.Load<GameObject>("audioObject/vfxObj"), transform.position, Quaternion.identity);
            vfxObj.GetComponent<vfxComp>().setAudio(vfxSource);
            int range = Random.Range(0, 99);
            if(range < 50)//50�ļ��ʵ��佱��
            {
                Instantiate(rewoard[Random.Range(0, rewoard.Count - 1)],transform.position,Quaternion.identity);//���������Ʒ
            }

            Instantiate(breakBoxEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}
