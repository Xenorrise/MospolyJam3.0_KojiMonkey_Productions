using System;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public float solariumCost, scrapCost, mechanismsCost, foodCost, peopleCost, doingTime, devastationTime, devastationCoef;
    public int curEfficiency, curDevastation, baseDevastationDecrease, addEffeciancy;
    public bool isDoing, isActive;
    float curDoingTime, curDevastationTime;
    Slider doingSlider, devastationSlider;
    public bool[] neighborEffectsUsed;
    protected CityEconomy cityEconomy;
    protected Transform thisTR;

    void OnEnable()
    {
        neighborEffectsUsed = new bool[4];
        cityEconomy = FindAnyObjectByType<CityEconomy>();
        thisTR = GetComponent<Transform>();
        doingSlider = transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        devastationSlider = transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        devastationSlider.maxValue = curDevastation;
        devastationSlider.value = curDevastation;
        doingSlider.maxValue = doingTime;
        doingSlider.value = 0f;
        isDoing = true;
    }

    public virtual void EfficiencyCalculating(int addEffeciency)
    {
        //curEfficiency = Mathf.RoundToInt(curPeople / maxPeopleCost);
    }

    public virtual void NeighborSlotsEffect()
    {

    }

    public virtual void NeighborSlotsEffectCheck()
    {
        BuildingSlot curSlot = thisTR.parent.GetComponent<BuildingSlot>();
        
        if (curSlot.row + 1 < cityEconomy.buildingSlots.GetLength(0) && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>() != null)
        {
            Debug.Log(gameObject.name);
            cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().NeighborSlotsEffect();
        }
        if (curSlot.row - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>() != null)
        {
            cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().NeighborSlotsEffect();
        }
        if (curSlot.col + 1 < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>() != null)
        {
            cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>().NeighborSlotsEffect();
        }
        if (curSlot.col - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>() != null)
        {
            cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>().NeighborSlotsEffect();
        }
    }

    void FixedUpdate()
    {
        if (isActive && isDoing)
        {
            if(curDoingTime < doingTime)
            {
                curDoingTime += Time.fixedDeltaTime;
                doingSlider.value = curDoingTime;
            }
            else
            {
                Doing();
            }
            if (curDevastationTime < devastationTime)
            {
                curDevastationTime += Time.fixedDeltaTime;
            }
            else
            {
                curDevastationTime = 0f;
                Devastation();
            }
        }
    }

    public virtual void Doing()
    {
        curDoingTime = 0f;
        doingSlider.value = 0f;
    }

    public virtual void Devastation()
    {
        curDevastation -= Convert.ToInt32(baseDevastationDecrease * devastationCoef);
        devastationSlider.value = curDevastation;
    }
}
