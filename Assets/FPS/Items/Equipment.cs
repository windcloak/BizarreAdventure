using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public int armorModifier;
    public int hp;  // potion

    public override void Use()
    {
        base.Use();
        // Equip the item
    }
}

public enum EquipmentSlot {  Armor, Helmet, Potion, Gun }