using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : GameState
{
	public Canvas inventoryCanvas;
	public Button backButton;

	GameObject inventoryPanel;
	GameObject slotPanel;
	ItemManager itemManagerRef;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	int slotAmount;
	public List<Custom.Item> items = new List<Custom.Item>();
	public List<GameObject> slots = new List<GameObject>();

	public override void Initialize()
	{
		backButton.onClick.AddListener(delegate
		{
				ChangeState(StateName.MENU);
		});

		itemManagerRef = GetComponent<ItemManager> ();

		slotAmount = 16;
		inventoryPanel = GameObject.Find ("InventoryPanel");
		slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;
		for(int i=0;i<slotAmount;i++)
		{
			items.Add (new Custom.Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].transform.SetParent (slotPanel.transform);
			slots[i].transform.localScale = new Vector2(2, 2);
		}
	}

	public void AddItem(int id)
	{
		Custom.Item itemToAdd = itemManagerRef.FindbyID (id);
		for(int i=0;i<items.Count;i++)
		{
			if(items[i].id == -1)
			{
				items [i] = itemToAdd;
				GameObject itemObj = Instantiate (inventoryItem);
				itemObj.transform.SetParent (slots[i].transform);
				itemObj.transform.position = itemObj.transform.parent.position;
				itemObj.transform.localScale = new Vector2 (1, 1);
				itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
				itemObj.name = itemToAdd.name;
				break;
			}
		}
	}

	public override void Update()
	{

	}

	public override void Enable()
	{
		base.Enable();

		inventoryCanvas.gameObject.SetActive(true);
	}

	public override void Disable()
	{
		base.Disable();

		inventoryCanvas.gameObject.SetActive(false);
	}
}