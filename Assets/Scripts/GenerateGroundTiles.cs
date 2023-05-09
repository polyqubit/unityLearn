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
        int y = 0;
        for (int x = -width / 2; x < width / 2; x++)
        {
            y += RandomWalk();
            SpawnObject(grass, x, y);
            for(int i = y - 1; i > -height; i--)
            {
                SpawnObject(dirt, x, i);
            }
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

    private int RandomWalk()
    {
        float percent = Random.value;
        int mult = (Random.value > 0.5f) ? 1 : -1; // 50% chance for terrain to go up or down
        if (percent < 0.02f)
        {
            return mult * 3;
        }
        else if (percent < (0.02f + 0.07f))
        {
            return mult * 2;
        }
        else if (percent < ((0.02f + 0.1f) + 0.25f))
        {
            return mult * 1;
        }
        return 0;
    }
}



/* terrain gen
 * idea 1: sin(x / a) -> generates grass blocks with dirt extending (in?)finitely under
 * [idea 2]: random walk generation -> starting from (0, 0), grass blocks may be placed y-1, y, or y+1 from previous(recursive?)
*/