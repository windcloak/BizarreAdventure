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

    float m_healAmount;

    private void Start()
    {
        inventory = Inventory.instance;
        // get array of all elements in our equipment slot
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem, float armorModifier, float helmetModifier)
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
            Debug.Log("equipped " + newItem.name);
        }
     
        switch (slotIndex)
        {
            case 0:
                UseShield(armorModifier);
                break;
            case 1:
                UseHelmet(helmetModifier);
                break;
            case 2:
                // Can't pass potionModifier in here because we don't use it immediately
                break;
            default:
                Debug.Log("wrong slot index");
                break;
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
        if (Input.GetButtonDown(GameConstants.k_ButtonNamePotion) && Inventory.potions > 0)
        {
            UsePotion();
        }


    }

    // Recovers player health
    void UsePotion()
    {
        if (Inventory.potions <= 0)
        {
            Debug.Log("you don't have any potions!");
            return;
        }
        Health playerHealth = player.GetComponent<Health>();

        if (playerHealth && playerHealth.canPickup())
        {
            playerHealth.Heal(Potion.healAmount);   // from Potion script
        }
        Inventory.UpdatePotions(-1);
        if (Inventory.potions == 0)
        {
            inventory.Remove(currentEquipment[2]);
        }
        Debug.Log("used potion");

    }

    // Increases player max HP
    void UseShield(float healthFactor)
    {
        Health playerHealth = player.GetComponent<Health>();
        playerHealth.IncreaseHealth(healthFactor);
        Debug.Log("max health is " + playerHealth.maxHealth);
    }

    // Decreases damage taken
    void UseHelmet(float helmetModifier)
    {
        Debug.Log("used helmet");
        Damageable playerDamage = player.GetComponent<Damageable>();
        playerDamage.DecreaseDamage(helmetModifier);
        Debug.Log("damageable " + playerDamage.damageMultiplier);

    }
}
