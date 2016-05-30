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

    private float _APIncrementRatio = 0.25f; //per second, depends on Agility

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
    public virtual int GetAttributeTotalHP()
    {
        return totalHP;
    }
    public virtual int GetAttributeCurrentHP()
    {
        return currentHP;
    }
    public virtual float GetAttributeTotalAP()
    {
        return totalAP;
    }
    public virtual float GetAttributeCurrentAP()
    {
        return currentAP;
    }

    public virtual void IncreseAP()
    {
        currentAP += _APIncrementRatio * Time.deltaTime;
        if (currentAP > totalAP) currentAP = totalAP;
    }

    //return true if the unit is defeated
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

    public virtual void InitializeAttributes(int p_level, int p_baseAttack, int p_baseDefense, int p_baseAgility, int p_baseStamina, int p_totalHP, int p_totalAP)
    {
        level = p_level;
        baseAttack = p_baseAttack;
        baseDefense = p_baseDefense;
        baseAgility = p_baseAgility;
        baseStamina = p_baseStamina;
        totalHP = p_totalHP;
        totalAP = p_totalAP;

        currentHP = totalHP;
        currentAP = 0;
        _APIncrementRatio = (float)baseAgility / 100;
    }
}
