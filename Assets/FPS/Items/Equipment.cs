using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public int armorModifier;
    public int helmetModifier;
    public int potionModifier;
    public EquipmentSlot equipSlot;
    public override void Use()
    {
        base.Use();
        // Equip the item
        EquipmentManager.instance.Equip(this);
    }
}

public enum EquipmentSlot {  Armor, Helmet, Potion }