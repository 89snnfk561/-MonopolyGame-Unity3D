using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockEffectUI : MonoBehaviour
{
    [Header("UI")]
    public Button button;
    public Image[] image;
    public Text text;
    public bool UIupdate = false;
    

    
    void Update()
    {
        button.onClick.AddListener(Continue);
        if (!GameData.isPause)
        {
            GameData.isPause = true;
            Time.timeScale = 0;
            UIupdate = false;
            image[GameData.BlockEffectNum].gameObject.SetActive(true);
            text.text = "";
            text.text += GameData.BlockEffectDescription;
        }
        
    }
    public void Continue()
    {
        text.text = "";
        GameData.isPause = false;
        Time.timeScale = 1;

        image[GameData.BlockEffectNum].gameObject.SetActive(false);
        transform.gameObject.SetActive(false);

    }
}

