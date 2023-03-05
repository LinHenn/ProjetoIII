using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class handScript : MonoBehaviour
{
    public static handScript HS;

    public itemInventory itemHand;
    private Image handImage;


    private void Awake()
    {
        HS = this;
    }

    void Start()
    {
        handImage = GetComponent<Image>();
    }


    public void setHand(itemInventory item)
    {
        if(item.Name == itemHand.Name)
        {
            handImage.sprite = null;
            handImage.enabled = false;
            itemHand = new itemInventory();
        }
        else
        {
            handImage.sprite = item.img;
            itemHand = item;
            handImage.enabled = true;
        }
    }

}
