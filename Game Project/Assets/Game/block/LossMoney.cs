using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossMoney : MonoBehaviour
{
    public void calculate(Player playerData)
    {

        int minus = Random.Range(50, 100);
        if (minus > playerData.Getmoney()) minus = playerData.Getmoney();
        int NewMoney = playerData.Getmoney() - minus;


        GameData.BlockEffectNum = 3;
        GameData.BlockEffect = "LossMoney";
        GameData.BlockEffectDescription = "" +
            "You are out of lucky today.\n" +
            "Your money bag has a hole.\n" +
            "Player money minus " + minus + ".\n";

        playerData.Setmoney(NewMoney);
    }
}
