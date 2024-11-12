using UnityEngine;

public class MilitaryBuilding : Building
{
    public float damage;
    public AudioClip shotSound;
    public GameObject shotFire;
    CurEnemy curEnemy;

    void Awake()
    {
        curEnemy = FindAnyObjectByType<CurEnemy>();
    }

    void Start()
    {
        if(isActive)
            NeighborSlotsEffectCheck();
    }

    public override void Doing()
    {
        base.Doing();
        if (curEnemy.curEnemy == null)
        {
            isDoing = false;
            return;
        }
        curEnemy.TakingDamage(damage);
        mainSource.PlayOneShot(shotSound, 0.6f);
        shotFire.SetActive(true);
        Invoke(nameof(FireDisapper), 0.15f);
        if(curEnemy.curEnemy == null)
        {
            isDoing = false;
        }
    }

    public void FireDisapper()
    {
        shotFire.SetActive(false);
    }
}
