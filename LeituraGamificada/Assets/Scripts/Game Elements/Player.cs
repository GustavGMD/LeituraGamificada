using UnityEngine;
using System.Collections;

public class Player : Unit
{
    
    public Custom.Item[] equippedItem;

    public override int GetAttributeAttack()
    {
        int __itemSum = 0;
        for (int i = 0; i < equippedItem.Length; i++)
        {
            __itemSum += equippedItem[i].attack;
        }
        return baseAttack + __itemSum;
    }
    public override int GetAttributeDefense()
    {
        return baseDefense;
    }
    public override int GetAttributeAgility()
    {
        return baseAgility;
    }
    public override int GetAttributeStamina()
    {
        return baseStamina;
    }
    public override int GetAttributeCurrentHP()
    {
        return currentHP;
    }
    public override float GetAttributeCurrentAP()
    {
        return currentAP;
    }

}
