using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is nice
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : MonoBehaviour
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
