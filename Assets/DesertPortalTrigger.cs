using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertPortalTrigger : MonoBehaviour
{
    public GameFlowManager gameManager;
    void OnTriggerEnter()
    {
        gameManager.toDesert();
    }
}
