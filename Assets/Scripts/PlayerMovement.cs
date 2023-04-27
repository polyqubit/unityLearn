using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool ar, al, br, bl, cr, cl;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //private void Flip()
    //{
    //    if(facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
    //    {
    //        facingRight = !facingRight;
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1f;
    //        transform.localScale = localScale;
    //    }
    //}

    private int HitboxCheck(bool right)
    {
        Vector3 pos = transform.position;
        if(right)
        {
            if(cr)
            {

            }
        }
        return 0;
    }

    public void Left()
    {
        // left movement
    }

    public void Right()
    {
        //Vector3 pos = transform.position;
        //transform.position.Set(pos.x + 1, pos.y, pos.z);
        Debug.Log("button");
        Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, 0.2f, LayerMask.GetMask("ground"));
        for (int i = 0; i < coll.Length; i++)
        {
            Debug.Log(coll[i]);
        }
    }

    private void SetBoolState() 
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, 1);
        for(int i = 0; i < coll.Length; i++)
        {
            Debug.Log(coll[i]);
        }
    }

    public void SetColliderState(int n, bool val)
    {
        Debug.Log("a");
        // goofyahh
        switch (n)
        {
            case 0:
                ar = val;
                break;
            case 1:
                al = val;
                break;
            case 2:
                br = val;
                break;
            case 3:
                bl = val;
                break;
            case 4:
                cr = val;
                break;
            case 5:
                cl = val;
                break;
        }
    }
}
