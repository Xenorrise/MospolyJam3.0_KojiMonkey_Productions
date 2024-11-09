using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanel : MonoBehaviour
{
    public Object building;
    PlayerController controller;
    GameObject tempBuilding;

    void Awake()
    {
        controller = FindAnyObjectByType<PlayerController>();
        tempBuilding = Instantiate(building).GameObject();
        Image tempBuildingImage = tempBuilding.GetComponent<Image>();
        transform.GetChild(0).GetComponent<Image>().sprite = tempBuildingImage.sprite;
        tempBuildingImage.color = new(tempBuildingImage.color.r, tempBuildingImage.color.g, tempBuildingImage.color.b, 0.5f);
    }

    public void SelectingBuilding()
    {
        controller.curSelectedBuilding = tempBuilding;
    }
}
