using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Le Singletón
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found");
            return;
        }
        instance = this;
        Debug.Log("Inventory intance created.");
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Equipment> items = new List<Equipment>();
    public int inventorySpace = 20; // includes 1 armor + 1 helmet + rest potions

    public InventorySlot armorSlot, helmetSlot, potionSlot;
    Inventory inventory;

    public static bool hasArmor = false;
    public static bool hasHelmet = false;
    public static int potions = 0;

    private void Start()
    {
        inventory = Inventory.instance; //cache
    }

    public bool Add(Equipment item)
    {
        if (items.Count >= inventorySpace)
        {
            Debug.Log("Inventory full");
            return false; //did not pick up item
        }

        // if it's a armor or helmet (index 0 or 1), equip it

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        int slotIndex = (int)item.equipSlot;


        // Updating UI
        if (slotIndex == 0) // Armor
        {

            UpdateArmor();
            UpdateArmorSlot(item);

        }
        else if (slotIndex == 1)    // Helmet
        {
            UpdateHelmet();
            UpdateHelmetSlot(item);
        }
        else if (slotIndex == 2)    // Potion
        {
            UpdatePotions(1);
            UpdatePotionSlot(item);
        }

        // TODO implement a use for potion
        // puts it into "equipped"
        if (slotIndex < 2)
        {
            item.Use();
        }

        items.Add(item);
        Debug.Log("Picked up " + item.name);
        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
        return true; //picked up item
    }

    public void Remove(Equipment item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
    }

    void UpdateArmor()
    {
        hasArmor = !hasArmor;
    }
    void UpdateHelmet()
    {
        hasHelmet = !hasHelmet;
    }
    public static void UpdatePotions(int n)
    {
        if (potions + n > 0)
        {
            potions += n;
        }
        else
        {
            potions = 0;
        }
    }

    // if potions = 0, update that in UI
    void ClearPotionSlot()
    {
        if (potions > 0)
            return;

        potionSlot.ClearSlot();
    }

    void UpdateArmorSlot(Equipment item)
    {
        armorSlot.AddItem(item);
    }
    void UpdateHelmetSlot(Equipment item)
    {
        helmetSlot.AddItem(item);
    }
    void UpdatePotionSlot(Equipment item)
    {
        potionSlot.AddItem(item);
    }
}
