using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : GameState
{

    public Canvas menuCanvas;
    public Button fightButton;
    public Button inventoryButton;    

    public override void Initialize () {
        fightButton.onClick.AddListener(delegate ()
        {
            ChangeState(StateName.COMBAT);
        });

        inventoryButton.onClick.AddListener(delegate ()
        {
            ChangeState(StateName.INVENTORY);
        });
	}
	
	public override void Update () {
	
	}

    public override void Enable()
    {
        base.Enable();

        menuCanvas.gameObject.SetActive(true);
    }

    public override void Disable()
    {
        base.Disable();

        menuCanvas.gameObject.SetActive(false);
    }
    
}
