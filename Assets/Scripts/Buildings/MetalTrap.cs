using System;
using UnityEngine;

public class MetalTrap: IndustrialBuilding
{
    public int scrapProduction, curScrapProduction;

    void Awake()
    {
        curScrapProduction = scrapProduction;
    }

    public override void Doing()
    {
        base.Doing();
        float newCrap = float.Parse(cityEconomy.scrap.text) + scrapProduction;
        cityEconomy.scrap.text = newCrap.ToString();
    }

    public override void EfficiencyCalculating(int addEffeciency)
    {
        curEfficiency += addEffeciency;
        curScrapProduction = scrapProduction * curEfficiency / 100;
    }
}
