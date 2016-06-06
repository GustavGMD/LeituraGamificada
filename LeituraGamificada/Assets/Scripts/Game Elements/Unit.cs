using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public int level = 0;
    public int baseAttack = 0;
    public int baseDefense = 0;
    public int baseAgility = 0;
    public int baseStamina = 0;

    public int totalHP = 0;
    public int currentHP = 0;
    public int totalAP = 0;
    public float currentAP = 0;

    protected float _APIncrementRatio = 0.25f; //per second, depends on Agility

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
        currentAP += (_APIncrementRatio * GetAttributeAgility()/10) * Time.deltaTime;
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

    public virtual void InitializeAttributes(int p_level, int p_baseAttack, int p_baseDefense, int p_baseAgility, int p_baseStamina, int p_totalHP)
    {
        level = p_level;
        baseAttack = p_baseAttack;
        baseDefense = p_baseDefense;
        baseAgility = p_baseAgility;
        baseStamina = p_baseStamina;
        totalHP = p_totalHP;
        totalAP = (int)((float)GetAttributeStamina()/10);

        currentHP = totalHP;
        currentAP = 0;
    }

    public virtual void LevelUp()
    {
        level++;
        baseAttack += 20;
        baseDefense += 10;
        baseAgility += 2;
        baseStamina += 1;
        totalHP += 20;
        currentHP = totalHP;
        currentAP = 0;
    }

    public virtual void ReadyForCombat()
    {
        currentHP = totalHP;
        currentAP = 0;
    }
}
