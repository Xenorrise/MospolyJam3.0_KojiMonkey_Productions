using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject curSelectedBuilding, buildingController, curSelectedControlBuilding;
    public Sprite baseTemplate;
    public Vector3 addPosition;
    public AudioClip demolitionSound, deselectSound;
    CityEconomy cityEconomy;
    AudioSource mainSource;
    void Awake()
    {
        cityEconomy = FindAnyObjectByType<CityEconomy>();
        mainSource = FindAnyObjectByType<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            CancelSelecting();
    }

    public void BuildingControl()
    {
        buildingController.transform.position = Input.mousePosition + addPosition;
        buildingController.SetActive(true);
    }

    public void BuildingUpgrade()
    {

    }

    public void BuildingDemolition()
    {
        if (!curSelectedControlBuilding.GetComponent<Building>().cantDemolished)
        {
            BuildingSlot curSlot = curSelectedControlBuilding.transform.parent.GetComponent<BuildingSlot>();
            if (curSlot.row + 1 < cityEconomy.buildingSlots.GetLength(0) && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row + 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().neighborEffectsUsed[1] = false;
            }
            if (curSlot.row - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row - 1, curSlot.col].transform.GetChild(1).GetComponent<Building>().neighborEffectsUsed[0] = false;
            }
            if (curSlot.col + 1 < cityEconomy.buildingSlots.GetLength(1) && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col + 1].transform.GetChild(1).GetComponent<Building>().neighborEffectsUsed[3] = false;
            }
            if (curSlot.col - 1 >= 0 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.childCount > 1 && cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>() != null)
            {
                cityEconomy.buildingSlots[curSlot.row, curSlot.col - 1].transform.GetChild(1).GetComponent<Building>().neighborEffectsUsed[2] = false;
            }
            curSelectedControlBuilding.GetComponent<Building>().Demolition();
            mainSource.PlayOneShot(demolitionSound);
            CancelSelecting();
        }
    }

    public void BuildingSkillUsing()
    {

    }

    public void CancelSelecting()
    {
        if (curSelectedControlBuilding != null)
        {
            curSelectedControlBuilding = null;
            buildingController.SetActive(false);
            mainSource.PlayOneShot(deselectSound);
        }
        else
            curSelectedBuilding = null;
    }
}
