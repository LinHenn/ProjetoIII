using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileStart : tilesGerador
{
    protected override void Start()
    {
        
    }

    public void PlayPause()
    {
        CheckEnergy(eachSide[0].conection[0]);
    }

    public override void CheckEnergy(colorEnergy energy)
    {

        //tileDown.changeUp();
        tileDown.CheckEnergy(energy);

    }


}
