using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContraoller : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speed;
    float horInp;
    Animator anim;
    SpriteRenderer spR;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spR = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horInp = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * horInp, 0);
        if (horInp != 0)
        {
            anim.SetBool("Walking", true);
            if (horInp > 0)
            {
                spR.flipX = false;
            }
            else if (horInp < 0)
            {
                spR.flipX = true;
            }
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }
}
