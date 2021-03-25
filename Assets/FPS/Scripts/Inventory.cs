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

    public List<Item> items = new List<Item>();
    public int inventorySpace = 15;

    public bool Add (Item item)
    {
        if(items.Count >= inventorySpace)
        {
            Debug.Log("Inventory full");
            return false; //did not pick up item
        }
        items.Add(item);
        Debug.Log("Picked up " + item.name);
        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
        return true; //picked up item
    }

    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
    }
}
