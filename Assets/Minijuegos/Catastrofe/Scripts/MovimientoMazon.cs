using UnityEngine;
using TMPro;

public class MazonMovimiento : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    private float speed = 200f; // Velocidad de movimiento

    public int vidas = 3; // Numero de vidas iniciales
    public TextMeshProUGUI vidasContador;  // Referencia al texto UI de vidas
    public GeneradorDeObjetos generadorObjetos;  // Referencia al script de GeneradorObjetos
    public GameObject hasDimitidoText; 

    // Tema vidas

    void Start()
    {
       
        ActualizarVidasUI(); //Actualizar vidas al iniciar
    }

    void Update()
    {
        if (Input.touchCount > 0) // Si hay una entrada táctil
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                touchEndPos = Camera.main.ScreenToWorldPoint(touch.position);
                Vector3 movement = new Vector3(touchEndPos.x - touchStartPos.x, 0, 0);
                transform.position += movement * speed * Time.deltaTime;
                touchStartPos = touchEndPos;
            }
        }
    }

    // Detectar cuando choca contra mazon un objeto y restarle vida

    public void RestarVidasMazon ()
    {
            vidas--; // Resta una vida
            Debug.Log("Vidas restantes: " + vidas);
           
            // Actualizar vidas
            ActualizarVidasUI();
            DetenerGeneracion();
    }

    void DetenerGeneracion()
    {
        if (vidas <= 0)
        {
            
            // Opcional: Puedes desactivar el movimiento si quieres que el personaje deje de moverse
            this.enabled = false;

            // Detener la generación de objetos
            if (generadorObjetos != null)
            {
                hasDimitidoText.SetActive(true);
                generadorObjetos.DetenerGeneracion();  // Desactiva el script de generación de objetos
            }
        }
    }

    void ActualizarVidasUI()
    {
        vidasContador.text = "" + vidas;
    }


}

