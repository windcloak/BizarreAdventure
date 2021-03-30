using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryHUD : MonoBehaviour
{
    public GameObject menuRoot;
    public static bool isInventoryOpen;
    PlayerInputHandler m_PlayerInputsHandler;

    // Update is called once per frame
    void Update()
    {
        //if (!menuRoot.activeSelf && Input.GetMouseButtonDown(0))
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //}

        // press I to pull up inventory
        if (Input.GetButtonDown("Inventory"))
        {
            // open panel if it's not already open
            if (!isInventoryOpen)   
            {
                OpenInventoryPanel();
            }
            else
            {
                CloseInventoryPanel();
            }
        }

        if (Input.GetButtonDown("Inventory")
    || (menuRoot.activeSelf && Input.GetButtonDown(GameConstants.k_ButtonNameCancel)))
        {
            SetPauseMenuActivation(!menuRoot.activeSelf);

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
        menuRoot.SetActive(false);
    }

    void SetPauseMenuActivation(bool active)
    {
        menuRoot.SetActive(active);

        if (menuRoot.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }

    }

    public void OpenInventoryPanel()
    {
        isInventoryOpen = true;
        menuRoot.SetActive(true);
    }

    public void CloseInventoryPanel()
    {
        isInventoryOpen = false;
        menuRoot.SetActive(false);
    }
}
