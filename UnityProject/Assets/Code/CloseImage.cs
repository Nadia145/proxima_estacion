using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseImage : MonoBehaviour
{
    // Variables del Mensaje
    public GameObject imageToClose;
    public Button closeButton;

    // Variables de la camara
    public Vector3 newCameraPosition;
    private Camera mainCamera;

    // Variables de los objetos
    public GameObject objects;
    public bool isObject;

    void Start()
    {
        closeButton.onClick.AddListener(CloseImagePanel);
        mainCamera = Camera.main;
    }

    void CloseImagePanel()
    {
        imageToClose.SetActive(false);
        // Si se esta cerrando un objeto, se mantiene la posicion de la camara actual
        if (isObject) {
            newCameraPosition = mainCamera.transform.position;
        }
        // Si no es un objeto, se mueve a la nueva posición
        mainCamera.transform.position = newCameraPosition;
        objects.SetActive(true);
    }
}
