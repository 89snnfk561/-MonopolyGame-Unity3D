using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int round = 0;
    public static int turn = 1;
    public static int PlayerCount = 4;
    public static int steps = 0;
    public static float speed = 50f;
    public static bool isPause = false;
    public static bool Victory = true;
    
    //Boss
    public static int BossHP = 5000;
    public static int BossATK = 500;
    public static bool AOE = false;
    public static int BossAOE = 300;
    

    //dice
    public static bool DiceRollStart = false;
    public static bool DiceRollEnd = false;

    //block
    public static int BlockEffectNum = 0;
    public static string BlockEffectDescription= "Get Start!";
    public static string BlockEffect= "start";

    //player
    public static int HP = 1000;
    public static int ATK = 200;
    public static int money = 0;
}

public enum BossState
{
    Normal,
    Angry,
    Dead
}
public enum PlayerState
{
    finish,
    start,
    dead
}


