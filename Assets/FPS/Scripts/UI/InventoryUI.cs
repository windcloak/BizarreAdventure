using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    //public Transform itemsParent;
    //InventorySlot[] slots;
    Inventory inventory;
    public InventorySlot potionSlot;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance; //cache
        inventory.onItemChangedCallback += UpdateUI;

        //slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void UpdateUI()
    {
        // if armor was picked up
        //Debug.Log("Updating UI in the good script");
        //for(int i = 0; i < slots.Length; i++)
        //{
        //    if (i < inventory.items.Count)
        //    {
        //        slots[i].AddItem(inventory.items[i]);
        //    }
        //    else
        //    {
        //        slots[i].ClearSlot();
        //    }
        //}
    }

}
