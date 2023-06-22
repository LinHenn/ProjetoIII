using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class bedScript : MonoBehaviour, IInteractible
{

    [SerializeField] GC_Cirurgy CirurgyGC;

    public UnityEvent itHappens;

    [SerializeField]
    private GameObject cameraCapsule;
    private GameObject playerChar;

    [SerializeField]
    private Animator doorAnim;

    //[SerializeField]
    public GameObject endChat;

    public void Interaction()
    {
        if (Gamecontrol.GC.MissionComplete) return;

        if (CirurgyGC.energyDone && CirurgyGC.puzzleDone)
        {
            Gamecontrol.GC.CompleteMission();
            itHappens.Invoke();
            Debug.Log("Dormi");

            playerChar = PlayerController.PC.gameObject;
            StartCoroutine(setWait());
        }
        else Debug.Log("Nao Dormi");
    }

    private IEnumerator setWait()
    {
        cameraCapsule.SetActive(true);
        playerChar.SetActive(false);
        doorAnim.SetTrigger("Close");
        doorAnim.gameObject.GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(4);

        doorAnim.SetTrigger("Open");
        doorAnim.gameObject.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(2);
        playerChar.SetActive(true);
        cameraCapsule.SetActive(false);
        endChat.GetComponent<IInteractible>().Interaction();
    }


}
