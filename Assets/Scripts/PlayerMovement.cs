using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject cam;
    private bool climb;
    private bool side;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -10000, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Place()
    {
        int y = 10;
        int c = 0;
        Vector3 bob = new Vector3(0, y, 0);
        climb = false;
        side = false;
        while ((c < 50) && Physics2D.OverlapCircle(new Vector2(0, y + 1), 0.2f, LayerMask.GetMask("ground")) is not null)
        {
            c++;
            bob.y = ++y;
        }
        while ((c < 50) && Physics2D.OverlapCircle(new Vector2(0, y - 1), 0.2f, LayerMask.GetMask("ground")) is null)
        {
            c++;
            bob.y = --y;
        }
        transform.position = bob;
        CameraPan cp = (CameraPan)cam.GetComponent(typeof(CameraPan));
        cp.SetPos(bob.x, bob.y);
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
        if (climb) {
            if (side)
            {
                if (right && (Physics2D.OverlapCircle(new Vector2(pos.x + 1, pos.y + 0.5f), 0.2f, LayerMask.GetMask("ground")) is null))
                {
                    transform.position = new Vector3(pos.x + 1, pos.y + 0.5f);
                    climb = false;
                }
                else if (!right && (Physics2D.OverlapCircle(new Vector2(pos.x, pos.y - 1.5f), 0.2f, LayerMask.GetMask("ground")) is not null))
                {
                    transform.position = new Vector3(pos.x, pos.y - 0.5f);
                    climb = false;
                }
                else
                {
                    if (!right && (Physics2D.OverlapCircle(new Vector2(pos.x + 1, pos.y - 0.5f), 0.2f, LayerMask.GetMask("ground")) is not null))
                    {
                        transform.position = new Vector3(pos.x, pos.y - 1);
                    }
                    else if (right)
                    {
                        transform.position = new Vector3(pos.x, pos.y + 1);
                    }
                }
            }
            else
            {
                if (!right && (Physics2D.OverlapCircle(new Vector2(pos.x - 1, pos.y + 0.5f), 0.2f, LayerMask.GetMask("ground")) is null))
                {
                    transform.position = new Vector3(pos.x - 1, pos.y + 0.5f);
                    climb = false;
                }
                else if (right && (Physics2D.OverlapCircle(new Vector2(pos.x, pos.y - 1.5f), 0.2f, LayerMask.GetMask("ground")) is not null))
                {
                    transform.position = new Vector3(pos.x, pos.y - 0.5f);
                    climb = false;
                }
                else
                {
                    if (right && (Physics2D.OverlapCircle(new Vector2(pos.x - 1, pos.y - 0.5f), 0.2f, LayerMask.GetMask("ground")) is not null))
                    {
                        transform.position = new Vector3(pos.x, pos.y - 1);
                    }
                    else if (!right)
                    {
                        transform.position = new Vector3(pos.x, pos.y + 1);
                    }
                }
            }
        }
        else if (Physics2D.OverlapCircle(new Vector2(pos.x + direction, pos.y), 0.2f, LayerMask.GetMask("ground")) is not null) //b, same y
        {
            if (Physics2D.OverlapCircle(new Vector2(pos.x + direction, pos.y + 1), 0.2f, LayerMask.GetMask("ground")) is not null
                && Physics2D.OverlapCircle(new Vector2(pos.x, pos.y + 1), 0.2f, LayerMask.GetMask("ground")) is not null) //a, y+1
            {
                climb = true;
                side = right;
                transform.position = new Vector3(pos.x, pos.y + 0.5f);
            }
            else { transform.position = new Vector3(pos.x + direction, pos.y + 1); }
        }
        else if (Physics2D.OverlapCircle(new Vector2(pos.x + direction, pos.y - 1), 0.2f, LayerMask.GetMask("ground")) is not null) //c, y-1
        {
            transform.position = new Vector3(pos.x + direction, pos.y);
        }
        else if (Physics2D.OverlapCircle(new Vector2(pos.x + direction, pos.y - 2), 0.2f, LayerMask.GetMask("ground")) is not null) //d, y-2
        {
            transform.position = new Vector3(pos.x + direction, pos.y - 1);
        }
        else
        {
            climb = true;
            side = !right;
            if(side)
            {
                transform.position = new Vector3(pos.x - 1, pos.y - 0.5f);
            }
            else
            {
                transform.position = new Vector3(pos.x + 1, pos.y - 0.5f);
            }
        }
    }
}