public class CultureBuilding : Building
{
    void Awake()
    {
        if (isActive)
        {
            NeighborSlotsEffect();
        }
    }

    public override void NeighborSlotsEffect()
    {
        BuildingSlot curSlot = thisTR.parent.GetComponent<BuildingSlot>();
        if (curSlot.row + 1 < cityEconomy.buildingSlots.GetLength(0) && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
        {
            if (!neighborEffectsUsed[0])
            {
                cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().EfficiencyCalculating(addEffeciancy);
                neighborEffectsUsed[0] = true;
            }
        }
        if (curSlot.row - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
        {
            if (!neighborEffectsUsed[1])
            {
                cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().EfficiencyCalculating(addEffeciancy);
                neighborEffectsUsed[1] = true;
            }
        }
        if (curSlot.col + 1 < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
        {
            if (!neighborEffectsUsed[2])
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>().EfficiencyCalculating(addEffeciancy);
                neighborEffectsUsed[2] = true;
            }
        }
        if (curSlot.col - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<IndustrialBuilding>() != null)
        {
            if (!neighborEffectsUsed[3])
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>().EfficiencyCalculating(addEffeciancy);
                neighborEffectsUsed[3] = true;
            }
        }
    }
}
