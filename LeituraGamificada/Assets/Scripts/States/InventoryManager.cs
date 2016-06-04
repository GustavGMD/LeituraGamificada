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

		slotAmount = 16;
		inventoryPanel = GameObject.Find ("InventoryPanel");
		slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;
		/*for(int i=0;i<slotAmount;i++)
		{
			slots.Add (Instantiate (inventorySlot));
			slots [i].transform.SetParent (slotPanel.transform);
		}*/
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