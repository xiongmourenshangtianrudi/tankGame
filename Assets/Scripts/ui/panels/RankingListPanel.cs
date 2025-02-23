using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingListPanel : basePanel
{
    public Button closeButton;
    public GameObject rankingbox;
    public GameObject listObjet;
   
    public override void init()
    {
        closeButton.onClick.AddListener(() =>
        {
            UImanager.Instance.hidePane<RankingListPanel>();
            UImanager.Instance.showPanel<mainMenuPanel>();
        });

        GameDataManager.Instance.ReadData();
        List<RankingData> rank = GameDataManager.Instance.ranking.rankingDatas;
        Debug.Log(GameDataManager.Instance.ranking.rankingDatas.Count);
        for (int i = 0; i < 10; i++)
        {
           GameObject rankObj =  GameObject.Instantiate(rankingbox, listObjet.transform);
          
            if (i >= rank.Count)
            {
                rankObj.GetComponent<RankingObj>().setValue((i+1).ToString(),"ÐéÎ»ÒÔ´ý","0",0);
            }
            else
            {
                rankObj.GetComponent<RankingObj>().setValue((i + 1).ToString(), rank[i].playerName, rank[i].score.ToString(), rank[i].passTime);
            }
           
        }
    }


}
