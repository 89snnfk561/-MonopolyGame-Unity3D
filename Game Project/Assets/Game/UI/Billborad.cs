using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Billborad : MonoBehaviour
{
    public Player player;
    [Header("Toxic")]
    public Image toxic;
    public Text tt;
    [Space]

    [Header("Stop")]
    public Image stop;
    public Text st;
    [Space]

    [Header("Cam")]
    public Transform cam;
    public Vector3 vec;

    private void Update()
    {
        if (player.GetToxic() > 0)
        {
            toxic.gameObject.SetActive(true);
            tt.text = player.GetToxic().ToString();
        }
        else
        {
            toxic.gameObject.SetActive(false);
        }
        if (player.GetStop() > 0)
        {
            stop.gameObject.SetActive(true);
            st.text = player.GetStop().ToString();
        }
        else
        {
            stop.gameObject.SetActive(false);
        }
    }
    void LateUpdate()
    {
        vec = cam.position;
        vec.y = transform.position.y;
        transform.LookAt(vec);
    }
}
