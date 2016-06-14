using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : GameState
{
	public Player playerRef;

	public Canvas inventoryCanvas;
	public Button backMenu;
	public Button newBookButton;
	public Button equipButton;
	public Button unequipButton;

	public GameObject createItemPanel;
	public GameObject itemStatsPanel;
	public GameObject inventoryPanel;
	public GameObject slotPanel;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	public ItemManager itemManagerRef;

	int slotAmount;

	int idAtual;

	public List<Custom.Item> items = new List<Custom.Item>();
	public List<GameObject> slots = new List<GameObject>();

	public Text titulo;
	public Text attack;
	public Text defense;
	public Text agility;
	public Text stamina;

	public override void Initialize()
	{
		createItemPanel.SetActive (false);
		itemStatsPanel.SetActive (false);

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
				itemObj.GetComponent<ItemData>().onClick += delegate(int p_int) 
				{
					//Debug.Log("CHamando método do inventoryManager: " + p_int);
					idAtual = p_int;
					Stats(idAtual);
				};
				break;
			}
		}

		Back ();
	}

	public void EquipItem()
	{
		if(playerRef.equippedItem.Count < 2 && !playerRef.equippedItem.Contains(itemManagerRef.FindbyID(idAtual)))
		{
			playerRef.equippedItem.Add (itemManagerRef.FindbyID(idAtual));
		}
		equipButton.gameObject.SetActive (false);
		unequipButton.gameObject.SetActive (true);

	}
	public void UnequipItem()
	{
		playerRef.equippedItem.Remove (itemManagerRef.FindbyID (idAtual));
		equipButton.gameObject.SetActive (true);
		unequipButton.gameObject.SetActive (false);
	}

	public void Stats(int id)
	{
		slotPanel.SetActive (false);
		itemStatsPanel.SetActive (true);
		newBookButton.gameObject.SetActive (false);
		backMenu.gameObject.SetActive (false);
		if (playerRef.equippedItem.Contains(itemManagerRef.FindbyID(id)))
		{
			equipButton.gameObject.SetActive (false);
			unequipButton.gameObject.SetActive (true);
		}
		else
		{
			equipButton.gameObject.SetActive (true);
			unequipButton.gameObject.SetActive (false);
		}

		titulo.text = itemManagerRef.FindbyID (id).name;
		attack.text = itemManagerRef.FindbyID (id).attack.ToString();
		defense.text = itemManagerRef.FindbyID (id).defense.ToString();
		agility.text = itemManagerRef.FindbyID (id).agility.ToString();
		stamina.text = itemManagerRef.FindbyID (id).stamina.ToString();
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

	public void Back()
	{
		slotPanel.SetActive (true);
		createItemPanel.SetActive (false);
		itemStatsPanel.SetActive (false);
		newBookButton.gameObject.SetActive (true);
		backMenu.gameObject.SetActive (true);
	}
	public void NewBook()
	{
		slotPanel.SetActive (false);
		createItemPanel.SetActive (true);
		newBookButton.gameObject.SetActive (false);
		backMenu.gameObject.SetActive (false);
	}
}