using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigMode : MonoBehaviour
{
    public GameObject locate;
    private bool dmode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleDigMode()
    {
        //dmode = !dmode;
        //Debug.Log("dmode:" + dmode);
        DisplayBreakableTiles();
    }

    void DisplayBreakableTiles()
    {
        //Vector3 pos = transform.position;
        //Collider2D right = Physics2D.OverlapCircle(new Vector2(pos.x + 1, pos.y), 0.2f, LayerMask.GetMask("ground"));
        //if (right is not null)
        //{
        //    Debug.Log(right);
        //}
        Instantiate(locate, transform); //.transform.position = new Vector2(-1, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
