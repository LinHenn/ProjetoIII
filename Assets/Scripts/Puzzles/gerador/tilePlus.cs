using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilePlus : tilesGerador
{
    //eachSide: 0 e 2 conectados
    //          1 e 3 conectados


    public override void CheckEnergy(colorEnergy energy)
    {
        //eachSide[0].conection.Clear();
        //eachSide[1].conection.Clear();
        //eachSide[2].conection.Clear();
        //eachSide[3].conection.Clear();

        
        for (int x = 0; x < eachSide.Length; x++)
        {
            foreach (var con in eachSide[x].conection)
            {
                if (con == energy)
                {
                    Debug.Log("parei");
                    return;
                }
            }
        }



        for (int i = 0; i < eachSide.Length; i++)
        {
            switch (eachSide[i].direction)
            {
                case sides.up:
                    if (tileUp == null) break;
                    foreach (var tile in tileUp.eachSide)
                    {
                        if (tile.direction == sides.down)
                        {
                            foreach (var con in tile.conection)
                            {
                                if (i == 0) eachSide[2].conection.Add(con);
                                if (i == 1) eachSide[3].conection.Add(con);
                                if (i == 2) eachSide[0].conection.Add(con);
                                if (i == 3) eachSide[1].conection.Add(con);
                            }
                            if (tileDown != null) tileDown.changeUp();
                            if(tileUp != null) tileUp.changeDown();
                            if (tileLeft != null) tileLeft.changeRight();
                            if (tileRight != null) tileRight.changeLeft();
                        }
                    }
                    break;


                case sides.right:
                    if (tileRight == null) break;
                    foreach (var tile in tileRight.eachSide)
                    {
                        if (tile.direction == sides.left)
                        {
                            foreach (var con in tile.conection)
                            {
                                if (i == 0) eachSide[2].conection.Add(con);
                                if (i == 1) eachSide[3].conection.Add(con);
                                if (i == 2) eachSide[0].conection.Add(con);
                                if (i == 3) eachSide[1].conection.Add(con);
                            }
                            if (tileDown != null) tileDown.changeUp();
                            if(tileUp != null) tileUp.changeDown();
                            if (tileLeft != null) tileLeft.changeRight();
                            if (tileRight != null) tileRight.changeLeft();
                        }
                    }
                    break;


                case sides.down:
                    if (tileDown == null) break;
                    foreach (var tile in tileDown.eachSide)
                    {
                        if (tile.direction == sides.up)
                        {
                            foreach (var con in tile.conection)
                            {
                                if (i == 0) eachSide[2].conection.Add(con);
                                if (i == 1) eachSide[3].conection.Add(con);
                                if (i == 2) eachSide[0].conection.Add(con);
                                if (i == 3) eachSide[1].conection.Add(con);
                            }
                            if (tileDown != null) tileDown.changeUp();
                            if(tileUp != null) tileUp.changeDown();
                            if (tileLeft != null) tileLeft.changeRight();
                            if (tileRight != null) tileRight.changeLeft();
                        }
                    }
                    break;


                case sides.left:
                    if (tileLeft == null) break;
                    foreach (var tile in tileLeft.eachSide)
                    {
                        if (tile.direction == sides.right)
                        {
                            foreach (var con in tile.conection)
                            {
                                if (i == 0) eachSide[2].conection.Add(con);
                                if (i == 1) eachSide[3].conection.Add(con);
                                if (i == 2) eachSide[0].conection.Add(con);
                                if (i == 3) eachSide[1].conection.Add(con);
                            }
                            if (tileDown != null) tileDown.changeUp();
                            if (tileUp != null) tileUp.changeDown();
                            if (tileLeft != null) tileLeft.changeRight();
                            if (tileRight != null) tileRight.changeLeft();
                        }
                    }
                    break;
            }
        }
    }




    public override void changeUp()
    {
        base.changeUp();

        for (int i = 0; i < eachSide.Length; i++)
        {
            if (eachSide[i].direction == sides.up)
            {
                if (i == 0) 
                    eachSide[2].conection.Clear();
                if (i == 1) 
                    eachSide[3].conection.Clear();
                if (i == 2) 
                    eachSide[0].conection.Clear();
                if (i == 3) 
                    eachSide[1].conection.Clear();
                
                foreach (var tile in tileUp.eachSide)
                {
                    if (tile.direction == sides.down)
                    {
                        foreach (var con in tile.conection)
                        {
                            if (i == 0) { eachSide[2].conection.Add(con); setDir(2); }
                            if (i == 1) { eachSide[3].conection.Add(con); setDir(3); }
                            if (i == 2) { eachSide[0].conection.Add(con); setDir(0); }
                            if (i == 3) { eachSide[1].conection.Add(con); setDir(1); }
                        }
                    }
                }
            }
        }
    }


    public override void changeDown()
    {
        base.changeDown();

        for (int i = 0; i < eachSide.Length; i++)
        {
            if (eachSide[i].direction == sides.down)
            {
                
                if (i == 0) eachSide[2].conection.Clear();
                if (i == 1) eachSide[3].conection.Clear();
                if (i == 2) eachSide[0].conection.Clear();
                if (i == 3) eachSide[1].conection.Clear();
                
                foreach (var tile in tileDown.eachSide)
                {
                    if (tile.direction == sides.up)
                    {
                        foreach (var con in tile.conection)
                        {
                            if (i == 0) { eachSide[2].conection.Add(con); setDir(2); }
                            if (i == 1) { eachSide[3].conection.Add(con); setDir(3); }
                            if (i == 2) { eachSide[0].conection.Add(con); setDir(0); }
                            if (i == 3) { eachSide[1].conection.Add(con); setDir(1); }
                        }
                    }
                }
            }
        }
    }


    public override void changeLeft()
    {
        base.changeLeft();

        for (int i = 0; i < eachSide.Length; i++)
        {
            if (eachSide[i].direction == sides.left)
            {
                
                if (i == 0) eachSide[2].conection.Clear();
                if (i == 1) eachSide[3].conection.Clear();
                if (i == 2) eachSide[0].conection.Clear();
                if (i == 3) eachSide[1].conection.Clear();
                

                foreach (var tile in tileLeft.eachSide)
                {
                    if (tile.direction == sides.right)
                    {
                        foreach (var con in tile.conection)
                        {
                            if (i == 0) { eachSide[2].conection.Add(con); setDir(2); }
                            if (i == 1) { eachSide[3].conection.Add(con); setDir(3); }
                            if (i == 2) { eachSide[0].conection.Add(con); setDir(0); }
                            if (i == 3) { eachSide[1].conection.Add(con); setDir(1); }
                        }
                    }
                }
            }
        }
    }


    public override void changeRight()
    {
        base.changeRight();

        for (int i = 0; i < eachSide.Length; i++)
        {
            if (eachSide[i].direction == sides.right)
            {
                
                if (i == 0) eachSide[2].conection.Clear();
                if (i == 1) eachSide[3].conection.Clear();
                if (i == 2) eachSide[0].conection.Clear();
                if (i == 3) eachSide[1].conection.Clear();
                

                foreach (var tile in tileRight.eachSide)
                {
                    if (tile.direction == sides.left)
                    {
                        foreach (var con in tile.conection)
                        {
                            if (i == 0) { eachSide[2].conection.Add(con); setDir(2); }
                            if (i == 1) { eachSide[3].conection.Add(con); setDir(3); }
                            if (i == 2) { eachSide[0].conection.Add(con); setDir(0); }
                            if (i == 3) { eachSide[1].conection.Add(con); setDir(1); }
                        }
                    }
                }
            }
        }
    }



}
