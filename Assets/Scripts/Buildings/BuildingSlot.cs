using UnityEngine;
using UnityEngine.UI;

public class BuildingSlot : MonoBehaviour
{
    public GameObject curBuilding;
    public int row, col;
    public bool itMilitarySlot;
    public AudioClip buildSound, selectSound, warningSound;
    PlayerController controller;
    Image curBuildingImage;
    CityEconomy cityEconomy;
    AudioSource mainSource;
    
    void Awake()
    {
        controller = FindAnyObjectByType<PlayerController>();
        curBuildingImage = GetComponent<Image>();
        cityEconomy = FindAnyObjectByType<CityEconomy>();
        mainSource = FindAnyObjectByType<AudioSource>();
    }

    void Start()
    {
        cityEconomy.buildingSlots[row, col] = this;
    }

    public void CursorEnter()
    {
        if (controller.curSelectedBuilding != null && curBuilding == null)
        {
            curBuildingImage.sprite = controller.curSelectedBuilding.GetComponent<Image>().sprite;
            curBuildingImage.color = new(curBuildingImage.color.r, curBuildingImage.color.g, curBuildingImage.color.b, 0.5f);
        }
        else if (curBuilding != null)
        {
            curBuilding.GetComponent<Image>().color = new(0f, 255f, 0f);
        }
    }

    public void CursorExit()
    {
        if (controller.curSelectedBuilding != null && curBuilding == null)
        {
            curBuildingImage.sprite = controller.baseTemplate;
            curBuildingImage.color = new(curBuildingImage.color.r, curBuildingImage.color.g, curBuildingImage.color.b, 1f);
        }
        else if (curBuilding != null)
        {
            curBuilding.GetComponent<Image>().color = new(255f, 255f, 255f);
        }
    }

    public void Pressed()
    {
        if (Input.GetMouseButton(0))
        {
            bool isMilitaryRight = false;
            if (controller.curSelectedBuilding != null && controller.curSelectedBuilding.GetComponent<MilitaryBuilding>() != null)
            {
                if (itMilitarySlot)
                    isMilitaryRight = true;
            }
            else if (!itMilitarySlot)
                isMilitaryRight = true;
            if (controller.curSelectedBuilding != null && curBuilding == null && isMilitaryRight)
            {
                Building futureBuilding = controller.curSelectedBuilding.GetComponent<Building>();
                if (futureBuilding.peopleCost <= float.Parse(cityEconomy.people.text) && futureBuilding.scrapCost <= float.Parse(cityEconomy.scrap.text) && futureBuilding.solariumCost <= float.Parse(cityEconomy.solarium.text) && futureBuilding.foodCost <= float.Parse(cityEconomy.food.text) && futureBuilding.mechanismsCost <= float.Parse(cityEconomy.mechanisms.text))
                {
                    curBuilding = Instantiate(controller.curSelectedBuilding);
                    curBuilding.GetComponent<Building>().isActive = true;
                    curBuilding.transform.position = transform.position;
                    curBuilding.transform.SetParent(transform, true);
                    curBuilding.transform.localScale = Vector3.one;
                    curBuilding.GetComponent<Building>().NeighborSlotsEffectCheck();
                    curBuildingImage.color = new(curBuildingImage.color.r, curBuildingImage.color.g, curBuildingImage.color.b, 1f);
                    curBuildingImage.sprite = controller.baseTemplate;
                    controller.curSelectedBuilding = null;
                    mainSource.PlayOneShot(buildSound, 0.25f);
                    float newPeople = float.Parse(cityEconomy.people.text) - futureBuilding.peopleCost;
                    float newScrap = float.Parse(cityEconomy.scrap.text) - futureBuilding.scrapCost;
                    float newSolarium = float.Parse(cityEconomy.solarium.text) - futureBuilding.solariumCost;
                    float newFood = float.Parse(cityEconomy.food.text) - futureBuilding.foodCost;
                    float newMechanisms = float.Parse(cityEconomy.mechanisms.text) - futureBuilding.mechanismsCost;
                    cityEconomy.people.text = newPeople.ToString();
                    cityEconomy.scrap.text = newScrap.ToString();
                    cityEconomy.solarium.text = newSolarium.ToString();
                    cityEconomy.food.text = newFood.ToString();
                    cityEconomy.mechanisms.text = newMechanisms.ToString();
                    CursorExit();
                    CursorEnter();
                }
                else
                {
                    mainSource.PlayOneShot(warningSound, 0.6f);
                }
            }
            else if (curBuilding != null)
            {
                controller.curSelectedControlBuilding = curBuilding;
                mainSource.PlayOneShot(selectSound, 0.5f);
                controller.BuildingControl();
            }
        }
    }
}
