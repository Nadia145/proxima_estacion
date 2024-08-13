using UnityEngine;
using UnityEngine.UI;

public class Bajarse : MonoBehaviour
{
    public GameObject imageToShow;
    public GameObject imageToClose;
    public Button bajarseButton;

    void Start()
    {
        bajarseButton.onClick.AddListener(popUpPanel);
    }

    void popUpPanel() {
        imageToClose.SetActive(false);
        imageToShow.SetActive(true);
    }
}
