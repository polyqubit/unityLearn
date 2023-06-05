using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    private bool active = false;
    private bool first = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleButton()
    {
        GameObject b = transform.Find("digbutton").gameObject;
        if(first)
        {
            Destroy(transform.Find("menu").transform.Find("bob").gameObject);
            first = false;
        }
        if (!active) //180,-40
        {
            b.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(180, -40);
            active = true;
        }
        else 
        {
            b.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(-100, 100);
            active = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
