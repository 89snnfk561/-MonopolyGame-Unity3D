using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour
{
    
    public void calculate(Player playerData)
    {
        int plus = Random.Range(50, 100);
        int Newmoney = playerData.Getmoney();
        Newmoney += plus;

        GameData.BlockEffectNum = 2;
        GameData.BlockEffect = "GetMoney";
        GameData.BlockEffectDescription = "" +
            "Player got a windfall in the way.\n" +
            "Player money plus " + plus +".\n";

        playerData.Setmoney(Newmoney);
    }
}
