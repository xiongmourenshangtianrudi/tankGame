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

        //随机掉落物品
        if (collision.gameObject.CompareTag("bullet"))
        {
            //爆炸的时候创建创建一个声音对象播放音乐
            GameObject vfxObj = Instantiate(Resources.Load<GameObject>("audioObject/vfxObj"), transform.position, Quaternion.identity);
            vfxObj.GetComponent<vfxComp>().setAudio(vfxSource);
            int range = Random.Range(0, 99);
            if(range < 50)//50的几率掉落奖励
            {
                Instantiate(rewoard[Random.Range(0, rewoard.Count - 1)],transform.position,Quaternion.identity);//随机掉落物品
            }

            Instantiate(breakBoxEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}
