using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SpawnButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    GameObject cube;

    GameObject spwnd;
    Mover m;

    [SerializeField] UnityEvent pDown;
    [SerializeField] UnityEvent pUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 buttonPos = cam.ScreenToWorldPoint(transform.position);
        buttonPos.y -= 2;
            
        spwnd = Instantiate(cube, buttonPos, cube.transform.rotation);
        m = spwnd.GetComponent<Mover>();
        m.cam = cam;
        pDown.AddListener(m.SetFollow);
        pUp.AddListener(m.Done);
        pDown.Invoke();

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pUp.Invoke();
        pDown.RemoveListener(m.SetFollow);
    }
}
