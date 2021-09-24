using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHurt : MonoBehaviour
{
    
    public void calculate(Player playerData)
    {
        int NewHP = playerData.GetHP();
        NewHP -= 100;
        playerData.SetHP(NewHP);
        playerData.SetKeep(playerData.GetToxic(), 2);

        GameData.BlockEffectNum = 4;
        GameData.BlockEffect = "GetHurt";
        GameData.BlockEffectDescription = "" +
            "The trap was triggerd.\n" +
            "Player has been hurt.\n" +
            "Player HP minus 100.\n";
    }
}
