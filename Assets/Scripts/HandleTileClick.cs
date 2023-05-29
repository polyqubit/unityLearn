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

    // OnMouseClick is called on mouse click
    private void OnMouseDown()
    {
        Vector2 pos = transform.position;
        if (Physics2D.OverlapCircle(new Vector2(pos.x, pos.y), 0.2f, LayerMask.GetMask("Ignore Raycast")) is not null)
        {
            Debug.Log(transform.position);
        }
    }
}
