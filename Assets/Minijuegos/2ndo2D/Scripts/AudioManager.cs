using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip disparoClip; // El clip de sonido del disparo
    private AudioSource audioSource; // El AudioSource que usaremos para reproducir el sonido

    void Start()
    {
        // Asegúrate de que haya un AudioSource en el AudioManager
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayDisparoSound()
    {
        if (audioSource != null && disparoClip != null)
        {
            audioSource.PlayOneShot(disparoClip); // Reproduce el sonido del disparo
        }
    }
}
