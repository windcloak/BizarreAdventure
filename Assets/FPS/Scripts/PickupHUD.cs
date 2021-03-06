using UnityEngine;
using System.Linq;

public class PickupHUD : MonoBehaviour
{
    public GameObject PickupPanel;
    public static string itemDescription;

    string m_helmetDesc = " increases damage resistance by ";
    string m_shieldDesc = " increases max health by ";
    string m_potionDesc = " increases health by ";
    string m_gunDesc = "This is a ";

    // all the things that can be picked up
    string[] m_pickups = {
        "Basic Helmet",
        "Good Helmet",
        "Super Helmet",
        "Mega Helmet",
        "Basic Shield",
        "Good Shield",
        "Super Shield",
        "Mega Shield",
        "Potion",
        "Salmon Rifle",
        "Blue Pistol",
        "Cactus Gun",
        "Ocean Shotgun",
        "Sword Gun",
    };
    public void OpenPickupPanel(Collider other)
    {
        if (m_pickups.Contains(other.tag))
            PickupPanel.SetActive(true);
        else
            return;

        switch (other.tag)
        {
            case "Basic Helmet":
                itemDescription = other.tag + m_helmetDesc + "20%";
                break;
            case "Good Helmet":
                itemDescription = other.tag + m_helmetDesc + "35%";
                break;
            case "Super Helmet":
                itemDescription = other.tag + m_helmetDesc + "50%";
                break;
            case "Mega Helmet":
                itemDescription = other.tag + m_helmetDesc + "65%";
                break;
            case "Basic Shield":
                itemDescription = other.tag + m_shieldDesc + "25 hp";
                break;
            case "Good Shield":
                itemDescription = other.tag + m_shieldDesc + "50 hp";
                break;
            case "Super Shield":
                itemDescription = other.tag + m_shieldDesc + "75 hp";
                break;
            case "Mega Shield":
                itemDescription = other.tag + m_shieldDesc + "100 hp";
                break;
            case "Potion":
                itemDescription = other.tag + m_potionDesc + "40 hp";
                break;
            case "Salmon Rifle":
                itemDescription = m_gunDesc + other.tag;
                break;
            case "Blue Pistol":
                itemDescription = m_gunDesc + other.tag;
                break;
            case "Cactus Gun":
                itemDescription = m_gunDesc + other.tag;
                break;
            case "Ocean Shotgun":
                itemDescription = m_gunDesc + other.tag;
                break;
            case "Sword Gun":
                itemDescription = m_gunDesc + other.tag;
                break;
            default:
                itemDescription = "This is a mysterious item";
                break;
        }
    }

    public void ClosePickupPanel()
    {
        PickupPanel.SetActive(false);
    }
}
