using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteInEditMode]
public class BossUI : MonoBehaviour
{

    public Boss boss;
    [Header("UI")]
    public Text HP;
    public Text ATK;
    public Image Mask;
    public Image Fill;
    
    [Header("Cam")]
    public Transform cam;
    public Vector3 vec;

    private void Start()
    {
        
    }
    private void Update()
    {
        HP.text = boss.GetHP().ToString() + " / " + GameData.BossHP.ToString();
        ATK.text = boss.GetATK().ToString();
        if(boss.GetState() == BossState.Angry)
        {
            ATK.color = Color.red;
        }
        Mask.fillAmount = (float)(GameData.BossHP-boss.GetHP()) / (float)(GameData.BossHP*0.7f);
    }

    void LateUpdate()
    {
        vec = cam.position;
        vec.y = transform.position.y;
        transform.LookAt(vec);
    }
}
