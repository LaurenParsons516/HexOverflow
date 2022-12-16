using IronPython;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using Microsoft.Scripting.Hosting;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public Sprite fireball;
    public Sprite bullet;
    public Sprite wrench;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject specialAttackPrefab;

    GameObject player;
    GameObject enemy;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleHUD PlayerHUD;
    public BattleHUD EnemyHUD;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;
    public TMP_InputField codeInput;

    public GameObject errorBox;
    public Text errorText;

        
    public BattleState state;


    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        errorBox.SetActive(false);

        player = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = player.GetComponent<Unit>();

        enemy = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemy.GetComponent<Unit>();


        dialogueText.text = "Oh no! " + enemyUnit.unitName + " has trapped you and now you must battle!";

        PlayerHUD.SetHUD(playerUnit);
        EnemyHUD.SetHUD(enemyUnit);

        playerUnit.healthChange += hp =>
        {
            PlayerHUD.SetHP(hp);
        };

        enemyUnit.healthChange += hp =>
        {
            EnemyHUD.SetHP(hp);
        };


        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {

        // Using IronPython Library to use Python within C#
        var eng = IronPython.Hosting.Python.CreateEngine();
        var scope = eng.CreateScope();

        scope.SetVariable("attack", new System.Func<int, bool>(enemyUnit.TakeDamage));
        //scope.GetVariable("attack").__name__ = "attack";

        // defining python funtion and linking the to C# methods

        if (FunctionTracker.IsUnlocked("Fireball"))
        {
            scope.SetVariable("fireball_attack", new System.Action(() => performSpecialAttack(fireball, 20)));
        }

        if (FunctionTracker.IsUnlocked("Bullet"))
        {
            scope.SetVariable("bullet_attack", new System.Action(() => performSpecialAttack(bullet, 10)));
        }

        if (FunctionTracker.IsUnlocked("Wrench"))
        {
            scope.SetVariable("wrench_attack", new System.Action(() => performSpecialAttack(wrench, 5)));
        }

        scope.SetVariable("log", new System.Action<object>(Debug.Log)); //used to be "print", but didn't work because it is using Python 2 which is a statement, not a function.
        string code = codeInput.text;
        Debug.Log(code);

        //Exception handling for Python code
        try
        {
            if (!string.IsNullOrEmpty(code))
            {
                // executing code with "special attack type" functions defined earlier
                eng.Execute(code, scope);
            } else
            {
                errorBox.SetActive(true);
                errorText.text = "Please enter some code for your attack!";
                yield break;
            }
            
        } catch (System.Exception e)
        {
            errorBox.SetActive(true);

            //takes c# exception and formats to Python exception
            ExceptionOperations eo = eng.GetService<ExceptionOperations>();
            string error = eo.FormatException(e);

            errorText.text = error;
            yield break;
        }
            


        bool isDead = enemyUnit.currentHP <= 0;
        
        EnemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack was successful!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
            SceneManager.LoadScene(4);
        } else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        PlayerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You feel renewed strength!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        PlayerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        } else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(3);
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerHeal());
    }

    public void performSpecialAttack(Sprite attackType, int damageAmount)
    {
        GameObject attack = Instantiate(specialAttackPrefab) as GameObject;
        attack.GetComponent<SpriteRenderer>().sprite = attackType;
        Vector3 position = player.transform.position;
        position.y += Random.Range(-1, 1);
        attack.transform.position = position;
        SpecialAttack attackScript = attack.GetComponent<SpecialAttack>();

        attackScript.target = enemy;
        attackScript.caster = player;
        attackScript.victim = enemyUnit;
        attackScript.damageAmount = damageAmount;
    }
}
