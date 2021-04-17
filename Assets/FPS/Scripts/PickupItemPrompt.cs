using UnityEngine;

public class PickupItemPrompt : MonoBehaviour
{
    public PickupHUD pickup;

    public void OnTriggerEnter(Collider other)
    {
        pickup.OpenPickupPanel(other);
    }

    public void OnTriggerExit(Collider other)
    {
        pickup.ClosePickupPanel(other);
    }
}
