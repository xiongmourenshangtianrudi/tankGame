using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuPanel : basePanel
{
    public Button stratGame;
    public Button optionButton;
    public Button quitGame;
    public Button ranking;
    public override void init()
    {
        //������ť

        stratGame.onClick.AddListener(() =>
        {
            //��ʼ��Ϸ �л�������
            SceneManager.LoadScene("level1");
            UImanager.Instance.hidePane<mainMenuPanel>();
            GameManager.Instance.straGame();//��ʼ��Ϸ
        });

        optionButton.onClick.AddListener(() =>
        {
            //��option�˵�
            UImanager.Instance.showPanel<optionPanel>();
            //UImanager.Instance.hidePane<mainMenuPanel>();
        });
        quitGame.onClick.AddListener(() =>
        {
            Application.Quit();
        });


        ranking.onClick.AddListener(() =>{
            UImanager.Instance.showPanel<RankingListPanel>();
            UImanager.Instance.hidePane<mainMenuPanel>();
        });
    }

  
}


