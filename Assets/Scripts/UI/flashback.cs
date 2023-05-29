using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashback : MonoBehaviour
{
    public static flashback instance;

    public List<Sprite> photos;
    [SerializeField]
    private GameObject voidScreen;
    [SerializeField]
    private GameObject[] screens;

    private bool isRestarting = false;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //playMemory();
    }

    public void addPhoto(Sprite img)
    {
        photos.Add(img);
    }



    public void playMemory()
    {
        voidScreen.SetActive(true);
        nextScreen();
    }

    public void nextScreen()
    {
        if (isRestarting) return;

        if (photos.Count <= 0) 
        { 
            Gamecontrol.GC.restartDie(); 
            isRestarting = true; 
            return; 
        }

        var screen = choiceScreen();

        screen.SetActive(true);
        screen.GetComponent<Image>().sprite = photos[photos.Count - 1];
        screen.GetComponent<Animator>().SetTrigger("play");

        photos.Remove(photos[photos.Count - 1]);
    }


    private GameObject choiceScreen()
    {
        foreach(var screen in screens)
        {
            if (!screen.activeSelf) return screen;
        }
        return null;
    }


}
