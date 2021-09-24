using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonCamera : MonoBehaviour
{
    Transform[] childObjects;
    public List<Transform> TPCs = new List<Transform>();

    void Awake()
    {
        FillNodes();
    }

    void FillNodes()
    {
        TPCs.Clear();

        childObjects = GetComponentsInChildren<Transform>();

        foreach(Transform child in childObjects)
        {
            if(child != this.transform && child.tag == "TPCs")
            {
                TPCs.Add(child);
            }
        }
    }
}
