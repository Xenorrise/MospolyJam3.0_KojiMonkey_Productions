using System;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public float solariumCost, scrapCost, mechanismsCost, foodCost, peopleCost, doingTime, devastationTime, devastationCoef;
    public int curEfficiency, curDevastation, baseDevastationDecrease;
    public bool isDoing, isActive;
    float curDoingTime, curDevastationTime;
    Slider doingSlider, devastationSlider;

    void OnEnable()
    {
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
