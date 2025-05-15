using UnityEngine;
using UnityEngine.EventSystems;  // Necesario para la interfaz IPointerDownHandler

public class Pato : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        // Llamamos al método del GameManager para agregar un punto
        FindFirstObjectByType<Funcionamiento>()?.AddPoint();  // Llamamos al GameManager para añadir puntos

        // Llamamos al GameManager para reproducir el sonido del disparo
        FindFirstObjectByType<Funcionamiento>()?.PlayDisparoSound();  // Reproducir sonido al disparar

        // Hacer vibrar el dispositivo móvil
        Handheld.Vibrate();  // Llama a la vibración del dispositivo

        // Destruir el Pato cuando se toque
        Destroy(gameObject);
    }
}
