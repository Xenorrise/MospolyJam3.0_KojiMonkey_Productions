using UnityEngine;
using UnityEngine.UI;

public class CityEconomy : MonoBehaviour
{
    public Text people, scrap, solarium, food, mechanisms;
    public BuildingSlot[,] buildingSlots;

    void Awake()
    {
        buildingSlots = new BuildingSlot[5, 5];
    }
}
