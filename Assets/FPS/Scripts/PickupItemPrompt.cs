﻿using UnityEngine;

public class PickupItemPrompt : MonoBehaviour
{
    public PickupHUD pickup;

    public void OnTriggerEnter(Collider other)
    {
        // Todo: check if item is an inventory item
        pickup.OpenPickupPanel();
    }

    public void OnTriggerExit(Collider other)
    {
        pickup.ClosePickupPanel();
    }
}