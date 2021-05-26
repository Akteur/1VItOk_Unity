using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool paused = false;
    public static PauseMenu instance = null;
    [SerializeField] RectTransform menuRectTransform;
    [SerializeField] RectTransform canvasRectTransform;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject aim;
    [SerializeField] GameObject table;
    public bool canPause = true;
    public bool achievementsOpened = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        canPause = true;
        pauseMenu = GameObject.Find("PauseMenu");
        menuRectTransform = pauseMenu.GetComponent<RectTransform>();
        canvasRectTransform = GameObject.Find("Canvas").GetComponent<RectTransform>();
        mainCamera = GameObject.Find("Main Camera");
        aim = GameObject.Find("Aim");
        table = GameObject.Find("Table");
        if (pauseMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
        }
    }
    void Update()
    {
        menuRectTransform.sizeDelta = new Vector2(canvasRectTransform.sizeDelta.x - 50, canvasRectTransform.sizeDelta.y - 50);
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !achievementsOpened)
            {
                paused = !paused;
            }
        }
        if (pauseMenu != null)
        {
            PauseMenuVisibility();
        }
        if (achievementsOpened)
        {
            pauseMenu.SetActive(false);
        }
    }
    private void PauseMenuVisibility()
    {
        if (paused)
        {
            aim.SetActive(false);
            pauseMenu.SetActive(true);
            Cursor.visible = true;
        }
        else
        {
            aim.SetActive(true);
            pauseMenu.SetActive(false);
            Cursor.visible = false;
        }
    }
}