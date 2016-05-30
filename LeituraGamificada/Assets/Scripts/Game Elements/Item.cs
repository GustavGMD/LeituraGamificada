using UnityEngine;
using System.Collections;

namespace Custom
{
    public class Item
    {

        public enum ItemTipo
        {
            WEAPON,
            ARMOR
        }

        public enum ItemElemento
        {
            FIRE,
            ICE,
            ELETRICITY,
            POISON
        }

        public string name;
        public int pagesTotal;
        public int pagesRead;
        public int chaptersTotal;
        public int chaptersRead;
        public int baseLevel;

        public ItemTipo type;
        public int attack;
        public int defense;
        public int agility;
        public int stamina;
        public ItemElemento element;

        public int visualIndex = 0;


        private bool abilityReleased = false;

        private static int atributeGeneratingValue = 10;

        public static Item GenerateNewItem(string p_nome, int p_paginasTotal, int p_paginasLidas, int p_capitulosTotal, int p_capitulosLidos, int p_nivelBase)
        {
            Item __tempItem = new Item();
            Random.seed = p_nome.GetHashCode();

            __tempItem.name = p_nome;
            __tempItem.pagesTotal = p_paginasTotal;
            __tempItem.pagesRead = p_paginasLidas;
            __tempItem.chaptersTotal = p_capitulosTotal;
            __tempItem.chaptersRead = p_capitulosLidos;
            __tempItem.baseLevel = p_nivelBase;

            __tempItem.type = (ItemTipo)(Random.Range(0, System.Enum.GetNames(typeof(ItemTipo)).Length));
            __tempItem.element = (ItemElemento)(Random.Range(0, System.Enum.GetNames(typeof(ItemElemento)).Length));
            __tempItem.attack = Random.Range((p_nivelBase - 1) * atributeGeneratingValue, p_nivelBase * atributeGeneratingValue);
            __tempItem.defense = Random.Range((p_nivelBase - 1) * atributeGeneratingValue, p_nivelBase * atributeGeneratingValue);
            __tempItem.agility = Random.Range((p_nivelBase - 1) * atributeGeneratingValue, p_nivelBase * atributeGeneratingValue);
            __tempItem.stamina = Random.Range((p_nivelBase - 1) * atributeGeneratingValue, p_nivelBase * atributeGeneratingValue);

            return __tempItem;
        }        
    }    
}
