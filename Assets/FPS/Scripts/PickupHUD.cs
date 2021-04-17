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
            case "Plain Helmet":
                itemDescription = other.tag + " gives you a 20% decrease in damage";
                break;
            //case 1:
            //    UseHelmet(helmetModifier);
            //    break;
            //case 2:
            //    // Can't pass potionModifier in here because we don't use it immediately
            //    break;
            default:
                Debug.Log("wrong slot index");
                break;
        }
    }

    public void ClosePickupPanel(Collider other)
    {
        PickupPanel.SetActive(false);
    }
}
