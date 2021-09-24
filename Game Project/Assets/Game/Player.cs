using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Valus")]
    public string name;
    public int HP;
    public int ATK;
    public int money;
    public PlayerStatus playerStatus;
    public int keepToxic;
    public int keepStop;

    [Space]

    [Header("Animator")]
    public bool isWalking;
    public bool Attack;
    public bool isDead;
    Animator animator;
    int isWalkingHash;
    int AttackHash;
    int isDeadHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        AttackHash = Animator.StringToHash("Attack");
        isDeadHash = Animator.StringToHash("isDead");
        HP = GameData.HP;
        ATK = GameData.ATK;
        money = GameData.money;
        playerStatus = PlayerStatus.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        isWalking = animator.GetBool(isWalkingHash);
        Attack = animator.GetBool(AttackHash);
        isDead = animator.GetBool(isDeadHash);
    }


    public bool IsWalk()
    {
        return isWalking;
    }
    public void Walk()
    {
        animator.SetBool(isWalkingHash, true);
    }
    public void Hit()
    {
        animator.SetBool(AttackHash, true);
    }
    public void Stop()
    {
        animator.SetBool(isWalkingHash, false);
        animator.SetBool(AttackHash, false);
    }
    public void Dead()
    {
        animator.SetBool(isDeadHash, true);
    }


    public string Name()
    {
        return name;
    }

    public int GetHP()
    {
        return HP;
    }
    public void SetHP(int HP)
    {
        this.HP = HP;
    }
    public int GetATK()
    {
        return ATK;
    }
    public void SetATK(int ATK)
    {
        this.ATK = ATK;
    }
    public int Getmoney()
    {
        return money;
    }
    public void Setmoney(int money)
    {
        this.money = money;
    }
    public PlayerStatus GetPlayerStatus()
    {
        return playerStatus;
    }
    public void SetPlayerStatus(PlayerStatus playerStatus)
    {
        this.playerStatus = playerStatus;
    }
    public int GetToxic()
    {
        return keepToxic;
    }
    public int GetStop()
    {
        return keepStop;
    }
    public void SetKeep(int Toxic, int Stop)
    {
        if (Toxic < 0) Toxic = 0;
        if (Stop < 0) Stop = 0;
        keepToxic = Toxic;
        keepStop = Stop;
    }
}

public enum PlayerStatus
{
    Normal,
    Toxic,
    Stop
}

