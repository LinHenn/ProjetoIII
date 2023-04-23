using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class mixerPuzzle : MonoBehaviour, IInteractible
{

    [SerializeField] List<SpriteRenderer> elements;
    [SerializeField] List<itemInventory> items;

    public UnityEvent Explosion;



    public void Interaction()
    {
        var item = handScript.HS.itemHand;
        if (item.Name == "") return;


        //Debug.Log(item.index);

        Gamecontrol.GC.RemoveInventory(handScript.HS.itemHand);
        handScript.HS.setHand(handScript.HS.itemHand);
        items.Add(item);

        var element = setElement();
        element.sprite = item.img;
        element.enabled = true;

        if (items.Count == 3)
        {
            var mixed1 = compare1();
            if(!mixed1) compare2();

            cleanMixer();
        }
    }


    SpriteRenderer setElement()
    {
        foreach(var element in elements)
        {
            if (element.enabled == false) return element;
        }

        return null;

    }



    bool compare1()
    {
        bool O = false, C = false, H = false;
        foreach(var item in items)
        {
            if (!O && item.index == 20) O = true;
            if (!C && item.index == 21) C = true;
            if (!H && item.index == 22) H = true;
        }

        if (H && C && O)
        {
            Debug.Log("Consegui Acido");
            //
            GetComponent<AddInventory>().Interaction();
            //cleanMixer();
            return true;
        }
        return false;

    }


    void compare2()
    {
        bool H2SO4 = false, HNO3 = false, C3H8O3 = false;
        foreach (var item in items)
        {
            if (!H2SO4 && item.index == 23) H2SO4 = true;
            if (!HNO3 && item.index == 24) HNO3 = true;
            if (!C3H8O3 && item.index == 25) C3H8O3 = true;
        }

        if (H2SO4 && HNO3 && C3H8O3)
        {
            Debug.Log("Consegui Explodir");
            Explosion.Invoke();
        }
    }





    public void cleanMixer()
    {

        items.Clear();

        foreach(var element in elements)
        {
            element.enabled = false;
        }

    }





}
