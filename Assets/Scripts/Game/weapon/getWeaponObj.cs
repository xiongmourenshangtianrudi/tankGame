using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getWeaponObj : MonoBehaviour
{
    public GameObject[] weaPon;//�������





    private void OnTriggerEnter(Collider other)
    {
        int index = Random.Range(0, weaPon.Length - 1);

        if (other.CompareTag("Player") && other .gameObject.GetComponent<BaseTank>())
        {
            //�����̹�˼���������
            playerTank playerTank = other.gameObject.GetComponent<BaseTank>()as playerTank;
            playerTank.changeWeaPon(weaPon[index]);//��ȡ�������
            Destroy(this.gameObject);


        }
    }
}
