using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    private bool d;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p = transform.position;
        if (d && p.x < 120)
        {
            p.x++;
            p.y--;
        }
        else
        {
            d = false;
            p.x--;
            p.y++;
        }
        if (p.x < 100)
        {
            d = true;
        }
        transform.position = p;
    }
}
