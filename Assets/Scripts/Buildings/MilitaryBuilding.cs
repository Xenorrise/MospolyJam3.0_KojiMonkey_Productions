using UnityEngine;

public class MilitaryBuilding : Building
{
    public float damage;
    CurEnemy curEnemy;

    void Awake()
    {
        curEnemy = FindAnyObjectByType<CurEnemy>();
    }

    public override void Doing()
    {
        base.Doing();
        curEnemy.TakingDamage(damage);
        if(curEnemy.curEnemy == null)
        {
            isDoing = false;
        }
    }
}
