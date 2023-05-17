using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject button;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleButton()
    {
        if (!active)
        {
            GameObject b = Instantiate(button);
            b.transform.SetParent(transform);
            b.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(260, -40);
            b.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
            b.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
            b.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            b.GetComponent<RectTransform>().localScale = new Vector2(2, 2);
            active = true;
        }
        else 
        {
            Destroy(transform.Find("digbutton(Clone)").gameObject);
            active = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
