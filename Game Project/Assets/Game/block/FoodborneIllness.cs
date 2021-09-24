using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodborneIllness : MonoBehaviour
{
    public void calculate(Player playerData)
    {

        PlayerStatus playerStatus = PlayerStatus.Toxic;

        playerData.SetKeep(3, playerData.GetStop());

        GameData.BlockEffectNum = 8;
        GameData.BlockEffect = "foodborneillness";
        GameData.BlockEffectDescription = "" +
            "Maybe you shouldn't just eat mushrooms from the ground.\n" +
            "You have foodborneillness.\n" +
            "Player HP minus " + 150 + ".\n";

        playerData.SetPlayerStatus(playerStatus);
        playerData.SetKeep(3, 0);
    }
}
