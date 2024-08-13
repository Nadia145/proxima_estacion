using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    public Vector3 newCameraPosition;
    private Camera mainCamera;

    public Image fadePanel;
    public float fadeDuration = 1f;

    void Start()
    {
        mainCamera = Camera.main;
        fadePanel.color = new Color(0, 0, 0, 0);
    }

    public void OnMouseDown()
    {
        StartCoroutine(FadeOutIn());
    }

    private IEnumerator FadeOutIn()
    {
        // Fade out (panel negro)
        yield return StartCoroutine(FadeTo(1, fadeDuration));

        // Aquí puedes poner el código que quieres ejecutar mientras el panel es negro
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
