using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            transform.parent.GetComponent<PlayerMovement>().SetColliderState(0, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            transform.parent.GetComponent<PlayerMovement>().SetColliderState(0, false);
        }
    }
}
