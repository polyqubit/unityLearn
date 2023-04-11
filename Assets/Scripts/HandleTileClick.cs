using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTileClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnMouseDlick is called on mouse click
    private void OnMouseDown()
    {
        Debug.Log(transform.position);
    }
}
