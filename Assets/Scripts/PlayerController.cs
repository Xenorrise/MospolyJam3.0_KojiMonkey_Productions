using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject curSelectedBuilding, buildingController, curSelectedControlBuilding, gameOverPanel, victoryPanel, buttonsPanel;
    public Sprite baseTemplate;
    public Vector3 addPosition;
    public AudioClip demolitionSound, deselectSound, startWarningSound, warningSound, gameOverSound, victorySound, repairSound;
    public int scrapRepairCost, addDevastation;
    CityEconomy cityEconomy;
    AudioSource mainSource;

    void Awake()
    {
        cityEconomy = FindAnyObjectByType<CityEconomy>();
        mainSource = FindAnyObjectByType<AudioSource>();
    }

    void Start()
    {
        mainSource.PlayOneShot(startWarningSound);
        Time.timeScale = 1f;
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

    public void BuildingRepair()
    {
        if(int.Parse(cityEconomy.scrap.text) >= scrapRepairCost && 100 - curSelectedControlBuilding.GetComponent<Building>().curDevastation >= addDevastation)
        {
            int newScrap = int.Parse(cityEconomy.scrap.text) - scrapRepairCost;
            cityEconomy.scrap.text = newScrap.ToString();
            curSelectedControlBuilding.GetComponent<Building>().curDevastation += addDevastation;
            curSelectedControlBuilding.GetComponent<Building>().devastationSlider.value = curSelectedControlBuilding.GetComponent<Building>().curDevastation;
            mainSource.PlayOneShot(repairSound);
            CancelSelecting();
        }
        else
        {
            mainSource.PlayOneShot(warningSound, 0.6f);
        }
    }

    public void StraightBuildingDemolition()
    {
        BuildingDemolition(curSelectedControlBuilding);
    }
    public void BuildingDemolition(GameObject building)
    {
        if (!building.GetComponent<Building>().cantDemolished)
        {
            BuildingSlot curSlot = building.transform.parent.GetComponent<BuildingSlot>();
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
            building.GetComponent<Building>().Demolition();
            FindAnyObjectByType<TipScript>().gameObject.SetActive(false);
            mainSource.PlayOneShot(demolitionSound);
            CancelSelecting();
        }
        else if(building.GetComponent<MainBuilding>() != null && building.GetComponent<Building>().curDevastation <= 0f)
        {
            building.GetComponent<Building>().Demolition();
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

    public void GameOver()
    {
        buttonsPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        mainSource.PlayOneShot(gameOverSound);
        StopAllCoroutines();
        Time.timeScale = 0f;
    }

    public void Vitory()
    {
        buttonsPanel.SetActive(false);
        victoryPanel.SetActive(true);
        mainSource.PlayOneShot(victorySound);
        StopAllCoroutines();
        Time.timeScale = 0f;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
