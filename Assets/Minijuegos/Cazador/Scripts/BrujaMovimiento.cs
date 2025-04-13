using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BrujaMovimiento : MonoBehaviour
{
    public float velocidadHorizontal = 2f;
    public float distanciaHorizontal = 3f;

    public float amplitudFlote = 0.5f;
    public float frecuenciaFlote = 2f;

    private Rigidbody2D rb;
    private Vector3 posicionInicial;
    private bool yendoDerecha = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // para que no caiga
        posicionInicial = transform.position;
    }

    void FixedUpdate()
    {
        // Movimiento horizontal con física
        float movimiento = yendoDerecha ? velocidadHorizontal : -velocidadHorizontal;
        rb.linearVelocity = new Vector2(movimiento, rb.linearVelocity.y);

        if (transform.position.x >= posicionInicial.x + distanciaHorizontal)
            yendoDerecha = false;
        else if (transform.position.x <= posicionInicial.x - distanciaHorizontal)
            yendoDerecha = true;
    }

    void Update()
    {
        // Movimiento vertical tipo flote (sin afectar Rigidbody)
        float offsetY = Mathf.Sin(Time.time * frecuenciaFlote) * amplitudFlote;
        Vector3 nuevaPos = new Vector3(transform.position.x, posicionInicial.y + offsetY, transform.position.z);
        transform.position = nuevaPos;
    }
}
