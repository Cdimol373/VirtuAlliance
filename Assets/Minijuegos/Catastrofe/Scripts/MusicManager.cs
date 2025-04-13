using UnityEngine;

public class MusicaManager : MonoBehaviour
{
    public static MusicaManager instancia;
    private AudioSource audioSource;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirMusica()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void DetenerMusica()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }
}
