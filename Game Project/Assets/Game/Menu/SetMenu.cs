using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMenu : MonoBehaviour
{
    public void volume()
    {
        
    }

    public List<Button> PC = new List<Button>();


    void Update()
    {
        PC[0].onClick.AddListener(B4);
        PC[1].onClick.AddListener(B1);
        PC[2].onClick.AddListener(B2);
        PC[3].onClick.AddListener(B3);
        if (this.gameObject.activeSelf)
        {
            PC[GameData.PlayerCount % 4].Select();
        }
        Debug.Log(GameData.PlayerCount.ToString());
    }

    public void B1()
    {
        GameData.PlayerCount = 1;
    }
    public void B2()
    {
        GameData.PlayerCount = 2;
    }
    public void B3()
    {
        GameData.PlayerCount = 3;
    }
    public void B4()
    {
        GameData.PlayerCount = 4;
    }

}
