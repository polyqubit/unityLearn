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
            y = RandomWalk(y);
            SpawnObject(grass, x, y);
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

    private int RandomWalk(int y)
    {
        float percent = Random.value; // how much the ground will go up/down(60% for +-0, 25% f0r +-1, 10% for +-2, 5% for +-3)
        int mult = (Random.value > 0.5f) ? 1 : -1; // 50% chance for terrain to go up or down
        if (percent < 0.05f)
        {
            return y + mult * 3;
        }
        else if (percent < (0.05f + 0.1f))
        {
            return y + mult * 2;
        }
        else if (percent < ((0.05f + 0.1f) + 0.25f))
        {
            return y + mult * 1;
        }
        return 0;
    }
}



/* terrain gen
 * idea 1: sin(x / a) -> generates grass blocks with dirt extending (in?)finitely under
 * [idea 2]: random walk generation -> starting from (0, 0), grass blocks may be placed y-1, y, or y+1 from previous(recursive?)
*/