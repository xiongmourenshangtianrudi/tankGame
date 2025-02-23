using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vectory : basePanel
{
    public Button yes;
    public Button reStart;
    public Text info;
    public Text head;
    public InputField input;


    public override void init()
    {
        GameManager.Instance.isGame = false;
        //ʵ�ֹ��ܼ���
        inputManager.Instance.inputActions.Disable(); //�رտ�����
        yes.onClick.AddListener(() =>
        {
            //��������
            //���ص�������
            GameManager.Instance.gameData.playerName = input.text;
            GameManager.Instance.endGame();
            SceneManager.LoadScene("mainScene");
           
        });
        reStart.onClick.AddListener(() =>
        {
            //�������ݣ�������������
            //���¿�ʼ��Ϸ
            UImanager.Instance.hidePane<vectory>();
            SceneManager.LoadScene("level1");
        });
    }

    public void setInfo(string headInfo,string text,int score)
    {
        head.text = headInfo;
        info.text = text + score;
    }

    private void OnDestroy()
    {
        inputManager.Instance.inputActions.Enable(); //����������
    }

}

  

   

