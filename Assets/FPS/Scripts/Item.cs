using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is nice
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    // to be overrided
    public virtual void Use()
    {
        // use the item
        // something might happen
        Debug.Log("Using " + name);
    }
}
