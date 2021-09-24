using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startblock : MonoBehaviour
{
    public Boss boss;
    public void pass(Player playerData)
    {
        boss.SetHP(boss.GetHP() - playerData.GetATK());
    }
    public void calculate(Player playerData)
    {
        boss.SetHP(boss.GetHP() - (playerData.GetATK()*2));

        GameData.BlockEffectNum = 1;
        GameData.BlockEffect = "DamageBoss";
        GameData.BlockEffectDescription = "" +
            "This is a good opportunity to hurt BOSS.\n" +
            "And you didn't miss this opportunity.\n" +
            "Boss HP minus"+ playerData.GetATK() * 2 + ".\n";
        
    }
}
