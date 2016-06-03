using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryManager : GameState
{
	public Canvas inventoryCanvas;
	public Button menuButton;

	public override void Initialize () {

		menuButton.onClick.AddListener(delegate
		{
			ChangeState(StateName.MENU);
		});
	}

	public override void Update () {

	}

	public override void Enable()
	{
		base.Enable();

		inventoryCanvas.gameObject.SetActive(true);
	}

	public override void Disable()
	{
		base.Disable();

		inventoryCanvas.gameObject.SetActive(false);
	}
}