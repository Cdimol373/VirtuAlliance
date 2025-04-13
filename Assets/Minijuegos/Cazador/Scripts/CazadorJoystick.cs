using UnityEngine;

public class CazadorJoystick : MonoBehaviour
{
    [Header("Movimiento")]
    public FixedJoystick joystick;
    public float velocidad = 5f;

    [Header("Salto")]
    public float fuerzaSalto = 5f;
    public Transform verificadorSuelo;
    public float radioVerificacion = 0.2f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Mover();
    }

    void Mover()
    {
        float horizontal = joystick.Horizontal;
        rb.linearVelocity = new Vector2(horizontal * velocidad, rb.linearVelocity.y);
    }

    public void Saltar()
    {
        bool enSuelo = Physics2D.OverlapCircle(verificadorSuelo.position, radioVerificacion, capaSuelo);
        if (enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }
}
