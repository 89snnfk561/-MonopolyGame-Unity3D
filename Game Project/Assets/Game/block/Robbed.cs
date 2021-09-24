using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robbed : MonoBehaviour
{
    public void calculate(Player playerData)
    {
        bool enough = false;
        int NewHP = playerData.GetHP();
        int Newmoney = playerData.Getmoney();
        
        
        if (Newmoney >= 100) enough = true;

        if(enough)
        {
            Newmoney -= 100;
        }
        else
        {
            Newmoney = 0;
            NewHP -= 200;
            
        }

        GameData.BlockEffectNum = 7;
        GameData.BlockEffect = "Robbed";
        GameData.BlockEffectDescription = "" +
            "This is obviously a bad opportunity.\n" +
            "You was robbed.\n";
        if (enough)
        {
            GameData.BlockEffectDescription += "" +
                "Player money minus " + 100 + ".\n";
        }
        else
        {
            GameData.BlockEffectDescription += "" +
                "But you dont have enough money to pleasing the looters.\n" +
                "So they decied to take it out on you.\n" +
                "Player HP minus " + 200 + ".\n";
        }
        playerData.SetHP(NewHP);
        playerData.Setmoney(Newmoney);
    }
}
