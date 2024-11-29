using UnityEngine;
using UnityEngine.InputSystem;


public class Mover : MonoBehaviour
{
    public Camera cam;

    bool follow = false;

    public void SetFollow()
    {
        follow = true;
    }

    public void Done()
    {
        follow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            Vector3 curPos = Touchscreen.current.position.ReadValue();
            curPos.z = cam.transform.position.y;
            Vector3 newPos = cam.ScreenToWorldPoint(curPos);
            newPos.y = transform.position.y;
            transform.position = newPos;
        }
    }

   
}
