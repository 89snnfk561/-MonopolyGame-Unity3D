using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    Transform[] childObjects;
    public List<Transform> childNodeList = new List<Transform>();

    public Lines lines;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        FillNodes();

        for (int i = 0; i < childNodeList.Count; i++)
        {
            Vector3 currentPos = childNodeList[i].position;
            if(i > 0)
            {
                Vector3 prevPos = childNodeList[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }
    private void Start()
    {
        
        for (int i = 0; i < childNodeList.Count; i++)
        {
            LineRenderer L = lines.childNodeList[i].GetComponent<LineRenderer>();
            L.positionCount = 2;
            L.startColor = Color.green;
            L.endColor = Color.green;

            L.startWidth = 10f;
            L.endWidth = 0f;
            
            
            
            Vector3 currentPos = childNodeList[i].position;
            if (i > 0)
            {
                Vector3 prevPos = childNodeList[i - 1].position;
                L.SetPosition(0, prevPos);
                L.SetPosition(1, currentPos);
            }
            else
            {
                L.SetPosition(0, childNodeList[childNodeList.Count-1].position);
                L.SetPosition(1, childNodeList[0].position);
            }

        }
        lines.gameObject.SetActive(false);
    }
    void FillNodes()
    {
        childNodeList.Clear();

        childObjects = GetComponentsInChildren<Transform>();

        foreach(Transform child in childObjects)
        {
            if(child != this.transform)
            {
                childNodeList.Add(child);
            }
        }
    }
}
