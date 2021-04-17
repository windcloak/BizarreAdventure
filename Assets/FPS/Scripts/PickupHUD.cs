﻿using UnityEngine;

public class PickupHUD : MonoBehaviour
{
    public GameObject PickupPanel;
    public static string itemDescription;

    string m_helmetDesc = " increases damage resistance by ";
    string m_shieldDesc = " increases max health by ";

    public void OpenPickupPanel(Collider other)
    {
        PickupPanel.SetActive(true);

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
