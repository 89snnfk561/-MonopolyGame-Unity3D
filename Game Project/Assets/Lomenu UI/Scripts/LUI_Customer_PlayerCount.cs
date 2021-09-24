using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LUI_Customer_PlayerCount : MonoBehaviour
{

	public Dropdown drop;
	Resolution[] resolutions;

	void Start()
	{
		drop.onValueChanged.AddListener(delegate
			{
				Change();
			}
		);
	}
    private void Change()
    {
		Debug.Log(drop.value);
		GameData.PlayerCount = drop.value + 1;
    }
    
}
