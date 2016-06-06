using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatManager : GameState
{
    //UI variables
    public Canvas combatCanvas;
    public Button enemyButton;
    public Slider playerAPSlider;
    public Slider playerHPSlider;
    public Slider enemyAPSlider;
    public Slider enemyHPSlider;

    //gameplay variablespublic 
    public Player player;
    public Enemy enemy;

    private bool _playing = false;

    
	public override void Initialize ()
    {
        enemyButton.onClick.AddListener(delegate
        {
            TryAttack(player, enemy);
        });

	}
	
	public override void Update ()
    {
        if (_playing)
        {
            player.IncreseAP();
            enemy.IncreseAP();

            playerAPSlider.value = player.GetAttributeCurrentAP() / player.GetAttributeTotalAP();
            playerHPSlider.value = (float)(player.GetAttributeCurrentHP()) / player.GetAttributeTotalHP();
            enemyAPSlider.value = enemy.GetAttributeCurrentAP() / enemy.GetAttributeTotalAP();
            enemyHPSlider.value = (float)(enemy.GetAttributeCurrentHP()) / enemy.GetAttributeTotalHP();

            //IA improvisada
            if(enemy.GetAttributeCurrentAP() > 1)
            {
                if (Random.value < 0.01) TryAttack(enemy, player);
            }
            
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

    public bool TryAttack(Unit p_attacker, Unit p_defender)
    {
        if (p_attacker.GetAttributeCurrentAP() >= 1)
        {
            //tenta atacar o inimigo
            Debug.Log(p_attacker + " attacked " + p_defender);

            //apply damage
            if (p_defender.ReceiveDamage(CalculateDamage(p_attacker, p_defender)))
            {
                if(p_defender == enemy)
                {
                    //player level up
                }

                //game over
                ChangeState(StateName.MENU);
            }

            //edit attack related variables
            p_attacker.currentAP -= 1;

            Debug.Log(p_defender.currentHP);
            return true;
        }
        else
        {
            return false;
        }
    }
}
