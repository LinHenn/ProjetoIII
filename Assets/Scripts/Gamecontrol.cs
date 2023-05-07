using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;



[System.Serializable]
public class itemInventory
{
    public string Name;
    public int index;
    public Sprite img;
}

public enum Language
{
    English, 
    Português
}



public class Gamecontrol : MonoBehaviour
{

    public SaveGame SG;

    public GameObject[] players;

    public static Gamecontrol GC;

    public Language Linguagem;
    public static Language setLanguage;

    public bool mayInteract;
    private float timerInteract;

    public List<InventoryItem> itemsInventory;
    public List<itemInventory> Inventory;

    public string TargetItem;

    [SerializeField] private Image hand;


    public bool MissionComplete = false;

    //para Save da Cena 1;
    public Animator DoorAlaB;
    public Animator Door2Floor;
    public UnityEvent setCena1Part1;
    public UnityEvent setCena1Complete;
    public UnityEvent setCena1Subsolo;


    private void Awake()
    {
        GC = this;

        //Remover assim que finalizar o jogo
        setLanguage = Linguagem;
        //

        //Adicionar assim que criar o jogo
        //Linguagem = setLanguage;
        

        Debug.Log(setLanguage.ToString());

        //save system
        SG.startBool();
        if (!SaveGame._secureRoom1 && !SaveGame._secureRoom2) players[0].SetActive(true);
        else if (SaveGame._secureRoom1 && !SaveGame._secureRoom2)
        {
            players[1].SetActive(true);
            Door2Floor.SetTrigger("Open");
            setCena1Part1.Invoke();
        }
        else if (SaveGame._secureRoom2)
        {
            players[2].SetActive(true);
            Door2Floor.SetTrigger("Open");
            setCena1Part1.Invoke();
            setCena1Subsolo.Invoke();
        }

        if(SaveGame._is035Free)
        {
            setCena1Complete.Invoke();
        }

    }



    public void setTarget(string item, bool mayTarget)
    {
        TargetItem = item;
        targetScript.ScriptTarget.setText(item, mayTarget);
        //Debug.Log(mayTarget);
    }



    public void AddInventory(itemInventory item)
    {
        /*
        if (!mayInteract) return;
        timerInteract = 0.5f;
        */
        
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
        //Debug.Log("Removerei " +item.Name);

        Inventory.Remove(item);

        ReorganizeInventory();
        

    }



    public void ReorganizeInventory()
    {
        
        //Debug.Log(Inventory.Count);

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



    void Update()
    {
        if (timerInteract > 0)
        {
            mayInteract = false;
            timerInteract -= Time.deltaTime;
        }
        else mayInteract = true;


        
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


    //Ao interagir com qualquer item, começa a contagem
    public void HaveInteracted()
    {
        timerInteract = 0.5f;
    }


    public void YouDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void CompleteMission()
    {
        MissionComplete = true;
    }


    public void resetSave()
    {
        SG.clearSave();
    }

}
