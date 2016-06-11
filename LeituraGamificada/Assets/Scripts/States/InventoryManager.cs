using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : GameState
{
	public Canvas inventoryCanvas;
	public Button backMenu;
	public Button newBookButton;

	public GameObject createItemPanel;
	public GameObject inventoryPanel;
	public GameObject slotPanel;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	public ItemManager itemManagerRef;

	int slotAmount;

	public List<Custom.Item> items = new List<Custom.Item>();
	public List<GameObject> slots = new List<GameObject>();

	public override void Initialize()
	{
		createItemPanel.SetActive (false);

		backMenu.onClick.AddListener (delegate {
			ChangeState (StateName.MENU);
		});

		slotAmount = 16;
		for(int i=0;i<slotAmount;i++)
		{
			items.Add (new Custom.Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].transform.SetParent (slotPanel.transform);
			slots[i].transform.localScale = new Vector2(2, 2);
		}
	}

	public override void Update()
	{

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
				itemObj.GetComponent<ItemData> ().item = itemToAdd;
				itemObj.transform.SetParent (slots[i].transform);
				itemObj.transform.position = itemObj.transform.parent.position;
				itemObj.transform.localScale = new Vector2 (1, 1);
				itemObj.GetComponent<Image> ().sprite = itemToAdd.Sprite;
				itemObj.name = itemToAdd.name;
				break;
			}
		}

		Back ();
	}

	public void NewBook()
	{
		slotPanel.SetActive (false);
		createItemPanel.SetActive (true);
		newBookButton.gameObject.SetActive (false);
		backMenu.gameObject.SetActive (false);
	}
	public void Back()
	{
		slotPanel.SetActive (true);
		createItemPanel.SetActive (false);
		newBookButton.gameObject.SetActive (true);
		backMenu.gameObject.SetActive (true);
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