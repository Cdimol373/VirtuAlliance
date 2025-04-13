using UnityEngine;

public class BrujaMovimiento : MonoBehaviour
{
    public float velocidadHorizontal = 2f;
    public float distanciaHorizontal = 3f;

    public float amplitudFlote = 0.5f; // qué tanto sube y baja
    public float frecuenciaFlote = 2f; // qué tan rápido flota

    private Vector3 posicionInicial;
    private bool yendoDerecha = true;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Movimiento horizontal tipo patrulla
        float movimiento = velocidadHorizontal * Time.deltaTime;

        if (yendoDerecha)
        {
            transform.Translate(Vector2.right * movimiento);
            if (transform.position.x >= posicionInicial.x + distanciaHorizontal)
                yendoDerecha = false;
        }
        else
        {
            transform.Translate(Vector2.left * movimiento);
            if (transform.position.x <= posicionInicial.x - distanciaHorizontal)
                yendoDerecha = true;
        }

        // Movimiento de flote vertical (suavemente)
        float offsetY = Mathf.Sin(Time.time * frecuenciaFlote) * amplitudFlote;
        Vector3 nuevaPosicion = new Vector3(transform.position.x, posicionInicial.y + offsetY, transform.position.z);
        transform.position = nuevaPosicion;
    }
}
