using UnityEngine;

public class MagicBookGaze : MonoBehaviour
{
    public float gazeTimeRequired = 2f; // Tiempo en segundos para activar la magia
    private float gazeTimer = 0f; // Contador de tiempo de mirada
    private bool isGazedAt = false; // ¿El jugador está mirando el libro?
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>(); // Obtener el material del libro
    }

    void Update()
    {
        if (isGazedAt)
        {
            gazeTimer += Time.deltaTime; // Incrementa el tiempo de mirada

            // Cambiar el color del libro a medida que aumenta el tiempo de mirada
            rend.material.color = Color.Lerp(Color.white, Color.blue, gazeTimer / gazeTimeRequired);

            if (gazeTimer >= gazeTimeRequired) // Si la mirada dura suficiente tiempo...
            {
                ActivateMagic(); // Ejecuta el efecto mágico
                gazeTimer = 0f; // Reinicia el contador
            }
        }
        else
        {
            gazeTimer = 0f; // Si el jugador deja de mirar, reinicia el temporizador
            rend.material.color = Color.white; // Restaurar color normal
        }
    }

    // Detectar cuándo la mirada entra en el libro
    public void OnPointerEnter()
    {
        isGazedAt = true;
    }

    // Detectar cuándo la mirada sale del libro
    public void OnPointerExit()
    {
        isGazedAt = false;
    }

    // Acción que ocurre cuando la mirada se mantiene el tiempo suficiente
    void ActivateMagic()
    {
        Debug.Log("✨ ¡Magia activada! ✨");
        transform.position += Vector3.up * 0.5f; // Mueve el libro hacia arriba (flotación)
    }
}
