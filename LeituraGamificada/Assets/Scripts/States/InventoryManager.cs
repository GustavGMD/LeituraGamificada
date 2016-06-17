using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : GameState
{
	public Canvas inventoryCanvas;

	public Player playerRef;

	public ItemManager itemManagerRef;
	public ScreenNavigation screenNavigationRef;

	public Button backMenu;

	public GameObject inventorySlot;
	public GameObject inventoryItem;
	public GameObject slotPanel;

	int slotAmount;

	int idAtual;

	public List<Custom.Item> items = new List<Custom.Item>();
	public List<GameObject> slots = new List<GameObject>();

	public Text titulo;
	public Text attack;
	public Text defense;
	public Text agility;
	public Text stamina;

	public Text pagesTotal;
	public Text pagesRead;
	public Text chaptersTotal;
	public Text chaptersRead;

	public void Awake()
	{
		slotAmount = 16;
		for(int i=0;i<slotAmount;i++)
		{
			items.Add (new Custom.Item ());
			slots.Add (Instantiate (inventorySlot));
			slots [i].transform.SetParent (slotPanel.transform);
			slots[i].transform.localScale = new Vector2(2, 2);
		}
	}

	public override void Initialize()
	{
		backMenu.onClick.AddListener (delegate {
			ChangeState (StateName.MENU);
		});
	}

	public void AddItem(Custom.Item item)
	{
		Custom.Item itemToAdd = item;
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
		DataManager.SaveItems (items);
		screenNavigationRef.Back ();
	}

	public void ApplyEdit()
	{
        Custom.Item __temp = FindbyID(idAtual);
        __temp.pagesRead = int.Parse(pagesRead.text);
        __temp.chaptersRead = int.Parse(chaptersRead.text);
        __temp = Custom.Item.GenerateNewItem(__temp.name, __temp.id, __temp.pagesTotal, __temp.pagesRead, __temp.chaptersTotal, __temp.chaptersRead, __temp.baseLevel);
        items[items.IndexOf(FindbyID(idAtual))] = __temp;

        Stats(idAtual);
        DataManager.SaveItems(items);
		screenNavigationRef.Back ();
	}
	public void EditItem()
	{
		screenNavigationRef.EditScreen ();

		pagesTotal.text = " / " + FindbyID (idAtual).pagesTotal.ToString();
		chaptersTotal.text = " / " + FindbyID (idAtual).chaptersTotal.ToString();
	}
	public void EquipItem()
	{
		if(playerRef.equippedItem.Count < 2 && !playerRef.equippedItem.Contains(FindbyID(idAtual)))
		{
			playerRef.equippedItem.Add (FindbyID(idAtual));

			screenNavigationRef.EquipUnequipScreen (true);
		}
	}
	public void UnequipItem()
	{
		playerRef.equippedItem.Remove (FindbyID (idAtual));

		screenNavigationRef.EquipUnequipScreen (false);
	}

	public void Stats(int id)
	{
		screenNavigationRef.StatsScreen ();

		if (playerRef.equippedItem.Contains(FindbyID(id)))
		{
			screenNavigationRef.EquipUnequipScreen (true);
		}
		else
		{
			screenNavigationRef.EquipUnequipScreen (false);
		}

		titulo.text = FindbyID (id).name;
		attack.text = FindbyID (id).attack.ToString();
		defense.text = FindbyID (id).defense.ToString();
		agility.text = FindbyID (id).agility.ToString();
		stamina.text = FindbyID (id).stamina.ToString();
	}

	public void NextItemStats()
	{
		if (FindbyID (idAtual + 1).id != -1)
		{
			Stats (idAtual + 1);
			idAtual += 1;
		}
	}
	public void AnteriorItemStats()
	{
		if (FindbyID (idAtual - 1).id != -1)
		{
			Stats (idAtual - 1);
			idAtual -= 1;
		}
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

	public Custom.Item FindbyID(int id)
	{
		for(int i=0;i<items.Count;i++)
		{
			if(items[i].id == id)
				return items[i];
		}
		return null;
	}

	public void FillInventory(Custom.Item item)
	{
		Custom.Item itemToAdd = item;
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
					idAtual = p_int;
					Stats(idAtual);
				};
				break;
			}
		}
	}
}