using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanPortalTrigger : MonoBehaviour
{
    public GameFlowManager gameManager;
    void OnTriggerEnter()
    {
        gameManager.toOcean();
    }
}
