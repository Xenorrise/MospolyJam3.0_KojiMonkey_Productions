using UnityEngine;
using UnityEngine.UI;

public class CurEnemy : MonoBehaviour
{
    public Enemy curEnemy;
    public Slider HPSlider;

    public void EnemyArriving(Enemy enemy)
    {
        curEnemy = enemy;
        HPSlider.maxValue = curEnemy.HP;
        HPSlider.value = curEnemy.HP;
        InvokeRepeating(nameof(Damage), curEnemy.damageCooldown, curEnemy.damageCooldown);
    }

    public void TakingDamage(float damage)
    {
        curEnemy.HP -= damage;
        HPSlider.value = curEnemy.HP;
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
