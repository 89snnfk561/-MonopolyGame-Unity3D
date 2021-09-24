using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Transform canvas;
    public Text text;
    public Boss boss;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (GameData.Victory)
        {
            text.text = "Victory";
            text.color = Color.cyan;
            boss.Dead();
        }
        else
        {
            text.text = "GameOver";
            text.color = Color.red;
            boss.GameEnd();
        }
    }
}
