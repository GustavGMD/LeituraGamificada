using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour {

	public List<Custom.Item> items = new List<Custom.Item>();

    public void Start()
    {
        for (int i = 1; i <= 3; i++)
        {
            Custom.Item __tempItem = Custom.Item.GenerateNewItem("Nome do livro " + i.ToString(), i, 100, 0, 10, 0, i);
			//Debug.Log("Tipo: " + __tempItem.type.ToString() + " Elemento: " + __tempItem.element.ToString()  + " Ataque: " + __tempItem.attack + " Defesa: " + __tempItem.defense + " Agilidade: " + __tempItem.agility + " Estamina: " + __tempItem.stamina);
			items.Add (__tempItem);
        }

		//Debug.Log (FindbyID (2).name);
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