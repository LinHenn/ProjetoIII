using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour
{

    public float speed = 1.0f;
    public int index = 0;
    public Transform[] locations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, locations[index].position, step);

        if (Vector3.Distance(transform.position, locations[index].position) < 0.5f)
        {
            // Swap the position of the cylinder.
            //locations[index].position *= -1.0f;
            if (index == 0) index++;
            else if (index == 1) index = 0;
        }
    }
}
