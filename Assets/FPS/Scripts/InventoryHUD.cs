using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryHUD : MonoBehaviour
{
    public GameObject menuRoot1;
    static bool _isInventoryOpen = false;
    PlayerInputHandler m_PlayerInputsHandler;

    public void Display()
    {
        menuRoot1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // this breaks the pause menu ;__;
        //if (!menuRoot1.activeSelf && Input.GetMouseButtonDown(0))
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = true;
        //}

        // press I to pull up inventory
        if (Input.GetButtonDown("Inventory"))
        {
            // open panel if it's not already open
            if (!_isInventoryOpen)   
            {
                OpenInventoryPanel();
            }
            else
            {
                CloseInventoryPanel();
            }
        }

        // leaves inventory panel when you press Esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetButtonDown("Inventory")
            || (menuRoot1.activeSelf && Input.GetButtonDown(GameConstants.k_ButtonNameCancel)))
        {
            SetPauseMenuActivation(!menuRoot1.activeSelf);

        }

        if (Input.GetAxisRaw(GameConstants.k_AxisNameVertical) != 0)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }

    }

    private void Start()
    {
        m_PlayerInputsHandler = FindObjectOfType<PlayerInputHandler>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerInputHandler, InGameMenuManager>(m_PlayerInputsHandler, this);
        menuRoot1.SetActive(false);
    }

    void SetPauseMenuActivation(bool active)
    {
        menuRoot1.SetActive(active);

        if (menuRoot1.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(null);
            WeaponController.isPaused = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            WeaponController.isPaused = false;
        }

    }

    public void OpenInventoryPanel()
    {
        _isInventoryOpen = true;
        menuRoot1.SetActive(true);
    }

    public void CloseInventoryPanel()
    {
        _isInventoryOpen = false;
        menuRoot1.SetActive(false);
    }
}
