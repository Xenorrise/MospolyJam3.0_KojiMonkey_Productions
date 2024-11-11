using UnityEngine;

public class FactoryOfFactories : IndustrialBuilding
{
    public int solariumProduction, scrapProduction, mechanismsProduction, curSolariumProduction, curScrapProduction, curMechanismsProduction;
    CityEconomy cityEconomy;
    int i = 0;

    void Awake()
    {
        cityEconomy = FindAnyObjectByType<CityEconomy>();
        curSolariumProduction = solariumProduction;
        curScrapProduction = scrapProduction;
        curMechanismsProduction = mechanismsProduction;
    }

    public override void Doing()
    {
        base.Doing();
        switch (i) 
        {
            case 0:
                float newSolarium = float.Parse(cityEconomy.solarium.text) + curSolariumProduction;
                cityEconomy.solarium.text = newSolarium.ToString(); 
                break;
            case 1:
                float newScrap = float.Parse(cityEconomy.scrap.text) + curScrapProduction;
                cityEconomy.scrap.text = newScrap.ToString();
                break;
            case 2:
                float newMechanisms = float.Parse(cityEconomy.mechanisms.text) + curMechanismsProduction;
                cityEconomy.mechanisms.text = newMechanisms.ToString();
                i = 0;
                break;
        }
        i++;
    }

    public override void EfficiencyCalculating(int addEffeciency)
    {
        curEfficiency += addEffeciency;
        curSolariumProduction = solariumProduction * curEfficiency / 100;
        curScrapProduction = scrapProduction * curEfficiency / 100;
        curMechanismsProduction = mechanismsProduction * curEfficiency / 100;
    }
}
