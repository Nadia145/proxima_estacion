using UnityEngine;
using UnityEngine.UI;

public class ClickToShowImage : MonoBehaviour
{
    public GameObject imageToShow;

    void Start()
    {
        if (imageToShow != null)
        {
            imageToShow.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (imageToShow != null)
        {
            imageToShow.SetActive(!imageToShow.activeSelf);
        }
    }
}
