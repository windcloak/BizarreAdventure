using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance; 
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    private void Start()
    {
        // get array of all elements in our equipment slot
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        currentEquipment[slotIndex] = newItem;
        Debug.Log("equipped " + newItem.name);
    }
}
