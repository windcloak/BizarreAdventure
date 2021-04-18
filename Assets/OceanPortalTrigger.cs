using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanPortalTrigger : MonoBehaviour
{
    public GameFlowManager gameManager;

    public GameObject portalNotification;
    void OnTriggerEnter()
    {
        if (GameFlowManager.isDesertLevelComplete)
        {
            gameManager.toOcean();
        } else
        {
            ShowPortalNotification();
        }
    }

    void OnTriggerExit()
    {
        portalNotification.SetActive(false);
    }
    void ShowPortalNotification()
    {
        portalNotification.SetActive(true);
    }
}
