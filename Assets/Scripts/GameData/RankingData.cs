using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingData 
{
  //û��������������˳������ʾ����
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
