using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public float armorModifier;
    public float helmetModifier;
    public float potionModifier;
    public EquipmentSlot equipSlot;
    public override void Use()
    {
        base.Use();
        // Equip the item
        EquipmentManager.instance.Equip(this, armorModifier, helmetModifier);
    }


}

public enum EquipmentSlot {  Armor, Helmet, Potion }