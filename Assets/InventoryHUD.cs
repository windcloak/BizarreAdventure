using UnityEngine;

public class InventoryHUD : MonoBehaviour
{
    public GameObject inventoryPanel;
    public static bool isInventoryOpen = false;
    public GameObject menuRoot;
    PlayerInputHandler m_PlayerInputsHandler;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
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
    }


    public void OpenInventoryPanel()
    {
        isInventoryOpen = true;
        inventoryPanel.SetActive(true);

        if (!menuRoot.activeSelf && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // disable in-game mouse movement
        Cursor.lockState = CursorLockMode.None;
    
        Cursor.visible = true;
        // TODO need to disable clicking/shooting in-game
        Time.timeScale = 0f;


    }

    public void CloseInventoryPanel()
    {
        isInventoryOpen = false;
        inventoryPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
