using UnityEngine;

public class Rehub : ResidentionalBuilding
{
    public float peopleDecrease;
    public int addEffeciancy;
    CityEconomy cityEconomy;
    Transform thisTR;

    void Awake()
    {
        cityEconomy = FindAnyObjectByType<CityEconomy>();
        thisTR = GetComponent<Transform>();
    }

    void Start()
    {
        if(isActive)
        {
            BuildingSlot curSlot = thisTR.parent.GetComponent<BuildingSlot>();
            if (curSlot.row + 1 < cityEconomy.buildingSlots.GetLength(0) && curSlot.col < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().EfficiencyCalculating(addEffeciancy);
            }
            if (curSlot.row - 1 < cityEconomy.buildingSlots.GetLength(0) && curSlot.col < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col] != null && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().EfficiencyCalculating(addEffeciancy);
            }
            if (curSlot.row < cityEconomy.buildingSlots.GetLength(0) && curSlot.col + 1 < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1] != null && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>().EfficiencyCalculating(addEffeciancy);
            }
            if (curSlot.row < cityEconomy.buildingSlots.GetLength(0) && curSlot.col - 1 < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1] != null && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>().EfficiencyCalculating(addEffeciancy);
            }
        }
    }
    public override void Doing()
    {
        base.Doing();
        float newPeople = float.Parse(cityEconomy.people.text) - peopleDecrease;
        cityEconomy.people.text = newPeople.ToString();
    }
}
