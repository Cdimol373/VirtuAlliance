using UnityEngine;

public class CazadorMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    private Rigidbody2D rb;
    private bool enSuelo;

    public Transform verificadorSuelo;
    public LayerMask capaSuelo;
    public float radioVerificacion = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

        enSuelo = Physics2D.OverlapCircle(verificadorSuelo.position, radioVerificacion, capaSuelo);

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (verificadorSuelo != null)
            Gizmos.DrawWireSphere(verificadorSuelo.position, radioVerificacion);
    }
}
