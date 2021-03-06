﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Unit
{
    
    public List<Custom.Item> equippedItem = new List<Custom.Item>();

    public void Start()
    {
    }

    public override int GetAttributeAttack()
    {
        int __itemSum = 0;
        for (int i = 0; i < equippedItem.Count; i++)
        {
            __itemSum += equippedItem[i].attack;
        }
        return baseAttack + __itemSum;
    }
    public override int GetAttributeDefense()
    {
        int __itemSum = 0;
        for (int i = 0; i < equippedItem.Count; i++)
        {
            __itemSum += equippedItem[i].defense;
        }
        return baseDefense + __itemSum;
    }
    public override int GetAttributeAgility()
    {
        int __itemSum = 0;
        for (int i = 0; i < equippedItem.Count; i++)
        {
            __itemSum += equippedItem[i].agility;
        }
        return baseAgility + __itemSum;
    }
    public override int GetAttributeStamina()
    {
        int __itemSum = 0;
        for (int i = 0; i < equippedItem.Count; i++)
        {
            __itemSum += equippedItem[i].stamina;
        }
        return baseStamina + __itemSum;
    }
    public override int GetAttributeCurrentHP()
    {
        return currentHP;
    }
    public override float GetAttributeCurrentAP()
    {
        return currentAP;
    }

    public override void LevelUp()
    {
        base.LevelUp();
        DataManager.SavePlayer(this);
    }
}