using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameManager gameManager;
    public EnemyCombat enemyCombat;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void CoinTossWon(string text)
    {
        int coinTossChoice = Random.Range(1, 101);

        if (coinTossChoice <= 75)
        {
            gameManager.tutorialText.text = text + "attack. You will now kick the ball to them. Choose to either kick deep and pin the opponent deep into their half," +
                "or go short and try to recover the ball.";
            gameManager.KickingPhase();
        }
        else if (coinTossChoice > 75)
        {
            gameManager.KickReturn();
            gameManager.tutorialText.text = text + "defend. You will now receive the ball from them. Your opponent will either kick it deep into your territory, or go" +
                "short and attempt to recover the ball.";
        }
    }

    public void EnemyAttack()
    {
        if(gameManager.isKickingPhase == true)
        {
            int x = Random.Range(1, 101);

            if(x <= 75)
            {
                enemyCombat.UseKickOne();
            } 
            else if(x > 75)
            {
                enemyCombat.UseKickTwo();
            }
            return;
        }

        if(gameManager.isKickReturn == true)
        {
            enemyCombat.KickReturn();
            return;
        }

        if(gameManager.isAttackPhase == true)
        {
            int y = Random.Range(1, 101);

            if(y <= 40)
            {
                enemyCombat.UseAttackOne();
            }
            else if(y > 40 && y <= 55)
            {
                enemyCombat.UseAttackTwo();
            }
            else if(y > 55 && y <= 80)
            {
                enemyCombat.UseAttackOne();
            }
            else if(y > 80 && y <= 90)
            {
                enemyCombat.UseAttackTwo();
            }
            else if(y > 90 && y <= 95)
            {
                enemyCombat.UseAttackThree();
            }
            else if(y > 95)
            {
                enemyCombat.UseAttackThree();
            }
            return;
        }

        if(gameManager.isDefencePhase == true)
        {
            int z = Random.Range(1, 101);
            
            if(z <= 40)
            {
                enemyCombat.UseDefenceOne();
            }
            else if (z > 40 && z <= 60)
            {
                enemyCombat.UseDefenceTwo();
            }
            else if (z > 60 && z <= 75)
            {
                enemyCombat.UseDefenceOne();
            }
            else if (z > 75 && z <= 85)
            {
                enemyCombat.UseDefenceTwo();
            }
            else if (z > 85 && z <= 95)
            {
                enemyCombat.UseDefenceThree();
            }
            else if (z > 95)
            {
                enemyCombat.UseDefenceThree();
            }
            return;
        }
    }
}
