using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    [SerializeField] Toggle touchTgl;
    [SerializeField] Toggle gyroTgl;
    [SerializeField] GameObject plane;

    bool touchFollow = true;

    Transform rotator;

    Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        rotator = new GameObject("Rotator").transform;
        rotator.SetPositionAndRotation(transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!AttitudeSensor.current.enabled)
            InputSystem.EnableDevice(AttitudeSensor.current);
        
        rotator.rotation = AttitudeSensor.current.attitude.ReadValue();
        rotator.Rotate(0f, 0f, 180f, Space.Self);
        rotator.Rotate(90f, 180f, 0f, Space.World);

        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, rotator.rotation, Time.deltaTime * 3);
        
    }

    public void MoveToFinger(InputAction.CallbackContext context)
    {
        if (touchFollow)
        {
            Vector3 curPos = context.ReadValue<Vector2>();

            curPos.z = cam.transform.position.y;
            Vector3 newPos = cam.ScreenToWorldPoint(curPos);
            newPos.y = transform.position.y;
            transform.position = newPos;
        }
        
    }

    public void StopFollow()
    {
        touchFollow = false;
    }

    public void Follow()
    {
        touchFollow = true; 
    }
}
