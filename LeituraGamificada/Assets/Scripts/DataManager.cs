using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this is a static class used for saving a loading data from Unity's PlayerPrefs
public class DataManager : MonoBehaviour {

    enum InfoName
    {
        CONTAINS_SAVED_DATA,
        NUMBER_OF_ITEMS,
        ITEM,
        PLAYER
    }

    enum InfoItem
    {
        NAME,
        ID,
        PAGES_TOTAL,
        PAGES_READ,
        CHAPTERS_TOTAL,
        CHAPTERS_READ,
        BASE_LEVEL,
        TYPE,
        ATTACK,
        DEFENSE,
        AGILITY,
        STAMINA,
        ELEMENT
    }

    enum InfoPlayer
    {
        LEVEL,
        ATTACK,
        DEFENSE,
        AGILITY,
        STAMINA
    }

    public static void SaveItems(List<Custom.Item> p_itemList)
    {
        string __key = InfoName.NUMBER_OF_ITEMS.ToString();
        PlayerPrefs.SetInt(__key, p_itemList.Count);

        for (int i = 0; i < p_itemList.Count; i++)
        {
            SaveItemAttribute(i, InfoItem.NAME, p_itemList[i].name);
            SaveItemAttribute(i, InfoItem.ID, p_itemList[i].id);
            SaveItemAttribute(i, InfoItem.PAGES_TOTAL, p_itemList[i].pagesTotal);
            SaveItemAttribute(i, InfoItem.PAGES_READ, p_itemList[i].pagesRead);
            SaveItemAttribute(i, InfoItem.CHAPTERS_TOTAL, p_itemList[i].chaptersTotal);
            SaveItemAttribute(i, InfoItem.CHAPTERS_READ, p_itemList[i].chaptersRead);
            SaveItemAttribute(i, InfoItem.BASE_LEVEL, p_itemList[i].baseLevel);
            SaveItemAttribute(i, InfoItem.TYPE, (int)p_itemList[i].type);
            SaveItemAttribute(i, InfoItem.ATTACK, p_itemList[i].attack);
            SaveItemAttribute(i, InfoItem.DEFENSE, p_itemList[i].defense);
            SaveItemAttribute(i, InfoItem.AGILITY, p_itemList[i].agility);
            SaveItemAttribute(i, InfoItem.STAMINA, p_itemList[i].stamina);
            SaveItemAttribute(i, InfoItem.ELEMENT, (int)p_itemList[i].element);
        }
    }
    static public List<Custom.Item> LoadItems()
    {
        List<Custom.Item> __items = new List<Custom.Item>();
        int __amountOfItems;
        Custom.Item __tempItem;

        string __key = InfoName.NUMBER_OF_ITEMS.ToString();
        __amountOfItems = PlayerPrefs.GetInt(__key);

        for (int i = 0; i < __amountOfItems; i++)
        {
            __tempItem = new Custom.Item();
            __tempItem.name = LoadItemAttributeString(i, InfoItem.NAME);
            __tempItem.id = LoadItemAttributeInt(i, InfoItem.ID);
            __tempItem.pagesTotal = LoadItemAttributeInt(i, InfoItem.PAGES_TOTAL);
            __tempItem.pagesRead = LoadItemAttributeInt(i, InfoItem.PAGES_READ);
            __tempItem.chaptersTotal = LoadItemAttributeInt(i, InfoItem.CHAPTERS_TOTAL);
            __tempItem.chaptersRead = LoadItemAttributeInt(i, InfoItem.CHAPTERS_READ);
            __tempItem.baseLevel = LoadItemAttributeInt(i, InfoItem.BASE_LEVEL);
            __tempItem.type = (Custom.Item.ItemTipo)LoadItemAttributeInt(i, InfoItem.TYPE);
            __tempItem.attack = LoadItemAttributeInt(i, InfoItem.ATTACK);
            __tempItem.defense = LoadItemAttributeInt(i, InfoItem.DEFENSE);
            __tempItem.agility = LoadItemAttributeInt(i, InfoItem.AGILITY);
            __tempItem.stamina = LoadItemAttributeInt(i, InfoItem.STAMINA);
            __tempItem.element = (Custom.Item.ItemElemento)LoadItemAttributeInt(i, InfoItem.ELEMENT);

            __items.Add(__tempItem);
        }

        return __items;
    }

    static void SaveItemAttribute(int p_index, InfoItem p_attribute, int p_value)
    {
        string __key = InfoName.ITEM.ToString() + p_index.ToString() + p_attribute.ToString();
        PlayerPrefs.SetInt(__key, p_value);
    }
    static void SaveItemAttribute(int p_index, InfoItem p_attribute, string p_value)
    {
        string __key = InfoName.ITEM.ToString() + p_index.ToString() + p_attribute.ToString();
        PlayerPrefs.SetString(__key, p_value);
    }

    static int LoadItemAttributeInt(int p_index, InfoItem p_attribute)
    {
        string __key = InfoName.ITEM.ToString() + p_index.ToString() + p_attribute.ToString();
        return PlayerPrefs.GetInt(__key);
    }
    static string LoadItemAttributeString(int p_index, InfoItem p_attribute)
    {
        string __key = InfoName.ITEM.ToString() + p_index.ToString() + p_attribute.ToString();
        return PlayerPrefs.GetString(__key);
    }

    public static void SavePlayer(Player p_player)
    {
        SavePlayerAttribute(InfoPlayer.LEVEL, p_player.level);
        SavePlayerAttribute(InfoPlayer.ATTACK, p_player.baseAttack);
        SavePlayerAttribute(InfoPlayer.DEFENSE, p_player.baseDefense);
        SavePlayerAttribute(InfoPlayer.AGILITY, p_player.baseAgility);
        SavePlayerAttribute(InfoPlayer.STAMINA, p_player.baseStamina);
    }
    public static void LoadPlayer(Player p_player)
    {
        p_player.level = LoadPlayerAttribute(InfoPlayer.LEVEL);
        p_player.baseAttack = LoadPlayerAttribute(InfoPlayer.ATTACK);
        p_player.baseDefense = LoadPlayerAttribute(InfoPlayer.DEFENSE);
        p_player.baseAgility = LoadPlayerAttribute(InfoPlayer.AGILITY);
        p_player.baseStamina = LoadPlayerAttribute(InfoPlayer.STAMINA);
    }

    static void SavePlayerAttribute(InfoPlayer p_attribute, int p_value)
    {
        string __key = InfoName.PLAYER.ToString() + p_attribute.ToString(); 
        PlayerPrefs.SetInt(__key, p_value);
    }
    static int LoadPlayerAttribute(InfoPlayer p_attribute)
    {
        string __key = InfoName.PLAYER.ToString() + p_attribute.ToString();
        return PlayerPrefs.GetInt(__key);
    }
}
