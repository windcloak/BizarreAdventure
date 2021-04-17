using UnityEngine;
using TMPro;

public class PickupHUD : MonoBehaviour
{
    public GameObject PickupPanel;
    public static string itemDescription;

    public void OpenPickupPanel(Collider other)
    {
        PickupPanel.SetActive(true);
        itemDescription = other.name;

        switch (other.tag)
        {
            case "Basic Helmet":
                itemDescription = other.tag + " increases damage resist by 20%";
                break;
            case "Good Helmet":
                itemDescription = other.tag + " increases damage resist by 35%";
                break;
            case "Super Helmet":
                itemDescription = other.tag + " increases damage resist by 50%";
                break;
            case "Mega Helmet":
                itemDescription = other.tag + " increases damage resist by 65%";
                break;
            default:
                itemDescription = "This is a mysterious item";
                break;
        }
    }

    public void ClosePickupPanel(Collider other)
    {
        PickupPanel.SetActive(false);
    }
}
