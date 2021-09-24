using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public Boss boss;
    public int minimum;
    public int maximum;
    public int current;
    public int temp;
    public Image mask;
    public Image fill;
    public Gradient gradient;
    
    void Start()
    {

        maximum = GameData.BossHP;
        current = maximum;
        temp = current;
    }

    
    void Update()
    {
        if (!GameData.isPause)
        {
            current = boss.GetHP();
            GetCurrentFill();
        }
    }

    void GetCurrentFill()
    {
        if (temp != current)
        {
            StartCoroutine(Filled());
        }

        float currentOffset = temp - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
        fill.color = gradient.Evaluate(fillAmount);
    }
    IEnumerator Filled()
    {
        if (temp > current)
        {
            temp -= 10;
        }
        else
        {
            temp = current;
        }
        yield return null;
    }
}
