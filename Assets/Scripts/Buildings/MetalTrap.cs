using UnityEngine;

public class MetalTrap: IndustrialBuilding
{
    public int scrapProduction;
    CityEconomy cityEconomy;

    void Awake()
    {
        cityEconomy = FindAnyObjectByType<CityEconomy>();
    }

    public override void Doing()
    {
        base.Doing();
        //cityEconomy.scrap += scrapProduction;
    }
}
