using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentsSelection : MonoBehaviour
{
    [SerializeField] Image motherboard;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject componentsObject;
    [SerializeField] GameObject motherboardComponentsObject;
    [SerializeField] GameObject powerSupplySlotsObject;
    public bool componentSlots;
    public bool motherboardComponents;
    public bool powerSupplySlots;
    
    public void MotherboardComponents()
    {
        motherboardComponents = true;
        componentSlots = false;
        powerSupplySlots = false;
        motherboardComponentsObject.SetActive(true);
        componentsObject.SetActive(false);
        powerSupplySlotsObject.SetActive(false);
        motherboard.sprite = sprites[1];
    }
    public void ComponentsSlots()
    {
        motherboardComponents = false;
        componentSlots = true;
        powerSupplySlots = false;
        motherboardComponentsObject.SetActive(false);
        componentsObject.SetActive(true);
        powerSupplySlotsObject.SetActive(false);
        motherboard.sprite = sprites[2];
    }
    public void PowerSupplySlots()
    {
        motherboardComponents = false;
        componentSlots = false;
        powerSupplySlots = true;
        motherboardComponentsObject.SetActive(false);
        componentsObject.SetActive(false);
        powerSupplySlotsObject.SetActive(true);
        motherboard.sprite = sprites[3];
    }
}
