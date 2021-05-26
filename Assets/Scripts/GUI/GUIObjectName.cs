using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class GUIObjectName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI topButtonText;
    [SerializeField] TextMeshProUGUI middleButtonText;
    [SerializeField] TextMeshProUGUI bottomButtonText;
    [SerializeField] TextMeshProUGUI bottomButtonQText;
    [SerializeField] TextMeshProUGUI EButtonText;
    [SerializeField] TextMeshProUGUI shortExplain;
    [SerializeField] Text actionDescription;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject table;
    [SerializeField] Image actionDescriptionBackground;
    [SerializeField] Image eBackground;
    [SerializeField] Image helpBackground;
    [SerializeField] Image topButtonImage;
    [SerializeField] Image middleButtonImage;
    [SerializeField] Image bottomButtonImage;    
    [SerializeField] Image pickUpImage;
    [SerializeField] Image pickUpBackgroundImage;
    [SerializeField] Image shortExplainBackground;
    [SerializeField] GameObject achievementObject;
    [SerializeField] GameObject helpObject;
    [SerializeField] Transform canvas;
    Raycasting raycastScript;
    PickUpObject pickUpScript;
    BuildArea buildArea;
    PCbuilding pcBuildingScript;
    public bool showName = false;
    public bool canMove = true;
    public bool canLook = true;
    public bool controlPossibility = true;
    public bool achievementVisibility = false;
    public bool componentInstalled;
    public bool helpInstantiated = false;
    public bool achievementInstantiated = false;
    public bool buildAreaHelpPickup = false;
    public bool buildAreaHelpInstall = false;
    public string achievementText;
    public string helpText;
    private void Start()
    {
        raycastScript = mainCamera.GetComponent<Raycasting>();
        pickUpScript = mainCamera.GetComponent<PickUpObject>();
        buildArea = table.GetComponent<BuildArea>();
        pcBuildingScript = mainCamera.GetComponent<PCbuilding>();
    }
    private void Update()
    {
        if (raycastScript.succesful && !pcBuildingScript.pickedUp)
        {
            showName = true;
        }
        else
        {
            showName = false;
        }
        ControllSwitcher();
        Achievements();
    }
    public void OnGUI()
    {
        ShowGUI();
    }
    public void ControllSwitcher()
    {
        if (!controlPossibility && !canLook && !canMove)
        {
            controlPossibility = false;
        }
    }
    public void ShowGUI()
    {
        
        if(showName)
        {
            if (pickUpScript.PickedUp)
            {
                PickUpObjectOpacity(false);
            }
            else
            {
                PickUpObjectOpacity(true);
            }
        }
        else if(!showName && !buildArea.inBuildArea)
        {
            PickUpObjectOpacity(false);
        }
        else if(showName && buildArea.buildStarted)
        {
            ShortExplainTextGUI(true);
            PickUpObjectOpacity(true);
        }
        else if(buildArea.inBuildArea && !buildArea.buildStarted)
        {
            BuildStartingTextGUI(true);
            PressEOpacity(true);
        }
        if (buildArea.buildStarted)
        {
            BuildStartingTextGUI(false);
            PressEOpacity(false);
            BuildHelpTextGUI(true);
        }
        else
        {
            BuildHelpTextGUI(false);
        }
        
        if (buildArea.buildStarted)
        {
            if (!buildAreaHelpPickup)
            {
                if (!helpInstantiated)
                {
                    helpInstantiated = true;
                    buildAreaHelpPickup = true;
                    Instantiate(helpObject, canvas);
                }
            }
        }
        if(pcBuildingScript.pickedUp)
        {
            if (!buildAreaHelpInstall)
            {
                if (!helpInstantiated)
                {
                    helpInstantiated = true;
                    buildAreaHelpInstall = true;
                    Instantiate(helpObject, canvas);
                }
            }
        }
    }
    private void ShortExplainTextGUI(bool shortExplainTextVisibility)
    {
        if (shortExplainTextVisibility)
        {
            shortExplain.text = raycastScript.raycastedObject.GetComponent<Name>().shortExplain;
            ShortExplainOpacity(true);
        }
        else
        {
            shortExplain.text = null;
            ShortExplainOpacity(false);
        }
    }
    private void ShortExplainOpacity(bool shortExplainVisibility)
    {
        if (shortExplainVisibility)
        {
            shortExplainBackground.color = new Color(255, 255, 255, 0.7f);
        }
        else
        {
            shortExplainBackground.color = new Color(255, 255, 255, 0);
        }
    }
    private void Achievements()
    {
        if (componentInstalled)
        {
            if (!achievementInstantiated)
            {
                achievementInstantiated = true;
                Instantiate(achievementObject, canvas);
            }
        }
        componentInstalled = false;
    }
    private void BuildStartingTextGUI(bool buildStartingTextVisibility)
    {
        if (buildStartingTextVisibility)
        {
            actionDescription.text = "Войти в режим сборки";
            ActionDescriptionOpacity(true);
        }
        else
        {
            if (!showName)
            {
                actionDescription.text = "";
                ActionDescriptionOpacity(false);
            }
        }
    }
    private void BuildHelpTextGUI(bool helpTextVisibility)
    {
        if (helpTextVisibility)
        {
            topButtonText.text = "-взять комплектующее";
            middleButtonText.text = "-вверх(отдалить) / вниз(приблизить)";
            bottomButtonText.text = "-выйти";
            bottomButtonQText.text = "Esc";
            BuildHelpOpacity(true);
        }
        else
        {
            topButtonText.text = "";
            middleButtonText.text = "";
            bottomButtonText.text = "";
            bottomButtonQText.text = "";
            BuildHelpOpacity(false);
        }
    }
    private void PickUpObjectOpacity(bool pickUpObjectVisibility)
    {
        if (pickUpObjectVisibility)
        {
            actionDescription.text = raycastScript.raycastedObject.GetComponent<Name>().ObjectName;
            ActionDescriptionOpacity(true);
            if (!buildArea.inBuildArea)
            {
                ShortExplainTextGUI(true);
                LMBopacity(true);
            }
        }
        else
        {            
            actionDescription.text = "";
            ActionDescriptionOpacity(false);           
            LMBopacity(false);
            PressEOpacity(false);
            ShortExplainTextGUI(false);
        }
    }
    private void BuildHelpOpacity(bool helpVisibility)
    {
        if (helpVisibility)
        {
            helpBackground.color = new Color(255, 255, 255, 0.7f);
            topButtonImage.color = new Color(0, 0, 0, 1);
            middleButtonImage.color = new Color(0, 0, 0, 1);
            bottomButtonImage.color = new Color(0, 0, 0, 1);
        }
        else
        {
            helpBackground.color = new Color(255, 255, 255, 0);
            topButtonImage.color = new Color(0, 0, 0, 0);
            middleButtonImage.color = new Color(0, 0, 0, 0);
            bottomButtonImage.color = new Color(0, 0, 0, 0);
        }
    }
    private void PressEOpacity(bool actionVisibility)
    {
        if (actionVisibility)
        {
            EButtonText.text = "Е";
            eBackground.color = new Color(255, 255, 255, 0.7f);
        }
        else
        {
            EButtonText.text = "";
            eBackground.color = new Color(255, 255, 255, 0);
        }
    }
    private void ActionDescriptionOpacity(bool descriptionVisibility)
    {
        if (descriptionVisibility)
        {
            actionDescriptionBackground.color = new Color(255, 255, 255, 0.7f);
        }
        else
        {            
            actionDescriptionBackground.color = new Color(255, 255, 255, 0);
        }
    }
    private void LMBopacity(bool lmbVisibility)
    {
        if (lmbVisibility)
        {
            pickUpBackgroundImage.color = new Color(255, 255, 255, 1);
            pickUpImage.color = new Color(0, 0, 0, 1);
        }
        else
        {
            pickUpBackgroundImage.color = new Color(255, 255, 255, 0);
            pickUpImage.color = new Color(0, 0, 0, 0);
        }
    }
}