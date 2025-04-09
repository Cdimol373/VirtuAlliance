using UnityEngine;
using TMPro; // Si vas a usar TextMeshPro

public class PuntuacionTotal : MonoBehaviour
{
    public static PuntuacionTotal instancia;  // Singleton
    public int puntuacionTotal = 0;  // Puntaje total acumulado
    public TextMeshProUGUI textoPuntuacion; // Referencia al texto de puntuación en pantalla

    void Awake()
    {
        // Comprobamos si ya existe una instancia
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Mantener entre escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe, destruimos la nueva instancia
        }
    }

    // Método para agregar puntos al puntaje total
    public void AgregarPuntuacionTotal(int puntos)
    {
        puntuacionTotal += puntos;
        Debug.Log("Puntuación Total: " + puntuacionTotal);
        ActualizarTexto(); // Actualizamos el texto en pantalla
    }

    // Método para obtener la puntuación total
    public int ObtenerPuntuacionTotal()
    {
        return puntuacionTotal;
    }

    // Método para actualizar el texto de la puntuación en pantalla
    void ActualizarTexto()
    {
        if (textoPuntuacion != null)
        {
            textoPuntuacion.text = "Puntuación Total: " + puntuacionTotal;
        }
    }
}