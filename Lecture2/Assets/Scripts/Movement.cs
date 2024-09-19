using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float In;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        In = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(0, 10));

        In = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(10, 0));
    }
}
