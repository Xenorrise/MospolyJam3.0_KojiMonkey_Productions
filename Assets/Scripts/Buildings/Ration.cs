using UnityEngine;

public class Ration : IndustrialBuilding
{
    public int foodProduction, curFoodProduction;
    CityEconomy cityEconomy;

    void Awake()
    {
        cityEconomy = FindAnyObjectByType<CityEconomy>();
        curFoodProduction = foodProduction;
    }

    public override void Doing()
    {
        base.Doing();
        float newFood = float.Parse(cityEconomy.food.text) + foodProduction;
        cityEconomy.food.text = newFood.ToString();
    }

    public override void EfficiencyCalculating(int addEffeciency)
    {
        curEfficiency += addEffeciency;
        curFoodProduction = foodProduction * curEfficiency / 100;
    }
}
