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
    public bool Hardcore;
    public static bool setHardcore;

    [HideInInspector]
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
    public UnityEvent setSubsoloComplete;
    public UnityEvent isAtHome;

    [HideInInspector]
    public bool isDead = false;

    //para quando for visto por um inimigo
    private bool isSeen = false;
    [HideInInspector]
    public bool iSeeYou = false;
    [SerializeField]
    private GameObject isSeenPanel;

    //pause
    [Header("Menu de pausa")]
    public bool isPause;
    [SerializeField]
    private GameObject MenuScreen;

    private bool playerMayMove;
    private CursorLockMode mouseMode;
    private bool cursorVisible;
    //PlayerController.PC.setMove(true);
    //Cursor.lockState = CursorLockMode.Locked;
    //Cursor.visible = false;

    //

    private void Awake()
    {
        GC = this;

        //Remover assim que finalizar o jogo
        setLanguage = Linguagem;
        //

        //Adicionar assim que criar o jogo
        //Linguagem = setLanguage;
        

        Debug.Log(setLanguage.ToString());

        //remover assim que estiver ajustado no menu inicial
        setHardcore = Hardcore;
        Debug.Log("Hardcore: " +setHardcore);
        //

        startPlayer();

    }


    void startPlayer()
    {
        //save system
        SG.startBool();

        if (SaveGame._homeSweetHome)
        {
            players[3].SetActive(true);
            isAtHome.Invoke();
        }
        else
        {
            if (!SaveGame._secureRoom1 && !SaveGame._secureRoom2)
            {
                players[0].SetActive(true);
                return;
            }

            if (SaveGame._secureRoom1)
            {
                players[1].SetActive(true);
                Door2Floor.SetTrigger("Open");
                setCena1Part1.Invoke();
            }

            if (SaveGame._secureRoom2)
            {
                players[2].SetActive(true);
                Door2Floor.SetTrigger("Open");
                setCena1Part1.Invoke();
                setCena1Subsolo.Invoke();
            }


            if (SaveGame._is035Free)
            {
                setCena1Complete.Invoke();
            }

            if (SaveGame._timeComplete)
            {
                Debug.Log("TempoCompleto");
                SG.timeComplete = true;
                setSubsoloComplete.Invoke();
            }
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
                break;
            }
            //Debug.Log("Nao cabe mais");
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

        while(i < Inventory.Count && i < 5)
        {
            //Debug.Log(i);

            //Debug.Log(Inventory[i].Name);
            
            if(Inventory[i].Name != itemsInventory[i].thisItem.Name)
            {
                itemsInventory[i].setItem(Inventory[i]);
            }
            
            i++;
        }

        if(i < 5) itemsInventory[i].gameObject.SetActive(false);
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
            if (!itemsInventory[0].gameObject.activeSelf) return;
            handScript.HS.setHand(Inventory[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!itemsInventory[1].gameObject.activeSelf) return;
            handScript.HS.setHand(Inventory[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!itemsInventory[2].gameObject.activeSelf) return;
            handScript.HS.setHand(Inventory[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (!itemsInventory[3].gameObject.activeSelf) return;
            handScript.HS.setHand(Inventory[3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (!itemsInventory[4].gameObject.activeSelf) return;
            handScript.HS.setHand(Inventory[4]);
        }


        //if (Input.GetKeyDown(KeyCode.F)) Debug.Log(SG.timeComplete);
        if (Input.GetKeyDown(KeyCode.Escape)) PauseButton(!isPause);

    }

    //menu de pause
    public void PauseButton(bool value)
    {
        isPause = value;

        if(isPause)
        {
            Time.timeScale = 0;
            MenuScreen.SetActive(true);

            playerMayMove = PlayerController.PC.mayMove;
            mouseMode = Cursor.lockState;
            cursorVisible = Cursor.visible;

            PlayerController.PC.setMove(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            
}
        else
        {
            Time.timeScale = 1;
            MenuScreen.SetActive(false);

            PlayerController.PC.setMove(playerMayMove);
            Cursor.lockState = mouseMode;
            Cursor.visible = cursorVisible;
        }
    }

    //






    //Ao interagir com qualquer item, começa a contagem
    public void HaveInteracted()
    {
        timerInteract = 0.5f;
    }


    public void haveSeen()
    {
        isSeen = true;

        if (!iSeeYou)
        {
            Debug.Log("Avistado");
            Time.timeScale = 0.5f;
            StartCoroutine(timerSeen());
        }
    }

    private IEnumerator timerSeen()
    {
        //Debug.Log(Time.timeScale);

        iSeeYou = true;
        isSeenPanel.SetActive(true);

        yield return new WaitForSeconds(1);
        if (Time.timeScale == 0.5f) Time.timeScale = 1f;
        isSeen = false;

        yield return new WaitForSeconds(1);
        iSeeYou = false;
        Debug.Log("voltei");
        if (!isSeen) isSeenPanel.SetActive(false);
        else StartCoroutine(timerSeen());
    }


    //quando o jogador morrer
    public void YouDied()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("morri");
        //PlayerController.PC.gameObject.SetActive(false);
        flashback.instance.playMemory();

    }


    //apenas para resetar a fase;
    public void restartDie()
    {
        StartCoroutine(dieRestart());
    }
    IEnumerator dieRestart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void CompleteMission()
    {
        MissionComplete = true;
        SG.timeComplete = true;
    }

    public void LetGoHome()
    {
        SG.homeSweetHome = true;
        SG.saveBool();
        YouDied();
    }


    public void resetSave()
    {
        //SG.clearSave();
    }


}
