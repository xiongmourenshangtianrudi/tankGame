using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingObj : MonoBehaviour
{
    public Text ranking;
    public Text playerName;
    public Text score;
    public Text passTime;


    public void setValue(string ranking,string playerName, string score,float passTime)
    {
        this.ranking.text = ranking;
        this.playerName.text = playerName;
        this.score.text = score;
        this.passTime.text = (MathF.Floor( passTime /3600) +"·Ö" +MathF.Floor(passTime % 3600) +"Ãë").ToString();

        switch (ranking)
        {
            case "1":
                changeColor(Color.red);
                break;
            case "2":
                changeColor(Color.green);
                break;
            case "3":
                changeColor(Color.blue);
                break;
        }


    }
   
    public void changeColor(Color color)
    {
        this.ranking.color = color;
        this.playerName.color = color;
        this.score.color = color;
        this.passTime.color = color;
    }







}
