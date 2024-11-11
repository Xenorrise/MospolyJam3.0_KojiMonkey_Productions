using UnityEngine;

public class TownHall : ResidentionalBuilding
{
    public float devastationDecrease;
    CityEconomy cityEconomy;
    Transform thisTR;

    void Awake()
    {
        cityEconomy = FindAnyObjectByType<CityEconomy>();
        thisTR = GetComponent<Transform>();
    }

    void Start()
    {
        if (isActive)
        {
            BuildingSlot curSlot = thisTR.parent.GetComponent<BuildingSlot>();
            if (curSlot.row + 1 < cityEconomy.buildingSlots.GetLength(0) && curSlot.col < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().devastationCoef -= devastationDecrease;
            }
            if (curSlot.row - 1 < cityEconomy.buildingSlots.GetLength(0) && curSlot.col < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col] != null && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().devastationCoef -= devastationDecrease;
            }
            if (curSlot.row < cityEconomy.buildingSlots.GetLength(0) && curSlot.col + 1 < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1] != null && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>().devastationCoef -= devastationDecrease;
            }
            if (curSlot.row < cityEconomy.buildingSlots.GetLength(0) && curSlot.col - 1 < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1] != null && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>().devastationCoef -= devastationDecrease;
            }
        }
    }
    public override void Doing()
    {
        base.Doing();
    }
}
