using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP, gunCount, gunDamage, damageCooldown;

    public virtual void Death()
    {
        Destroy(gameObject);
    }

    public virtual void Damage()
    {

    }
}
