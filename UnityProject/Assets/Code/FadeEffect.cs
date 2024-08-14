using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    // Variables para el cambio de estacion
    public Vector3 newCameraPosition;
    public GameObject objetsToActivate;
    private Camera mainCamera;

    // Variables para el efecto de parpadeo
    public Image fadePanel;
    public float fadeDuration = 1f;
    public float blackPanelDuration = 1f;

    void Start()
    {
        mainCamera = Camera.main;
        fadePanel.color = new Color(0, 0, 0, 0);
    }

    public void OnMouseDown()
    {
        StartCoroutine(FadeOutIn());
        Debug.Log("Se llama la animacion");
    }

    private IEnumerator FadeOutIn()
    {
        // Fade out (panel negro)
        yield return StartCoroutine(FadeTo(1, fadeDuration));

        // Mantener el panel completamente negro durante un tiempo
        yield return new WaitForSeconds(blackPanelDuration);

        // ACodigo a ejecutar mientras el panel es negro
        objetsToActivate.SetActive(true);
        mainCamera.transform.position = newCameraPosition;

        // Fade in (panel negro)
        yield return StartCoroutine(FadeTo(0, fadeDuration));
    }

    private IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = fadePanel.color.a;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadePanel.color = new Color(0, 0, 0, targetAlpha);
    }
}
