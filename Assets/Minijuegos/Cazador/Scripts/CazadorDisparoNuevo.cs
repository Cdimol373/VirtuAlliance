using UnityEngine;

public class CazadorDisparoNuevo : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float velocidadBala = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);

        // Detectar dirección mirando el scale del cazador (por si se voltea)
        float direccion = transform.localScale.x > 0 ? 1f : -1f;

        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(direccion * velocidadBala, 0f);
    }
}
