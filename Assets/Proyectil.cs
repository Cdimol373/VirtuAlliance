using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Se destruye si sale de cámara
    }
}
