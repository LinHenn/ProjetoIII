using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum colorEnergy { clear, blue, red, yellow, green};
public enum sides { up, right, down, left};



[System.Serializable]
public class Connect
{
    public sides direction;
    public List<colorEnergy> conection;
}

public class tilesGerador : MonoBehaviour
{
    public int rotateStart;

    public tilesGerador tileUp;
    public tilesGerador tileDown;
    public tilesGerador tileLeft;
    public tilesGerador tileRight;

    private int rotate;

    public Connect[] eachSide;


    protected virtual void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotateStart * -90);
        rotate = rotateStart;

        ctrlGerador.Instance.OnClearEnter += setClear;
    }


    protected void setClear()
    {
        foreach (var thiside in eachSide) { thiside.conection.Clear(); }
    }



    public void OnCicked()
    {
        rotate++;
        if (rotate >= 4) rotate = 0;
        transform.rotation = Quaternion.Euler(0, 0, rotate * -90);

        letsRotate();
    }

    
    protected void letsRotate()
    {        
        
        for (int i = 0; i < eachSide.Length; i++)
        {
            switch (eachSide[i].direction)
            {
                case sides.up:
                    eachSide[i].direction = sides.right;
                    break;
                case sides.right:
                    eachSide[i].direction = sides.down;
                    break;
                case sides.down:
                    eachSide[i].direction = sides.left;
                    break;
                case sides.left:
                    eachSide[i].direction = sides.up;
                    break;
            }
        }
        //CheckEnergy();
    }
    
    public virtual void CheckEnergy(colorEnergy energy)
    {        

    }


    public virtual void changeUp()
    {

        for (int x = 0; x < eachSide.Length; x++)
        {
            foreach (var con in eachSide[x].conection)
            {
                foreach (var tileup in tileUp.eachSide)
                {
                    foreach(var tile in tileup.conection)
                    if (con == tile)
                    {
                        Debug.Log("parei " + gameObject.name + " " + tile);
                        return;
                    }
                }
            }
        }


    }

    public virtual void changeDown()
    {

        for (int x = 0; x < eachSide.Length; x++)
        {
            foreach (var con in eachSide[x].conection)
            {
                foreach (var tileup in tileDown.eachSide)
                {
                    foreach (var tile in tileup.conection)
                        if (con == tile)
                        {
                            Debug.Log("parei " + gameObject.name +" " +tile);
                            return;
                        }
                }
            }
        }
        //Debug.Log("Alterei em baixo");
        //for (int i = 0; i < eachSide.Length; i++)
        {
            //if (eachSide[i].direction == sides.down) Debug.Log("Alterei em baixo " + gameObject.name);
        }
    }

    public virtual void changeLeft()
    {

        for (int x = 0; x < eachSide.Length; x++)
        {
            foreach (var con in eachSide[x].conection)
            {
                foreach (var tileup in tileLeft.eachSide)
                {
                    foreach (var tile in tileup.conection)
                        if (con == tile)
                        {
                            Debug.Log("parei " + gameObject.name + " " + tile); return;
                        }
                }
            }
        }
        //Debug.Log("Alterei na esquerda");
        //for (int i = 0; i < eachSide.Length; i++)
        {
            //if (eachSide[i].direction == sides.left) Debug.Log("Alterei na esquerda " + gameObject.name);
        }
    }

    public virtual void changeRight()
    {

        for (int x = 0; x < eachSide.Length; x++)
        {
            foreach (var con in eachSide[x].conection)
            {
                foreach (var tileup in tileRight.eachSide)
                {
                    foreach (var tile in tileup.conection)
                        if (con == tile)
                        {
                            Debug.Log("parei " + gameObject.name + " " + tile); return;
                        }
                }
            }
        }
        //Debug.Log("Alterei na direita");
        //for (int i = 0; i < eachSide.Length; i++)
        {
            //if (eachSide[i].direction == sides.right) Debug.Log("Alterei na direita " + gameObject.name);
        }
    }


    protected void setDir(int index)
    {
        //agora verifica para outro
        if (eachSide[index].direction == sides.right && tileRight != null) { tileRight.changeLeft(); }
        if (eachSide[index].direction == sides.up && tileUp != null) tileUp.changeDown();
        if (eachSide[index].direction == sides.left && tileLeft != null) tileLeft.changeRight();
        if (eachSide[index].direction == sides.down && tileDown != null) tileDown.changeUp();
    }

}
