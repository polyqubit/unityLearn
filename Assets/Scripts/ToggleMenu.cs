using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleButton()
    {
        if (!active)
        {
            GameObject button = UnityEngine.UI.DefaultControls.CreateButton(new UnityEngine.UI.DefaultControls.Resources());
            button.transform.position = new Vector3(50, 50, 0);
            button.transform.name = "bobberton";
            button.transform.SetParent(transform);
            active = true;
        }
        else 
        {
            Destroy(transform.Find("bobberton").gameObject);
            active = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
