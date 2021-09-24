using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class ProgressBar : MonoBehaviour
{

    public Player player;
    public int minimum;
    public int maximum;
    public int current;
    public int temp;
    public Image mask;
    public Image fill;
    public Gradient gradient;
    // Start is called before the first frame update
    void Start()
    {

        maximum = GameData.HP;
        current = maximum;
        temp = current;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameData.isPause)
        {
            current = player.GetHP();
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
        if (temp < current)
        {
            temp += 1;
        }
        else if (temp > current)
        {
            temp -= 1;
        }
        yield return null;
    }
}
