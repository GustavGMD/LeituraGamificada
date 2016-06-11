using UnityEngine;
using System.Collections;

public class ItemData : MonoBehaviour {
	private InventoryManager inventoryManagerRef;

	public Custom.Item item;

	public void Start()
	{
		inventoryManagerRef = GameObject.Find ("InventoryManager").GetComponent<InventoryManager>();
	}
}
