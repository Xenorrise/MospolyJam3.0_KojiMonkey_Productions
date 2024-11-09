using UnityEngine;

public class ScrapFactory : CivilBuilding
{
    public int scrapProduction;
    CityEconomy cityEconomy;

    void Awake()
    {
        cityEconomy = FindAnyObjectByType<CityEconomy>();
    }

    public override void Production()
    {
        cityEconomy.scrap += scrapProduction;
    }
}
