using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Enemy Attack Moves")]
    public AttackMoves a_Move1;
    public AttackMoves a_Move2;
    public AttackMoves a_Move3; 
    public AttackMoves a_Move4;
    public AttackMoves a_Move5;
    public AttackMoves a_Move6;

    [Header("Enemy Defence Moves")]
    public DefenceMoves d_Move1;
    public DefenceMoves d_Move2;
    public DefenceMoves d_Move3;
    public DefenceMoves d_Move4;
    public DefenceMoves d_Move5;
    public DefenceMoves d_Move6;

    [Header("Enemy Kick Moves")]
    public KickingMoves k_Move1;
    public KickingMoves k_Move2;
    public KickingMoves k_Return;

    void Start()
    {

    }

    void Update()
    {

    }

    public void PickKick()
    {
        int x = Random.Range(1, 101);

        if (x <= 75)
        {
            GameManager.instance.enemyController.EnemyKickMove(k_Move1);
        }
        else if (x > 75)
        {
            GameManager.instance.enemyController.EnemyKickMove(k_Move2);
        }
        return;
    }

    public void KickReturn()
    {
        GameManager.instance.enemyController.EnemyKickReturn(k_Return);
    }

    public void PickAttack()
    {
        int y = Random.Range(1, 101);

        if (y <= 40)
        {
            GameManager.instance.enemyController.EnemyAttackMove(a_Move1);
        }
        else if (y > 40 && y <= 55)
        {
            GameManager.instance.enemyController.EnemyAttackMove(a_Move2);
        }
        else if (y > 55 && y <= 80)
        {
            GameManager.instance.enemyController.EnemyAttackMove(a_Move3);
        }
        else if (y > 80 && y <= 90)
        {
            GameManager.instance.enemyController.EnemyAttackMove(a_Move4);
        }
        else if (y > 90 && y <= 95)
        {
            GameManager.instance.enemyController.EnemyAttackMove(a_Move5);
        }
        else if (y > 95)
        {
            GameManager.instance.enemyController.EnemyAttackMove(a_Move6);
        }
    }

    public void PickDefence()
    {
        int z = Random.Range(1, 101);

        if (z <= 40)
        {
            GameManager.instance.enemyController.EnemyDefenceMove(d_Move1);
        }
        else if (z > 40 && z <= 60)
        {
            GameManager.instance.enemyController.EnemyDefenceMove(d_Move2);
        }
        else if (z > 60 && z <= 75)
        {
            GameManager.instance.enemyController.EnemyDefenceMove(d_Move3);
        }
        else if (z > 75 && z <= 85)
        {
            GameManager.instance.enemyController.EnemyDefenceMove(d_Move4);
        }
        else if (z > 85 && z <= 95)
        {
            GameManager.instance.enemyController.EnemyDefenceMove(d_Move5);
        }
        else if (z > 95)
        {
            GameManager.instance.enemyController.EnemyDefenceMove(d_Move6);
        }
        return;
    }
}
