using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dice : MonoBehaviour
{
    Rigidbody rb;

    bool hasLanded;
    bool thrown;

    Vector3 initPosition;

    public int diceValue;

    public DiceSide[] diceSides;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameData.DiceRollStart)
        {
            RollDice();
            GameData.DiceRollStart = false;
        }
        
        if(rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            SideValueCheck();
        }
        else if(rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            RollAgain();
        }
    }

    void RollDice()
    {
        if (!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(100, 1000), Random.Range(100, 1000), Random.Range(100, 1000));
        }
        else if(thrown && hasLanded)
        {
            Reset();
        }
    }
    void Reset()
    {
        transform.position = initPosition;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
    }

    void RollAgain()
    {
        Reset();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(Random.Range(100, 1000), Random.Range(100, 1000), Random.Range(100, 1000));
    }

    void SideValueCheck()
    {
        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if (side.OnGround())
            {
                diceValue = side.sideValue;
                GameData.steps = diceValue;
                Debug.Log(GameData.steps.ToString() + "has been rolled!");
                GameObject.Find("DICECamera").SetActive(false);
                GameData.DiceRollEnd = true;
                Reset();
            }
            
        }
    }
}
