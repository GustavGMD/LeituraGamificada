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
        public int id = -1;
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

        public Sprite Sprite;


        private bool abilityReleased = false;

        private static int atributeGeneratingValue = 10;

        public static Item GenerateNewItem(string p_nome, int p_id, int p_paginasTotal, int p_paginasLidas, int p_capitulosTotal, int p_capitulosLidos, int p_nivelBase)
        {
            float __taxaDeLeitura = p_capitulosTotal > 0 ? (((float)p_capitulosLidos) / p_capitulosTotal) : (((float)p_paginasLidas) / p_paginasTotal);
            Item __tempItem = new Item();
            Random.seed = p_nome.GetHashCode();

            __tempItem.name = p_nome;
            __tempItem.id = p_id;
            __tempItem.pagesTotal = p_paginasTotal;
            __tempItem.pagesRead = p_paginasLidas;
            __tempItem.chaptersTotal = p_capitulosTotal;
            __tempItem.chaptersRead = p_capitulosLidos;
            __tempItem.baseLevel = p_nivelBase;
            __tempItem.Sprite = Resources.Load<Sprite>("Sprites/Items/cursorSword_silver");

            __tempItem.type = (ItemTipo)(Random.Range(0, System.Enum.GetNames(typeof(ItemTipo)).Length));
            __tempItem.element = (ItemElemento)(Random.Range(0, System.Enum.GetNames(typeof(ItemElemento)).Length));
            
            __tempItem.attack = GenerateAttributeValue(p_nivelBase, __taxaDeLeitura);
            __tempItem.defense = GenerateAttributeValue(p_nivelBase, __taxaDeLeitura);
            __tempItem.agility = GenerateAttributeValue(p_nivelBase, __taxaDeLeitura);
            __tempItem.stamina = GenerateAttributeValue(p_nivelBase, __taxaDeLeitura);

            return __tempItem;
        }

        public static int GenerateAttributeValue(int p_nivelBase, float p_taxaDeLeitura)
        {
            int __attribute = (int)((Random.Range((p_nivelBase - 1) * atributeGeneratingValue, p_nivelBase * atributeGeneratingValue)) * ((p_taxaDeLeitura * 0.5f) + 0.5f));

            return __attribute;
        }
    }
}