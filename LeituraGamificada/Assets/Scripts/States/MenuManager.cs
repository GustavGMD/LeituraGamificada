using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : GameState
{
    public Canvas menuCanvas;
    public Button fightButton;
    public Button inventoryButton;

    public Player player;
    public Enemy enemy;

	public Text level;

    public override void Initialize () {
        fightButton.onClick.AddListener(delegate
        {
            ChangeState(StateName.COMBAT);
        });

        inventoryButton.onClick.AddListener(delegate
        {
            ChangeState(StateName.INVENTORY);
        });
        
        if(player.level == 0)
        {
            player.InitializeAttributes(1, 10, 10, 10, 10, 100);
        }

        GenerateNewEnemy();
	}
	
	public override void Update () {
	
	}

    public override void Enable()
    {
        base.Enable();

        menuCanvas.gameObject.SetActive(true);
		level.text = player.level.ToString();
    }

    public override void Disable()
    {
        base.Disable();

        menuCanvas.gameObject.SetActive(false);
    }

    public void GenerateNewEnemy()
    {
        int __enemyLevelRange = (int)((float)player.level/30);
        int __enemyLevel = player.level + Random.Range(-__enemyLevelRange, __enemyLevelRange);
        enemy.InitializeAttributes(1, 10, 10, 10, 10, 100);

        for (int i = 0; i < __enemyLevel-1; i++)
        {
            enemy.LevelUp();
        }
    }
}