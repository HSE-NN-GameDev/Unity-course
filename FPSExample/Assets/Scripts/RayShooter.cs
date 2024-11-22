using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    Camera cam;
    enum ShootingType { Single, Auto}

    [SerializeField] ShootingType shootingType;
    [SerializeField] ParticleSystem flash;
    [SerializeField] GameObject hole;
    [SerializeField] Vector3 recoilPower;
    [SerializeField] float retSpeed;
    [SerializeField] float snap;

    Vector3 targetRot;
    Vector3 currentRot;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        targetRot = Vector3.Lerp(targetRot, Vector3.zero, retSpeed * Time.deltaTime);
        currentRot = Vector3.Slerp(currentRot, targetRot, snap * 0.1f);
        transform.localRotation = Quaternion.Euler(currentRot);

        if (Input.GetMouseButtonDown(0))
        {
            switch (shootingType)
            {
                case ShootingType.Single:
                    SingleShot();
                    break;
                case ShootingType.Auto:
                    StartCoroutine(AutoShot());
                    break;

            }
        }       
    }

    void SingleShot()
    {
        flash.Play();
        CountRecoil();
        Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);

        Ray ray = cam.ScreenPointToRay(point);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            GameObject obj = hit.transform.gameObject;

            Instantiate(hole, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }

    IEnumerator AutoShot()
    {
        while (Input.GetMouseButton(0))
        {
            SingleShot();
            yield return new WaitForSeconds(0.2f);
        }
    }

    void CountRecoil()
    {
        targetRot += new Vector3(recoilPower.x, 
            Random.Range(-recoilPower.y, recoilPower.y), 
            Random.Range(-recoilPower.z, recoilPower.z)); 
    }
}
