using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool ar, al, br, bl, cr, cl;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.5f, 0);
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
        if(right)
        {
            if(Physics2D.OverlapCircle(new Vector2(pos.x + 1, pos.y), 0.2f, LayerMask.GetMask("ground")) is not null) //br
            {
                if(Physics2D.OverlapCircle(new Vector2(pos.x + 1, pos.y + 1), 0.2f, LayerMask.GetMask("ground")) is not null) //ar
                {
                    Debug.Log("wall!");
                }
                transform.position = new Vector3(pos.x + 1, pos.y + 1);
            }
            else if(Physics2D.OverlapCircle(new Vector2(pos.x + 1, pos.y - 1), 0.2f, LayerMask.GetMask("ground")) is not null) //cr
            {
                transform.position = new Vector3(pos.x + 1, pos.y);
            }
            else if (Physics2D.OverlapCircle(new Vector2(pos.x + 1, pos.y - 2), 0.2f, LayerMask.GetMask("ground")) is not null) //dr
            {
                transform.position = new Vector3(pos.x + 1, pos.y - 1);
            }
            else { Debug.Log("hole!"); }
            return;
        }
        al = Physics2D.OverlapCircle(new Vector2(pos.x - 1, pos.y + 1), 0.2f, LayerMask.GetMask("ground")) is not null;
        bl = Physics2D.OverlapCircle(new Vector2(pos.x - 1, pos.y), 0.2f, LayerMask.GetMask("ground")) is not null;
        cl = Physics2D.OverlapCircle(new Vector2(pos.x - 1, pos.y - 1), 0.2f, LayerMask.GetMask("ground")) is not null;
    }
}
