using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Equipment item; //current item in the slot

    public void AddItem (Equipment newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        Debug.Log("Added item");
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        Debug.Log("Cleared item");
    }

    //public void OnRemoveButton()
    //{
    //    Inventory.instance.Remove(item);
    //    Debug.Log("item removed");
    //}

    public void UseItem()
    {
        // customize for item
        if (item != null)
        {
            item.Use();
        }

    }
}
