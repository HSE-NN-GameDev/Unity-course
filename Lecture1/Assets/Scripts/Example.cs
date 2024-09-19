using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public int Field1;
    private int Field2;
    [SerializeField]
    private int Field3;
    [SerializeField]
    [Range(1, 10)]
    private int Field4;
    // Start is called before the first frame update
    void Start()
    {
        Field4 = 100;    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Field4); 
    }
}
