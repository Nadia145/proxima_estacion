using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeAuxiliar : MonoBehaviour
{
    // Variables para el efecto de parpadeo
    public Image fadePanel;
    public float fadeDuration = 1f;
    public float blackPanelDuration = 1f;

    void Start()
    {
        fadePanel.color = new Color(0, 0, 0, 0);
    }

    public void OnMouseDown(bool fadeOut)
    {
        StartCoroutine(FadeOutIn(fadeOut));
    }

    private IEnumerator FadeOutIn(bool fadeOut)
    {
        if (fadeOut) {
            yield return StartCoroutine(FadeTo(1, fadeDuration));
        } else {
            yield return fadePanel.color = new Color(0, 0, 0, 1);
        }

        // Mantener el panel completamente negro durante un tiempo
        yield return new WaitForSeconds(blackPanelDuration);

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
