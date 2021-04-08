using UnityEngine;

public class EquipmentPickup : ItemPickup
{
    public Equipment equipment;
    public override void PickUp()
    {
        Debug.Log("Attempting to pick up and equip " + equipment.name);
        bool wasPickedUp = Inventory.instance.Add(equipment);
        if (wasPickedUp)
        {
            // if it's a armor or helmet (index 0 or 1), equip it

            int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
            int slotIndex = (int)equipment.equipSlot;

            // if you already have armor
            if (slotIndex == 0 && Inventory.hasArmor)
            {
                EquipmentManager.instance.Unequip(0);
                equipment.Use();
            } else if (slotIndex == 1 && Inventory.hasHelmet)
            {
                EquipmentManager.instance.Unequip(1);
                equipment.Use();
            }

            if (slotIndex < 2)
            {
                equipment.Use();
            }

            Destroy(gameObject);
            return;
        }
        Debug.Log("Inventory full!");
    }
}
