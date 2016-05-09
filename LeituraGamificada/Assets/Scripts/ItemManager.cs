using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour {

    public void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            Custom.Item __tempItem = Custom.Item.GenerateNewItem("Nome do livro" + i.ToString(), 100, 0, 10, 0, i);
            Debug.Log("Tipo: " + __tempItem.tipo.ToString() + " Elemento: " + __tempItem.elemento.ToString()  + " Ataque: " + __tempItem.ataque + " Defesa: " + __tempItem.defesa + " Agilidade: " + __tempItem.agilidade + " Estamina: " + __tempItem.estamina);
        }
    }
}
