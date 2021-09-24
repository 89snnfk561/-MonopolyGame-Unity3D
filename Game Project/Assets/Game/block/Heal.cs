using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public void calculate(Player playerData)
    {
        int NewHP = playerData.GetHP();
        NewHP += 200;
        if (NewHP > GameData.HP) NewHP = GameData.HP;
        GameData.BlockEffectNum = 5;
        GameData.BlockEffect = "Potion";
        GameData.BlockEffectDescription = "" +
            "There is a Potion in the chest.\n" +
            "So you decided to drink it.\n" +
            "Player HP plus 200HP.\n";
        playerData.SetHP(NewHP);
    }
}
