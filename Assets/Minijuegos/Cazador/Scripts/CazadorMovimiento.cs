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
        Vector3 nuevaPos = transform.position;

        // --- Movimiento por teclado (PC) ---
        if (Input.GetAxis("Horizontal") != 0)
        {
            float movimiento = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);
        }
        // --- Movimiento con el mouse (clic sostenido) ---
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            nuevaPos = new Vector3(mousePos.x, transform.position.y, 0f);
            transform.position = Vector3.Lerp(transform.position, nuevaPos, velocidad * Time.deltaTime);
        }
        // --- Movimiento con el dedo (móviles) ---
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;
            nuevaPos = new Vector3(touchPos.x, transform.position.y, 0f);
            transform.position = Vector3.Lerp(transform.position, nuevaPos, velocidad * Time.deltaTime);
        }

        // Limitar al borde de la pantalla horizontalmente
        Vector3 posVista = Camera.main.WorldToViewportPoint(transform.position);
        posVista.x = Mathf.Clamp(posVista.x, 0.05f, 0.95f);
        transform.position = Camera.main.ViewportToWorldPoint(posVista);

        // Verificar si está en el suelo para saltar
        enSuelo = Physics2D.OverlapCircle(verificadorSuelo.position, radioVerificacion, capaSuelo);

        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).tapCount == 2)) && enSuelo)
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
