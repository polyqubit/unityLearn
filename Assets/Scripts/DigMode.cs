using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigMode : MonoBehaviour
{
    public GameObject locate;
    public GameObject cam;
    private CameraPan cp;
    private bool dmode = false;
    private bool f = true;
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
        if (f)
        {
            GameObject.Find("/Canvas/hi").GetComponent<TMPro.TextMeshProUGUI>().text = 
                "use left/right arrows to delete objects to left and right\n" +
                "note that the ant will not enable climbing while in dig mode\n" +
                "additionally 3 blocks are highlighted under the ant\n" +
                "clicking on these willbreak those blocks\n" +
                "the ant will fall if the block is directly under it\n" +
                "digging to the bottom of the world will result in getting stuck\n" +
                "additionally, there is a bug where the ant will tunnel unexpectedly\n" +
                "this bug occurs outside of digmode when moving into a wall\n" +
                "however, in some situations this is the only way to exit a hole";
            f = false;
            StartCoroutine(wait());
        }
        Vector2 bob = transform.position;
        dmode = !dmode;
        DisplayBreakableTiles();
        cp.SetPos(bob.x, bob.y);
        cp.zoom(dmode ? 4 : 7);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("/Canvas/hi").GetComponent<TMPro.TextMeshProUGUI>().text = "did you get all that?";
        yield return new WaitForSeconds(5);
        GameObject.Find("/Canvas/hi").GetComponent<TMPro.TextMeshProUGUI>().text = "";
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
        if (dmode && Input.GetMouseButton(0))
        {
            Vector3 bob = transform.position;
            int c = 0;
            while ((c < 100) && Physics2D.OverlapCircle(new Vector2(bob.x, bob.y - 1), 0.2f, LayerMask.GetMask("ground")) is null)
            {
                Debug.Log("going: " + bob.y);
                bob.y--;
                c++;
            }
            transform.position = (c < 100) ? bob : transform.position;
        }
        if (dmode)
        {
            y = Mathf.Abs(transform.position.y) % 1;
            locate.transform.localPosition = new Vector2(0, y);
            cp.SetPos(transform.position.x, transform.position.y);
        }
    }

    public bool IsDig()
    {
        return dmode;
    }
}