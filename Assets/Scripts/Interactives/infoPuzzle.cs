using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



[System.Serializable]
public class puzzlesInfo
{
    public bool isComplete;
    public UnityEvent willHappen;
}



public class infoPuzzle : InfoBase
{

    public List<puzzlesInfo> Puzzles;

    
    public override void willInteract()
    {
        if (playerDist > distance) return;

        int index = whatPuzzle();

        if (index == 100) willHappen.Invoke();
        else
        {
            Puzzles[index].willHappen.Invoke();
        }


    }

    int whatPuzzle()
    {
        
        for(int i = 0; i < Puzzles.Count; i++)
        {
            if (!Puzzles[i].isComplete) return i;
        }

        return 100;
    }




    public void setPuzzle(int index)
    {
        Puzzles[index].isComplete = true;
    }
    

}
