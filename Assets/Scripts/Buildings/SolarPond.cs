using UnityEngine;

public class SolarPond : CultureBuilding
{
    public float peopleDecrease, solariumDecrease, foodIncrease;

    public override void Doing()
    {
        base.Doing();
        float newPeople = float.Parse(cityEconomy.people.text) - peopleDecrease;
        float newSolarium = float.Parse(cityEconomy.solarium.text) - solariumDecrease;
        float newFood = float.Parse(cityEconomy.food.text) + foodIncrease;
        cityEconomy.people.text = newPeople.ToString();
        cityEconomy.solarium.text = newSolarium.ToString();
        cityEconomy.food.text = newFood.ToString();
    }
}
