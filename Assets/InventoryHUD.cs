using UnityEngine;

public class InventoryHUD : MonoBehaviour
{
    public GameObject inventoryPanel;
    public static bool isInventoryOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // open panel if it's not already open
            if (!isInventoryOpen)   
            {
                OpenInventoryPanel();
                isInventoryOpen = true;
            }
            else
            {
                CloseInventoryPanel();
                isInventoryOpen = false;
            }
        }
    }


    public void OpenInventoryPanel()
    {
        inventoryPanel.SetActive(true);
    }

    public void CloseInventoryPanel()
    {
        inventoryPanel.SetActive(false);
    }
}
