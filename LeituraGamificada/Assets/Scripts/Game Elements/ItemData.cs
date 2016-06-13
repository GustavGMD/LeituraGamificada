using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using UnityEngine.UI;

public class ItemData : MonoBehaviour {

	public event Action<int> onClick;

	public Custom.Item item;

	public void Start()
	{
		GetComponent<Button> ().onClick.AddListener(delegate {
			Debug.Log("Clicked");
			if(onClick != null) onClick(item.id);
		});
	}
}