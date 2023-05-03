using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxcollider2d;
    private BoxCollider2D boxCollider2d;
    [SerializeField] float jumpvelocity = 10f;
    [SerializeField] float movespeed = 6f;
    public float fallmultipier = 2.5f;
    public float lowjumpmultipier = 2f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switchspeed();
        betterjump();
        if(isground() && Input.GetKey(KeyCode.Space))
        {   
            rigidbody2d.velocity = Vector2.up * jumpvelocity;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            rigidbody2d.velocity = new Vector2(-movespeed, rigidbody2d.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            rigidbody2d.velocity = new Vector2(+movespeed, rigidbody2d.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else{
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
        }
    }
    void betterjump()
    {
         if(GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (fallmultipier-1) * Time.deltaTime;
                Debug.Log(fallmultipier-1);
            }
            else if(GetComponent<Rigidbody2D>().velocity.y > 0 && !Input.GetKey(KeyCode.Space) )
            {
                rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpmultipier-1) * Time.deltaTime;
                Debug.Log(lowjumpmultipier-1);
            }
    }
    private bool isground()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        return raycastHit2d.collider != null;
    }
    void switchspeed()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && movespeed ==10f)
        {
            movespeed = 15f;}
        else if(Input.GetKeyDown(KeyCode.LeftShift) && movespeed == 15)
        {
            movespeed = 10f;}
    }
}
    

