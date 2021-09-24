using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public void calculate(Player playerData)
    {
        int NewHP = playerData.GetHP();
        NewHP -= GameData.BossATK;
        playerData.SetHP(NewHP);

        GameData.BlockEffectNum = 6;
        GameData.BlockEffect = "BossAttack";
        GameData.BlockEffectDescription = "" +
            "This is obviously a bad opportunity.\n" +
            "You encountered Boss.\n" +
            "Player HP minus "+ GameData.BossATK + ".\n";
    }
}
