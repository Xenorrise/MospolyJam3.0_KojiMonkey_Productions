using UnityEngine;

public class Houses : ResidentionalBuilding
{
    public float peopleIncrease;

    void Start()
    {
        if (isActive)
        {
            cityEconomy.housesCount += 1;
        }
    }

    public override void Doing()
    {
        base.Doing();
    }
}
