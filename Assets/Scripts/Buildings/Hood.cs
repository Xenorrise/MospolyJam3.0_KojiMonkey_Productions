using UnityEngine;

public class Hood : ResidentionalBuilding
{
    public float peopleIncrease, solariumDecrease;

    public override void Doing()
    {
        base.Doing();
        float newPeople = float.Parse(cityEconomy.people.text) + peopleIncrease * (1 + 0.1f * cityEconomy.housesCount);
        float newSolarium = float.Parse(cityEconomy.solarium.text) - solariumDecrease * (1 + 0.1f * cityEconomy.housesCount);
        cityEconomy.people.text = newPeople.ToString();
        cityEconomy.solarium.text = newSolarium.ToString();
    }
}
