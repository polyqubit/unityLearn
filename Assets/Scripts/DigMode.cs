using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigMode : MonoBehaviour
{
    private bool dmode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleDigMode()
    {
        dmode = !dmode;
    }

    void DisplayBreakableTiles()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dmode)
        {
            DisplayBreakableTiles();
        }
    }
}
