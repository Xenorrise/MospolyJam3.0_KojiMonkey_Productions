using UnityEngine;

public class Building : MonoBehaviour
{
    public float moneyCost, scrapCost, maxPeopleCost;
    public int curEfficiency, curDevastation;

    public virtual void EfficiencyCalculating(float curPeople)
    {
        curEfficiency = Mathf.RoundToInt(curPeople / maxPeopleCost);
    }

    public virtual void Production()
    {

    }
}
