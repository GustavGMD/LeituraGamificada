using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatManager : GameState
{
    //UI variables
    public Canvas combatCanvas;

    //gameplay variables
    public Player player;
    public Enemy enemy;
    
	public override void Initialize () {
	
	}
	
	public override void Update () {
	
	}

    public override void Enable()
    {
        base.Enable();

        combatCanvas.gameObject.SetActive(true);
    }

    public override void Disable()
    {
        base.Disable();

        combatCanvas.gameObject.SetActive(false);
    }
}
