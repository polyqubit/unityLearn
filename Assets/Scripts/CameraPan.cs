using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0)) {
            Vector3 dir = startPos - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += dir;
        }
    }

    public void SetPos(float x, float y)
    {
        Camera.main.transform.position = new Vector3(x, y, -10);
    }

    public void zoom(float scale)
    {
        Camera.main.orthographicSize = scale;
    }
}
