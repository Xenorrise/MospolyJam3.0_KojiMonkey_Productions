using UnityEngine;

public class TownHall : ResidentionalBuilding
{
    public float devastationDecrease;

    void Start()
    {
        if (isActive)
        {
            NeighborSlotsEffect();
        }
    }

    public override void NeighborSlotsEffect()
    {
        BuildingSlot curSlot = thisTR.parent.GetComponent<BuildingSlot>();
        if (curSlot.row + 1 < cityEconomy.buildingSlots.GetLength(0) && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>() != null)
        {
            if (!neighborEffectsUsed[0])
            {
                cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().devastationCoef -= devastationDecrease;
                neighborEffectsUsed[0] = true;
            }
        }
        if (curSlot.row - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>() != null)
        {
            if (!neighborEffectsUsed[1])
            {
                cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().devastationCoef -= devastationDecrease;
                neighborEffectsUsed[1] = true;
            }
        }
        if (curSlot.col + 1 < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>() != null)
        {
            if (!neighborEffectsUsed[2])
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>().devastationCoef -= devastationDecrease;
                neighborEffectsUsed[2] = true;
            }
        }
        if (curSlot.col - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>() != null)
        {
            if (!neighborEffectsUsed[3])
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>().devastationCoef -= devastationDecrease;
                neighborEffectsUsed[3] = true;
            }
        }
    }

    public override void Doing()
    {
        base.Doing();
    }

    public override void Demolition()
    {
        BuildingSlot curSlot = thisTR.parent.GetComponent<BuildingSlot>();
        if (curSlot.row + 1 < cityEconomy.buildingSlots.GetLength(0) && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>() != null)
        {
            if (neighborEffectsUsed[0])
            {
                cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().devastationCoef += devastationDecrease;
                neighborEffectsUsed[0] = false;
            }
        }
        if (curSlot.row - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>() != null)
        {
            if (neighborEffectsUsed[1])
            {
                cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().devastationCoef += devastationDecrease;
                neighborEffectsUsed[1] = false;
            }
        }
        if (curSlot.col + 1 < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>() != null)
        {
            if (neighborEffectsUsed[2])
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>().devastationCoef += devastationDecrease;
                neighborEffectsUsed[2] = false;
            }
        }
        if (curSlot.col - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>() != null)
        {
            if (neighborEffectsUsed[3])
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>().devastationCoef += devastationDecrease;
                neighborEffectsUsed[3] = false;
            }
        }
        base.Demolition();
    }
}
