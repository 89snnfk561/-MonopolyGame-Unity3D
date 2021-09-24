using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Var")]
    Vector3 initVec;
    Quaternion Rotation;
    public int HP;
    public int ATK;
    public BossState bossState;

    [Header("Animator")]
    public bool Roar;
    public bool Attack;
    public bool isDead;
    public bool GameOver;
    Animator animator;
    int RoarHash;
    int AttackHash;
    int isDeadHash;
    int GameOverHash;

    void Start()
    {
        initVec = this.transform.position;
        Rotation = this.transform.rotation;
        animator = GetComponent<Animator>();
        RoarHash = Animator.StringToHash("Roar");
        AttackHash = Animator.StringToHash("Attack");
        isDeadHash = Animator.StringToHash("isDead");
        GameOverHash = Animator.StringToHash("GameOver");
        HP = GameData.BossHP;
        ATK = GameData.BossATK;
        bossState = BossState.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= GameData.BossHP * 0.3f && bossState != BossState.Angry && bossState != BossState.Dead)
        {
            ATK += 200;
            bossState = BossState.Angry;
        }
        if(HP <= 0)
        {
            bossState = BossState.Dead;
            animator.SetBool(isDeadHash, true);
        }
    }
    public void Back()
    {
        transform.position = initVec;
        transform.rotation = Rotation;
    }
    public void AckRoar()
    {
        animator.SetBool(RoarHash, true);
    }
    public void AckAttack()
    {
        animator.SetBool(AttackHash, true);
    }
    public void Dead()
    {
        animator.SetBool(isDeadHash, true);
    }
    public void GameEnd()
    {
        animator.SetBool(GameOverHash, true);
    }
    public void Stop()
    {
        animator.SetBool(RoarHash, false);
        animator.SetBool(AttackHash, false);
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

    public BossState GetState()
    {
        return bossState; 
    }
}
