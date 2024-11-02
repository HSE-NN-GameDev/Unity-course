using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, ISaveLoad
{
    Rigidbody2D rb;

    Vector2 lastPos;

    [SerializeField]
    float speed = 120;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horInput, verInput) * speed;
           
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        lastPos = transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rb.velocity = Vector2.zero;
        transform.position = lastPos;
    }

    public void Load(SaveStruct saveStruct)
    {
        transform.position = saveStruct.pos;
    }

    public void Save(SaveStruct saveStruct)
    {
        saveStruct.pos = transform.position;
    }

}
