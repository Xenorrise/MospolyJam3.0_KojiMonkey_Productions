using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float HP, gunCount, damageCooldown, curDamageCooldown;
    public Slider damageCooldownSlider;
    public int gunDamage;
    CityEconomy cityEconomy;
    RoadMap map;

    void Start()
    {
        cityEconomy = FindAnyObjectByType<CityEconomy>();
        map = FindAnyObjectByType<RoadMap>();
        damageCooldownSlider.maxValue = damageCooldown;
    }

    void FixedUpdate()
    {
            if (curDamageCooldown < damageCooldown)
            {
                curDamageCooldown += Time.fixedDeltaTime;
                damageCooldownSlider.value = curDamageCooldown;
            }
            else
            {
                curDamageCooldown = 0f;
                Damage();
            }
    }
    public virtual void Death()
    {
        map.NextStage();
        Destroy(gameObject);
    }

    public virtual void Damage()
    {
        for(int i = 0; i < gunCount; i++)
        {
            float layer1Chance, layer2Chance, layer3Chance, layer4Chance, layer5Chance;
            List<BuildingSlot> layer1Slots = new List<BuildingSlot>(), layer2Slots = new List<BuildingSlot>(), layer3Slots = new List<BuildingSlot>(), layer4Slots = new List<BuildingSlot>(), layer5Slots = new List<BuildingSlot>();
            for (int j = 0; j < cityEconomy.buildingSlots.GetLength(0); j++)
            {
                for (int k = 0; k < cityEconomy.buildingSlots.GetLength(1); k++)
                {
                    if (k == 0 && cityEconomy.buildingSlots[j, k].transform.childCount > 1)
                        layer1Slots.Add(cityEconomy.buildingSlots[j, k]);
                    if (k == 1 && cityEconomy.buildingSlots[j, k].transform.childCount > 1)
                        layer2Slots.Add(cityEconomy.buildingSlots[j, k]);
                    if (k == 2 && cityEconomy.buildingSlots[j, k].transform.childCount > 1)
                        layer3Slots.Add(cityEconomy.buildingSlots[j, k]);
                    if (k == 3 && cityEconomy.buildingSlots[j, k].transform.childCount > 1)
                        layer4Slots.Add(cityEconomy.buildingSlots[j, k]);
                    if (k == 4 && cityEconomy.buildingSlots[j, k].transform.childCount > 1)
                        layer5Slots.Add(cityEconomy.buildingSlots[j, k]);
                }
            }
            layer1Chance = layer1Slots.Count / cityEconomy.buildingSlots.GetLength(0);
            layer2Chance = (1 - layer1Chance) * layer2Slots.Count / cityEconomy.buildingSlots.GetLength(0);
            layer3Chance = (1 - layer2Chance) * layer3Slots.Count / cityEconomy.buildingSlots.GetLength(0);
            layer4Chance = (1 - layer3Chance) * layer4Slots.Count / cityEconomy.buildingSlots.GetLength(0);
            layer5Chance = (1 - layer4Chance) * layer5Slots.Count / cityEconomy.buildingSlots.GetLength(0);
            float allChance = layer1Chance + layer2Chance + layer3Chance + layer4Chance + layer5Chance;
            float randNum = Random.Range(0, allChance);
            int attakingLayer;
            if(randNum <= layer1Chance)
            {
                attakingLayer = 0;
            }
            else if (randNum <= layer1Chance + layer2Chance)
            {
                attakingLayer = 1;
            }
            else if(randNum <= layer1Chance + layer2Chance + layer3Chance)
            {
                attakingLayer = 2;
            }
            else if(randNum <= layer1Chance + layer2Chance + layer3Chance + layer4Chance)
            {
                attakingLayer = 3;
            }
            else 
            {
                attakingLayer = 4;
            }
            switch(attakingLayer)
            {
                case 0:
                    int rand1Building = Random.Range(0, layer1Slots.Count - 1);
                    layer1Slots[rand1Building].transform.GetChild(1).GetComponent<Building>().TakingDamage(gunDamage, false);
                    layer1Slots[rand1Building].transform.GetChild(1).GetComponent<Building>().devastationSlider.value = layer1Slots[rand1Building].transform.GetChild(1).GetComponent<Building>().curDevastation;
                    break;
                case 1:
                    int rand2Building = Random.Range(0, layer2Slots.Count - 1);
                    layer2Slots[rand2Building].transform.GetChild(1).GetComponent<Building>().TakingDamage(gunDamage, false);
                    layer2Slots[rand2Building].transform.GetChild(1).GetComponent<Building>().devastationSlider.value = layer2Slots[rand2Building].transform.GetChild(1).GetComponent<Building>().curDevastation;
                    break;
                case 2:
                    int rand3Building = Random.Range(0, layer3Slots.Count - 1);
                    layer3Slots[rand3Building].transform.GetChild(1).GetComponent<Building>().TakingDamage(gunDamage, false);
                    layer3Slots[rand3Building].transform.GetChild(1).GetComponent<Building>().devastationSlider.value = layer3Slots[rand3Building].transform.GetChild(1).GetComponent<Building>().curDevastation;
                    break;
                case 3:
                    int rand4Building = Random.Range(0, layer4Slots.Count - 1);
                    layer4Slots[rand4Building].transform.GetChild(1).GetComponent<Building>().TakingDamage(gunDamage, false);
                    layer4Slots[rand4Building].transform.GetChild(1).GetComponent<Building>().devastationSlider.value = layer4Slots[rand4Building].transform.GetChild(1).GetComponent<Building>().curDevastation;
                    break;
                case 4:
                    int rand5Building = Random.Range(0, layer5Slots.Count - 1);
                    layer5Slots[rand5Building].transform.GetChild(1).GetComponent<Building>().TakingDamage(gunDamage, false);
                    layer5Slots[rand5Building].transform.GetChild(1).GetComponent<Building>().devastationSlider.value = layer5Slots[rand5Building].transform.GetChild(1).GetComponent<Building>().curDevastation;
                    break;
            }
        }
    }
}
