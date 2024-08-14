using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    public Image fadePanel;
    public float fadeDuration = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        fadePanel.color = new Color(0, 0, 0, 1); // Iniciar en negro
        StartCoroutine(FadeTo(0, fadeDuration)); // Fade in al inicio
    }

    public void ChangeScene(int sceneIndex)
    {
        StartCoroutine(TransitionToScene(sceneIndex));
    }

    private IEnumerator TransitionToScene(int sceneIndex)
    {
        yield return StartCoroutine(FadeTo(1, fadeDuration)); // Fade out
        SceneManager.LoadScene(sceneIndex);
        yield return StartCoroutine(FadeTo(0, fadeDuration)); // Fade in
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
