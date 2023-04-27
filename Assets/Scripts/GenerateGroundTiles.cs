using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Later on, use a global zoom var to determin how many ground tiles to draw

// Alternatively, use this as a terrain generation tool which outputs a list of objects so that a renderer
// can draw them in its own Update()
public class GenerateGroundTiles : MonoBehaviour
{
    public GameObject dirt, grass, ant;
    public int width, height;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = -width / 2; x < width / 2; x++)
        {
            for (int y = -1; y > -height; y--)
            {
                SpawnObject(dirt, x, y);
            }
            SpawnObject(grass, x, -0.4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObject(GameObject obj, float x, float y)
    {
        obj = Instantiate(obj, new Vector3(x, y, 0), Quaternion.identity);
        obj.tag = "ground";
        obj.transform.parent = transform;
    }
}
