using UnityEngine;
using UnityEngine.UI;

public class BuildingSlot : MonoBehaviour
{
    public GameObject curBuilding;
    PlayerController controller;
    Image curBuildingImage;

    void Awake()
    {
        controller = FindAnyObjectByType<PlayerController>();
        curBuildingImage = GetComponent<Image>();
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
        Debug.Log("!");
        if (controller.curSelectedBuilding != null && curBuilding == null)
        {
            curBuilding = Instantiate(controller.curSelectedBuilding);
            curBuildingImage.color = new(curBuildingImage.color.r, curBuildingImage.color.g, curBuildingImage.color.b, 1f);
        }
    }
}
