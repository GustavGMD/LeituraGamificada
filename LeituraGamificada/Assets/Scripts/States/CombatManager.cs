using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatManager : GameState
{
    //UI variables
    public Canvas combatCanvas;
    public Button enemyButton;
    public Slider actionPointsSlider;

    //gameplay variables
    public Player player;
    public Enemy enemy;

    private bool _playing = false;

    
	public override void Initialize ()
    {
        enemyButton.onClick.AddListener(delegate
        {
            if(player.GetAttributeCurrentAP() >= 1)
            {
                //tenta atacar o inimigo
                Debug.Log("Attacked");

                //apply damage
                if(enemy.ReceiveDamage(CalculateDamage(player, enemy)))
                {
                    //game over
                    ChangeState(StateName.MENU);
                }

                //edit attack related variables
                player.currentAP -= 1;

                Debug.Log(enemy.currentHP);
            }
        });

	}
	
	public override void Update ()
    {
        if (_playing)
        {
            player.IncreseAP();
            enemy.IncreseAP();
            actionPointsSlider.value = player.GetAttributeCurrentAP() / player.GetAttributeTotalAP();
        }
	}

    public override void Enable()
    {
        base.Enable();

        combatCanvas.gameObject.SetActive(true);
        GenerateEnemy(player.level);

        StartGame();
    }

    public override void Disable()
    {
        base.Disable();
        combatCanvas.gameObject.SetActive(false);
    }

    public void GenerateEnemy(int p_playerLevel)
    {
        enemy.InitializeAttributes(1, 10, 10, 10, 10, 100, 2);
        player.InitializeAttributes(1, 10, 10, 10, 10, 100, 2);
    }

    public void StartGame()
    {
        _playing = true;
    }

    public int CalculateDamage(Unit p_attacker, Unit p_defender)
    {
        int __resultingDamage = 0;

        __resultingDamage = p_attacker.GetAttributeAttack() - (p_defender.GetAttributeDefense() / 2);

        return __resultingDamage;
    }
}
