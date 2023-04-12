using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontal, speed;
    private bool facingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    //private void Flip()
    //{
    //    if(facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
    //    {
    //        facingRight = !facingRight;
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1f;
    //        transform.localScale = localScale;
    //    }
    //}

    private int HitboxCheck(bool right)
    {
        Vector3 pos = transform.position;
        if(right)
        {
            
        }
        return 0;
    }

    public void Left()
    {
        // left movement
    }
}
