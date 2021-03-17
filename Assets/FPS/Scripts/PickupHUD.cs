using UnityEngine;

public class PickupHUD : MonoBehaviour
{

    public GameObject PickupPanel;

    public void OpenPickupPanel()
    {
        PickupPanel.SetActive(true);
    }

    public void ClosePickupPanel()
    {
        PickupPanel.SetActive(false);
    }
}
