using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderScript : MonoBehaviour
{

    public static FolderScript FS;

    [SerializeField] private GameObject itemImage;


    private void Awake()
    {
        FS = this;
    }


    private void Start()
    {
        itemImage.SetActive(false);        
    }



    public void setFolder(Sprite image)
    {

        PlayerController.PC.setMove(false);

        itemImage.SetActive(true);

        itemImage.GetComponent<Image>().sprite = image;




        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerController.PC.slowMouse(true);

        Time.timeScale = 0;
    }


    public void closeFolder()
    {
        PlayerController.PC.setMove(true);


        itemImage.SetActive(false);


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerController.PC.slowMouse(false);

        Time.timeScale = 1;
    }


}
