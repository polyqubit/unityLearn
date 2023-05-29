using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigMode : MonoBehaviour
{
    public GameObject locate;
    public GameObject cam;
    private CameraPan cp;
    private bool dmode = false;
    private float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        locate = Instantiate(locate, transform);
        locate.transform.localPosition = new Vector2(0, 1000);
        cp = (CameraPan)cam.GetComponent(typeof(CameraPan));
    }

    public void ToggleDigMode()
    {
        Vector2 bob = transform.position;
        dmode = !dmode;
        DisplayBreakableTiles();
        cp.SetPos(bob.x, bob.y);
        cp.zoom(dmode ? 3 : 7);
    }

    void DisplayBreakableTiles()
    {
        //Vector3 pos = transform.position;
        //Collider2D right = Physics2D.OverlapCircle(new Vector2(pos.x + 1, pos.y), 0.2f, LayerMask.GetMask("ground"));
        //if (right is not null)
        //{
        //    Debug.Log(right);
        //}
        if (dmode)
        {
            locate.transform.localPosition = new Vector2(0, y);
        }
        else
        {
            //Destroy(transform.Find("locator(Clone)").gameObject);
            locate.transform.localPosition = new Vector2(0, y + 1000);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dmode)
        {
            y = Mathf.Abs(transform.position.y) % 1;
            locate.transform.localPosition = new Vector2(0, y);
        }
        if (dmode && Input.GetMouseButton(0))
        {
            Vector3 bob = transform.position;
            while (Physics2D.OverlapCircle(new Vector2(bob.x, bob.y - 1), 0.2f, LayerMask.GetMask("ground")) is null)
            {
                Debug.Log("going: " + bob.y);
                bob.y--;
            }
            transform.position = bob;
        }
    }
}