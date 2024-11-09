using UnityEngine;

public class CurEnemy : MonoBehaviour
{
    public Enemy curEnemy;

    public void EnemyArriving(Enemy enemy)
    {
        curEnemy = enemy;
        InvokeRepeating(nameof(Damage), curEnemy.damageCooldown, curEnemy.damageCooldown);
    }

    public void TakingDamage(float damage)
    {
        curEnemy.HP -= damage;
        if(curEnemy.HP <= 0f)
        {
            curEnemy.Death();
            curEnemy = null;
        }
    }

    public void Damage()
    {

    }
}
