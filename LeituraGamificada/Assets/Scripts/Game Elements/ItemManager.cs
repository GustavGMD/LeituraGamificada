using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {

	InventoryManager InventoryManagerRef;
	public List<Custom.Item> items = new List<Custom.Item>();
	public int id;

    public void Start()
    {
		InventoryManagerRef = GetComponent<InventoryManager> ();
		id = 1;
    }

	public void CreateItem()
	{
		Custom.Item __tempItem = Custom.Item.GenerateNewItem("Nome do livro " + id.ToString(), id, 100, 0, 10, 0, id);
		//Debug.Log("Tipo: " + __tempItem.type.ToString() + " Elemento: " + __tempItem.element.ToString()  + " Ataque: " + __tempItem.attack + " Defesa: " + __tempItem.defense + " Agilidade: " + __tempItem.agility + " Estamina: " + __tempItem.stamina);
		items.Add (__tempItem);
		InventoryManagerRef.AddItem (id);
		id++;
	}

	public void DeleteItem()
	{
		id--;
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
}