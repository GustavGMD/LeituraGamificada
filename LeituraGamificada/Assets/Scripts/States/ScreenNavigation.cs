using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenNavigation : MonoBehaviour {

	public InventoryManager inventoryManagerRef;

	public Button backMenu;
	public Button newBookButton;
	public Button equipButton;
	public Button unequipButton;
	public Button editButton;

	public GameObject createItemPanel;
	public GameObject editItemPanel;
	public GameObject itemStatsPanel;
	public GameObject inventoryPanel;
	public GameObject slotPanel;

	// Use this for initialization
	void Start ()
	{
		createItemPanel.SetActive (false);
		itemStatsPanel.SetActive (false);
		editItemPanel.SetActive (false);
	}

	public void StatsScreen()
	{
		slotPanel.SetActive (false);
		itemStatsPanel.SetActive (true);
		newBookButton.gameObject.SetActive (false);
		backMenu.gameObject.SetActive (false);
	}

	public void EditScreen()
	{
		editItemPanel.SetActive (true);
		itemStatsPanel.SetActive (false);
	}
		
	public void EquipUnequipScreen(bool equipped)
	{
		if (equipped)
		{
			equipButton.gameObject.SetActive (false);
			unequipButton.gameObject.SetActive (true);
		}
		else
		{
			equipButton.gameObject.SetActive (true);
			unequipButton.gameObject.SetActive (false);
		}
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
		if (editItemPanel.activeSelf)
		{
			itemStatsPanel.SetActive (true);
			editItemPanel.SetActive (false);
		}
		else
		{
			slotPanel.SetActive (true);
			createItemPanel.SetActive (false);
			itemStatsPanel.SetActive (false);
			newBookButton.gameObject.SetActive (true);
			backMenu.gameObject.SetActive (true);
		}
	}
}