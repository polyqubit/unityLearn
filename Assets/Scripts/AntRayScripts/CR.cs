using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CR : MonoBehaviour
{
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("transform");
            transform.parent.GetComponent<PlayerMovement>().SetColliderState(4, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            transform.parent.GetComponent<PlayerMovement>().SetColliderState(4, false);
        }
    }
}
