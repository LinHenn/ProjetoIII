using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public itemInventory thisItem;

    public Image img;

    
    public void setItem(itemInventory item)
    {
        thisItem = item;

        img.sprite = thisItem.img;
    }

}
