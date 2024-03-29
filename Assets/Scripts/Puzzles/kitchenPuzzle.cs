using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenPuzzle : MonoBehaviour
{
    public GameObject[] objects;

    public bool[] inPlate;
    public bool isComplete;

    [SerializeField]
    private infoPuzzle chefKitchen;
    [SerializeField]
    private AudioSource beefSound;


    public void cozinhandoBife()
    {
        objects[0].SetActive(true);
        StartCoroutine(waitCook());
    }

    IEnumerator waitCook()
    {
        yield return new WaitForSeconds(5f);
        objects[0].SetActive(false);
        objects[1].SetActive(true);
        beefSound.Pause();
    }


    public void setInPlate(int index)
    {
        inPlate[index] = true;

        if (inPlate[0] && inPlate[1] && inPlate[2] && inPlate[3])
        {
            isComplete = true;
            chefKitchen.setPuzzle(1);
            GetComponent<addFlashback>().Interaction();
            //chefKitchen.setPuzzle(2);
        }
    }



}
