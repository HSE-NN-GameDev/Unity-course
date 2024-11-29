using UnityEngine;
using System.Collections;
using UnityEngine.Android;

public class CamScript : MonoBehaviour
{
    public Material CameraMaterial = null;
    
    private WebCamTexture m_texture = null;


    private void PermissionCallbacksPermissionGranted(string permissionName)
    {
        StartCoroutine(DelayedCameraInitialization());
    }

    private IEnumerator DelayedCameraInitialization()
    {
        yield return new WaitForSeconds(3);
        LaunchCamera();
    }

    private void PermissionCallbacksPermissionDenied(string permissionName)
    {
        Debug.LogWarning($"Permission {permissionName} Denied");
    }

    private void AskCameraPermission()
    {
        var callbacks = new PermissionCallbacks();
        callbacks.PermissionDenied += PermissionCallbacksPermissionDenied;
        callbacks.PermissionGranted += PermissionCallbacksPermissionGranted;
        Permission.RequestUserPermission(Permission.Camera, callbacks);
    }

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            AskCameraPermission();
            return;
        }
        StartCoroutine(LaunchCamera());
    }

    IEnumerator LaunchCamera()
    {
        yield return new WaitForSeconds(3);

        if (Application.HasUserAuthorization(UserAuthorization.WebCam) && m_texture == null)
        {
            if (null != WebCamTexture.devices)
            {
                for (int index = 0; index < WebCamTexture.devices.Length; ++index)
                {
                    Debug.Log(WebCamTexture.devices[index].name);
                }

                // use the device name
                m_texture = new WebCamTexture("Remote Camera 2");

                // start playing
                m_texture.Play();

                // assign the texture
                CameraMaterial.mainTexture = m_texture;
            }
        }
    }
}
