using UnityEngine;
using System.Collections;
using System;

public class GameState : MonoBehaviour {

    public enum StateName
    {
        MENU,
        COMBAT,
        INVENTORY
    };

    public event Action<StateName> onStateChange;

    public StateName state;

    public virtual void Initialize()
    {
        
    }

    public virtual void Update()
    {

    }

    public virtual void Enable()
    {
        Debug.Log("Enabling State");
    }

    public virtual void Disable()
    {

    }

    public virtual void ChangeState(StateName p_state)
    {
        if (onStateChange != null) onStateChange(p_state);
    }
}
