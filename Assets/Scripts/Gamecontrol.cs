using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class itemInventory
{
    public string Name;
    public int index;
    public Sprite img;
}



public class Gamecontrol : MonoBehaviour
{
    public static Gamecontrol GC;

    public List<InventoryItem> itemsInventory;
    public List<itemInventory> Inventory;

    public string TargetItem;

    [SerializeField] private Image hand;


    private void Awake()
    {
        GC = this;
    }


    public void setTarget(string item)
    {
        TargetItem = item;
        targetScript.ScriptTarget.setText(item);
    }



    public void AddInventory(itemInventory item)
    {
        
        Inventory.Add(item);

        foreach(var index in itemsInventory)
        {
            if(!index.gameObject.activeSelf)
            {
                index.setItem(item);
                index.gameObject.SetActive(true);
                return;
            }
        }
    }

    public void RemoveInventory(itemInventory item)
    {
        Debug.Log("Removerei " +item.Name);

        Inventory.Remove(item);

        ReorganizeInventory();
        

    }



    public void ReorganizeInventory()
    {
        
        Debug.Log(Inventory.Count);

        int i = 0;

        while(i < Inventory.Count)
        {
            Debug.Log(Inventory[i].Name);
            
            if(Inventory[i].Name != itemsInventory[i].thisItem.Name)
            {
                itemsInventory[i].setItem(Inventory[i]);
            }
            
            i++;
        }

        itemsInventory[i].gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handScript.HS.setHand(Inventory[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handScript.HS.setHand(Inventory[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handScript.HS.setHand(Inventory[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            handScript.HS.setHand(Inventory[3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            handScript.HS.setHand(Inventory[4]);
        }


    }
}
