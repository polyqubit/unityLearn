using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] bool ar, al, br, bl, cr, cl;
    // Start is called before the first frame update
    void Start()
    {
        
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
