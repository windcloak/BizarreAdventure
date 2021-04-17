using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainPortalTrigger : MonoBehaviour
{
    public GameFlowManager gameManager;
    void OnTriggerEnter()
    {
        gameManager.toPlains();
    }
}
