using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 newCameraPosition;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        if (mainCamera != null)
        {
            mainCamera.transform.position = newCameraPosition;
        }
    }
}
