using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public int level;
    public int baseAttack;
    public int baseDefense;
    public int baseAgility;
    public int baseStamina;

    public int totalHP;
    public int currentHP;
    public int totalAP;
    public float currentAP;

    public virtual int GetAttributeAttack()
    {
        return baseAttack;
    }
    public virtual int GetAttributeDefense()
    {
        return baseDefense;
    }
    public virtual int GetAttributeAgility()
    {
        return baseAgility;
    }
    public virtual int GetAttributeStamina()
    {
        return baseStamina;
    }
    public virtual int GetAttributeCurrentHP()
    {
        return currentHP;
    }
    public virtual float GetAttributeCurrentAP()
    {
        return currentAP;
    }

    public virtual bool ReceiveDamage(int p_damage)
    {
        currentHP -= p_damage;
        if (currentHP<= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
