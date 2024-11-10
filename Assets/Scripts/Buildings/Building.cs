using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public float moneyCost, scrapCost, maxPeopleCost, doingTime;
    public int curEfficiency, curDevastation;
    public bool isDoing, isActive;
    public float curDoingTime;
    public Slider doingSlider;

    void OnEnable()
    {
        doingSlider = transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        doingSlider.maxValue = doingTime;
        doingSlider.value = 0f;
        isDoing = true;
    }

    public virtual void EfficiencyCalculating(float curPeople)
    {
        curEfficiency = Mathf.RoundToInt(curPeople / maxPeopleCost);
    }

    void FixedUpdate()
    {
        if (isActive && isDoing)
        {
            Debug.Log("1");
            if(curDoingTime < doingTime)
            {
                curDoingTime += Time.fixedDeltaTime;
                doingSlider.value = curDoingTime;
                Debug.Log("2");
            }
            else
            {
                Debug.Log("3");
                Doing();
            }
        }
    }

    public virtual void Doing()
    {
        curDoingTime = 0f;
        doingSlider.value = 0f;
    }
}
