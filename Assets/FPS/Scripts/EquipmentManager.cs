using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Inventory inventory;
    public PlayerCharacterController player;
    private UnityAction m_onUsePotion;

    private void Start()
    {
        inventory = Inventory.instance;
        // get array of all elements in our equipment slot
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;
        // check if we have to swap
        if (currentEquipment[slotIndex] != null)
        {
            // TODO need to implement swap
            oldItem = currentEquipment[slotIndex];
            Debug.Log("drop currently equipped item " + oldItem.name + " on ground");
        } else
        {
            Debug.Log("nothing equipped");
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
        Debug.Log("equipped " + newItem.name + " in slot " + slotIndex.ToString());

    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            // TODO spawn old item onto floor
            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }

            Debug.Log("unequipped this " + currentEquipment[slotIndex]);
        }

    }

    public void UnequipAll()
    {
        for (int i=0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        //// Press U to unequip everything
        //if (Input.GetKeyDown(KeyCode.U))
        //{
        //    UnequipAll();
        //}
        if (Input.GetButtonDown(GameConstants.k_ButtonNamePotion))
        {
            Inventory.UpdatePotions(-1);
            UsePotion();
        }


    }

    // Recovers player health
    public void UsePotion()
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth && playerHealth.canPickup())
        {
            playerHealth.Heal(Potion.healAmount);
        }
    }


}
