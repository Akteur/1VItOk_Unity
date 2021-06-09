using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentsSelection : MonoBehaviour
{
    [SerializeField] Image motherboard;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject componentsObject;
    [SerializeField] GameObject motherboardComponentsObject;
    [SerializeField] GameObject powerSupplySlotsObject;
    [SerializeField] TextMeshProUGUI information;
    public bool componentSlots;
    public bool motherboardComponents;
    public bool powerSupplySlots;
    
    public void MotherboardComponents()
    {
        information.text = "Для получения информации нажмите кнопки под данной панелью " +
            "а затем нажмите по выделенным облостям на картинке слева." +
            "\n\nДля открытия меню паузы нажмите кнопку Esc на клавиатуре. Чтобы перейти к сборке компьютера, " +
            "вам необходимо из меню паузы нажать на кнопку \"Building\" и, если вы еще не авторизированы, " +
            "авторизироваться.";
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
        information.text = "Для получения информации нажмите кнопки под данной панелью " +
            "а затем нажмите по выделенным облостям на картинке слева." +
            "\n\nДля открытия меню паузы нажмите кнопку Esc на клавиатуре. Чтобы перейти к сборке компьютера, " +
            "вам необходимо из меню паузы нажать на кнопку \"Building\" и, если вы еще не авторизированы, " +
            "авторизироваться.";
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
        information.text = "Для получения информации нажмите кнопки под данной панелью " +
            "а затем нажмите по выделенным облостям на картинке слева." +
            "\n\nДля открытия меню паузы нажмите кнопку Esc на клавиатуре. Чтобы перейти к сборке компьютера, " +
            "вам необходимо из меню паузы нажать на кнопку \"Building\" и, если вы еще не авторизированы, " +
            "авторизироваться.";
        motherboardComponents = false;
        componentSlots = false;
        powerSupplySlots = true;
        motherboardComponentsObject.SetActive(false);
        componentsObject.SetActive(false);
        powerSupplySlotsObject.SetActive(true);
        motherboard.sprite = sprites[3];
    }
}
