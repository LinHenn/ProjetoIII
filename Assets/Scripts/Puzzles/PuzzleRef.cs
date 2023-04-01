using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRef : MonoBehaviour
{
    public static PuzzleRef PR;

    
    public List<GameObject> puzzlesList;


    private void Awake()
    {
        PR = this;
    }

    /*
    private void Start()
    {
        playPuzzle(0);
    }
    */

    public void playPuzzle(int index)
    {
        PlayerController.PC.setMove(false);
        PlayerController.PC.slowMouse(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        puzzlesList[index].SetActive(true);
        puzzlesList[index].GetComponent<IPuzzle>().letsPlay();
        //Debug.Log(puzzlesList[index]);
    }


    public void closePuzzle(int index)
    {
        PlayerController.PC.setMove(true);
        PlayerController.PC.slowMouse(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        puzzlesList[index].SetActive(false);
        //Debug.Log(puzzlesList[index]);
    }

}
