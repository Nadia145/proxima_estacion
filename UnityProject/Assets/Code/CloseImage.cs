using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseImage : MonoBehaviour
{
    public GameObject imageToClose;
    public Button closeButton;

    public Vector3 newCameraPosition;
    private Camera mainCamera;

    void Start()
    {
        closeButton.onClick.AddListener(CloseImagePanel);
        mainCamera = Camera.main;
    }

    void CloseImagePanel()
    {
        imageToClose.SetActive(false);
        mainCamera.transform.position = newCameraPosition;
    }
}
