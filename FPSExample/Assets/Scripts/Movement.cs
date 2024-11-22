using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    CharacterController charCont;
    // Start is called before the first frame update
    void Start()
    {
        charCont = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement *= Time.deltaTime * speed;
        movement = transform.TransformDirection(movement);

        movement.y = -9.8f * Time.deltaTime;

        charCont.Move(movement);
        
    }
}
