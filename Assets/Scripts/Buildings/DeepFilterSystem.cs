using UnityEngine;

public class DeepFilterSystem : IndustrialBuilding
{
    public int solariumProduction, curSolariumProduction;

    void Awake()
    {
        curSolariumProduction = solariumProduction;
    }

    public override void Doing()
    {
        base.Doing();
        float newSolarium = float.Parse(cityEconomy.solarium.text) + solariumProduction;
        cityEconomy.solarium.text = newSolarium.ToString();
    }

    public override void EfficiencyCalculating(int addEffeciency)
    {
        curEfficiency += addEffeciency;
        curSolariumProduction = solariumProduction * curEfficiency / 100;
    }
}
