using UnityEngine;
using TMPro;

public class PotionsUI : MonoBehaviour
{
    public TMP_Text potionAmount;

    // Update is called once per frame
    void Update()
    {
        potionAmount.text = Inventory.potions.ToString("0");
    }

}
