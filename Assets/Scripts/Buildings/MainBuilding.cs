using UnityEngine;

public class MainBuilding : IndustrialBuilding
{
    public int mechanismsProduction, curMechanismsProduction;

    void Awake()
    {
        curMechanismsProduction = mechanismsProduction;
    }

    public override void Doing()
    {
        base.Doing();
        float newMechanisms = float.Parse(cityEconomy.food.text) + curMechanismsProduction;
        cityEconomy.food.text = newMechanisms.ToString();
    }

    public override void EfficiencyCalculating(int addEffeciency)
    {
        curEfficiency += addEffeciency;
        curMechanismsProduction = mechanismsProduction * curEfficiency / 100;
    }
}
