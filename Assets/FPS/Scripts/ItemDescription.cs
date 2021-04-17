using UnityEngine;
using TMPro;

public class ItemDescription : MonoBehaviour
{
    public TMP_Text description;

    // Update is called once per frame
    void Update()
    {
        description.text = PickupHUD.itemDescription;
    }

}
