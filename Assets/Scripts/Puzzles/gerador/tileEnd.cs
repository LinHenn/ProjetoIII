using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tileEnd : tilesGerador
{
    public colorEnergy myColor;

    public int index;

    private Image myImage;

    private bool turnedOn;

    protected override void Start()
    {
        myImage = GetComponent<Image>();
    }

    public override void changeUp()
    {
        base.changeUp();
        if (turnedOn) return;

        foreach (var tile in tileUp.eachSide)
        {
            foreach(var energies in tile.conection)
            {
                if (energies == myColor)
                {
                    turnedOn = true;
                    myImage.enabled = true;
                    ctrlGerador.Instance.setLed(index);
                }
            }
        }

    }

    public override void changeDown()
    {
        base.changeDown();
        if (turnedOn) return;

        foreach (var tile in tileDown.eachSide)
        {
            foreach (var energies in tile.conection)
            {
                if (energies == myColor)
                {
                    turnedOn = true;
                    myImage.enabled = true;
                    ctrlGerador.Instance.setLed(index);
                }
            }
        }
    }

    public override void changeLeft()
    {
        base.changeLeft();
        if (turnedOn) return;

        foreach (var tile in tileLeft.eachSide)
        {
            foreach (var energies in tile.conection)
            {
                if (energies == myColor)
                {
                    turnedOn = true;
                    myImage.enabled = true;
                    ctrlGerador.Instance.setLed(index);
                }
            }
        }
    }

    public override void changeRight()
    {
        base.changeRight();

        if (turnedOn) return;

        foreach (var tile in tileRight.eachSide)
        {
            foreach (var energies in tile.conection)
            {
                if (energies == myColor)
                {
                    turnedOn = true;
                    myImage.enabled = true;
                    ctrlGerador.Instance.setLed(index);
                }
            }
        }
    }




}
