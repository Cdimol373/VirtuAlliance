using UnityEngine;

public class SonidoImpacto : MonoBehaviour
{
    public AudioClip sonido;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && sonido != null)
        {
            audioSource.PlayOneShot(sonido);
        }
    }
}
