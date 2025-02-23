using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingData 
{
  //没有索引，排序后的顺序来表示排名
    public string playerName;
    public int score;
    public float passTime;

    public RankingData()
    {

    }
    public RankingData(string name, int score, float time)
    {
        this.playerName = name;
        this.score = score;
        this.passTime = time;
    }
}


public class Ranklist
{
    public List<RankingData> rankingDatas;
}
