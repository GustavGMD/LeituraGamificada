using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {

	public InventoryManager InventoryManagerRef;
	public List<Custom.Item> items = new List<Custom.Item>();
	public int id;

	public Player PlayerRef;

	public Text titulo;
	public Text paginasTotais;
	public Text paginasLidas;
	public Text capitulosTotais;
	public Text capitulosLidos;

    public void Start()
    {
		id = 1;
    }

	public void CreateItem()
	{
		Custom.Item __tempItem = Custom.Item.GenerateNewItem(titulo.text, id, int.Parse(paginasTotais.text), int.Parse(paginasLidas.text), int.Parse(capitulosTotais.text), int.Parse(capitulosLidos.text), PlayerRef.level);
		Debug.Log ("Item criado com nome: " + __tempItem.name + " com paginas totais de: " + __tempItem.pagesTotal);
		//items.Add (__tempItem);
		InventoryManagerRef.AddItem (__tempItem);
		id++;
	}

	public void DeleteItem()
	{
		id--;
	}

	public void SetItemsList(List<Custom.Item> _items)
	{
		items = _items;
		for (int i = 0; i < _items.Count; i++)
		{	
			if (items [i].id != -1)
			{
				Custom.Item __tempItem = Custom.Item.GenerateNewItem (items [i].name, id, items [i].pagesTotal, items [i].pagesRead, items [i].chaptersTotal, items [i].chaptersRead, PlayerRef.level);
				InventoryManagerRef.FillInventory (__tempItem);
				id++;
			}
		}
	}
}