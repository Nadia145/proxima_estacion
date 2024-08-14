using UnityEngine;
using UnityEngine.UI;

public class ClickToShowImage : MonoBehaviour
{
    public GameObject imageToShow;
    public GameObject objects;

    void Start()
    {
        if (imageToShow != null)
        {
            imageToShow.SetActive(false);
            objects.SetActive(true);
        }
    }

    public void OnMouseDown()
    {
        if (imageToShow != null)
        {
            imageToShow.SetActive(!imageToShow.activeSelf);
            objects.SetActive(!objects.activeSelf);
        }
    }
}
