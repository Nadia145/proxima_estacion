using UnityEngine;

public class PlayAudioOnPress : MonoBehaviour
{
    public AudioSource audioSource;

    public void OnMouseDown()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
