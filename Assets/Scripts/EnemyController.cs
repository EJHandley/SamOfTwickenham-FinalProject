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

    public void CoinTossWon()
    {
        int coinTossChoice = Random.Range(1, 101);

        if (coinTossChoice <= 75)
        {
            gameManager.KickingPhase();
        }
        else if (coinTossChoice > 75)
        {
            gameManager.KickReturn();
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
        }

        if(gameManager.isAttackPhase == true)
        {
            int y = Random.Range(1, 101);

            if(y <= 40)
            {
                enemyCombat.UseAttackOne();
            }
            else if(y > 40 && y <= 60)
            {
                enemyCombat.UseAttackTwo();
            }
            else if(y > 60 && y <= 75)
            {
                enemyCombat.UseAttackOne();
            }
            else if(y > 75 && y <= 85)
            {
                enemyCombat.UseAttackTwo();
            }
            else if(y > 85 && y <= 95)
            {
                enemyCombat.UseAttackThree();
            }
            else if(y > 95)
            {
                enemyCombat.UseAttackThree();
            }
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
        }
    }
}
