using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigMode : MonoBehaviour
{
    public GameObject locate;
    private bool dmode = false;
    private float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleDigMode()
    {
        dmode = !dmode;
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
        locate = Instantiate(locate, transform);
        locate.transform.localPosition = new Vector2(0, y);
    }

    // Update is called once per frame
    void Update()
    {
        if (dmode)
        {
            y = (Mathf.Abs(transform.position.y) % 1);
            locate.transform.localPosition = new Vector2(0, y);
        }
    }
}
