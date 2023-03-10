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
        itemImage.SetActive(false);

    }



    public void setFolder(Sprite image)
    {

        PlayerController.PC.setMove(false);


        itemImage.GetComponent<Image>().sprite = image;
        itemImage.SetActive(true);




        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void closeFolder()
    {
        PlayerController.PC.setMove(true);


        itemImage.SetActive(false);


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


}
