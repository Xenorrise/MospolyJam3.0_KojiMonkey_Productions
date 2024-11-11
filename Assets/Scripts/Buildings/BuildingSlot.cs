using UnityEngine;
using UnityEngine.UI;

public class BuildingSlot : MonoBehaviour
{
    public GameObject curBuilding;
    public int row, col;
    public bool itMilitarySlot;
    PlayerController controller;
    Image curBuildingImage;
    CityEconomy cityEconomy;

    void Awake()
    {
        controller = FindAnyObjectByType<PlayerController>();
        curBuildingImage = GetComponent<Image>();
        cityEconomy = FindAnyObjectByType<CityEconomy>();
    }

    void Start()
    {
        cityEconomy.buildingSlots[row, col] = this;
    }

    public void CursorEnter()
    {
        if(controller.curSelectedBuilding != null && curBuilding == null)
        {
            curBuildingImage.sprite = controller.curSelectedBuilding.GetComponent<Image>().sprite;
            curBuildingImage.color = new(curBuildingImage.color.r, curBuildingImage.color.g, curBuildingImage.color.b, 0.5f);
        }
    }

    public void CursorExit()
    {
        if (controller.curSelectedBuilding != null && curBuilding == null)
        {
            curBuildingImage.sprite = controller.baseTemplate;
            curBuildingImage.color = new(curBuildingImage.color.r, curBuildingImage.color.g, curBuildingImage.color.b, 1f);
        }
    }

    public void Pressed()
    {
        bool isMilitaryRight = false;
        if (controller.curSelectedBuilding.GetComponent<MilitaryBuilding>() != null)
        {
            if (itMilitarySlot)
                isMilitaryRight = true; 
        }
        else if(!itMilitarySlot)
            isMilitaryRight = true;
        if (controller.curSelectedBuilding != null && curBuilding == null && isMilitaryRight)
        {
            curBuilding = Instantiate(controller.curSelectedBuilding);
            curBuilding.GetComponent<Building>().isActive = true;
            curBuilding.transform.position = transform.position;
            curBuilding.transform.SetParent(transform, true);
            curBuilding.transform.localScale = Vector3.one;
            curBuilding.GetComponent<Building>().NeighborSlotsEffectCheck();
            curBuildingImage.color = new(curBuildingImage.color.r, curBuildingImage.color.g, curBuildingImage.color.b, 1f);
            controller.curSelectedBuilding = null;
        }
    }
}
