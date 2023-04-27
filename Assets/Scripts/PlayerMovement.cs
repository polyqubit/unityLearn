using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool ar, al, br, bl, cr, cl;
    private bool climb;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Left()
    {
        Move(false);
    }

    public void Right()
    {
        Move(true);
    }

    private void Move(bool right)
    {
        Vector3 pos = transform.position;
        int direction = right ? 1 : -1;
        if(Physics2D.OverlapCircle(new Vector2(pos.x + direction, pos.y), 0.2f, LayerMask.GetMask("ground")) is not null) //br
        {
            if(Physics2D.OverlapCircle(new Vector2(pos.x + direction, pos.y + 1), 0.2f, LayerMask.GetMask("ground")) is not null) //ar
            {
                Debug.Log("wall!");
            }
            else { transform.position = new Vector3(pos.x + direction, pos.y + 1); }
        }
        else if(Physics2D.OverlapCircle(new Vector2(pos.x + direction, pos.y - 1), 0.2f, LayerMask.GetMask("ground")) is not null) //cr
        {
            transform.position = new Vector3(pos.x + direction, pos.y);
        }
        else if (Physics2D.OverlapCircle(new Vector2(pos.x + direction, pos.y - 2), 0.2f, LayerMask.GetMask("ground")) is not null) //dr
        {
            transform.position = new Vector3(pos.x + direction, pos.y - 1);
        }
        else { Debug.Log("hole!"); }
    }
}