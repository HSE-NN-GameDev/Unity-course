using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float verticalRot = 0;
    float horizontalRot = 0;

    [SerializeField]
    float sens = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalRot -= Input.GetAxis("Mouse Y") * sens;
        verticalRot = Mathf.Clamp(verticalRot, -45, 45);

        float delta = Input.GetAxis("Mouse X") * sens;
        horizontalRot = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
    }
}
