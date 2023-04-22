using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GC_Prisioneiro : MonoBehaviour
{
    
    [SerializeField]
    private bool isFree;

    [SerializeField]
    private bool[] setMove;
    

    [SerializeField]    
    private GameObject[] prisioners035;

    

    
    public void freeIs()
    {
        isFree = true;

        setPos();

    }

    public void moveSet0()
    {
        setMove[0] = true;

        if (isFree) setPos();
    }

    public void moveSet1()
    {
        setMove[1] = true;

       if (isFree) setPos();
    }

    public void moveSet2()
    {
        setMove[2] = true;

       if (isFree) setPos();
    }

    public void moveSet3()
    {
        setMove[3] = true;

        if (isFree) setPos();
    }




    private void setPos()
    {
        if (setMove[0] && !setMove[1] && !setMove[2])
        {
            prisioners035[0].SetActive(false);
            prisioners035[1].SetActive(true);
        }

        if(setMove[1] && !setMove[2])
        {
            prisioners035[0].SetActive(false);
            prisioners035[1].SetActive(false);
            prisioners035[2].SetActive(true);
        }

        if(setMove[2] && !setMove[3])
        {
            prisioners035[0].SetActive(false);
            prisioners035[1].SetActive(false);
            prisioners035[2].SetActive(false);
            prisioners035[3].SetActive(true);
        }

        if(setMove[3])
        {
            prisioners035[3].SetActive(false);
            prisioners035[4].SetActive(true);
        }
    }
    
    
}
