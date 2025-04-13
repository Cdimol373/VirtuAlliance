using UnityEngine;

public class CazadorDisparoNuevo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos = 0.5f;
    public float velocidadBala = 10f; // <-- Añadido

    private float tiempoUltimoDisparo;

    public void Disparar()
    {
        if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos)
        {
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);

            // Darle velocidad
            Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
            if (rbBala != null)
            {
                rbBala.linearVelocity = new Vector2(transform.localScale.x * velocidadBala, 0f);
            }

            tiempoUltimoDisparo = Time.time;
        }
    }
}
