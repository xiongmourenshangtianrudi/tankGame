using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getWeaponObj : MonoBehaviour
{
    public GameObject[] weaPon;//随机武器





    private void OnTriggerEnter(Collider other)
    {
        int index = Random.Range(0, weaPon.Length - 1);

        if (other.CompareTag("Player") && other .gameObject.GetComponent<BaseTank>())
        {
            //给这个坦克加上武器！
            playerTank playerTank = other.gameObject.GetComponent<BaseTank>()as playerTank;
            playerTank.changeWeaPon(weaPon[index]);//获取随机武器
            Destroy(this.gameObject);


        }
    }
}
